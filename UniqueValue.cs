using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace _2020114120王晨冲
{
    public partial class UniqueValue : Form
    {
        public static UniqueValue uniqueValue1;
        public static IMap pMap = null;
        IFeatureClass pFeatureClass = null;
        IFeatureLayer pFeatureLayer = new FeatureLayer();
        public UniqueValue(IMap map)
        {
            InitializeComponent();
            pMap = map;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UniqueValue_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.Layer[i] is FeatureLayer)
                {
                    cbxLayers.Items.Add(pMap.Layer[i].Name);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> attList = new List<string>();
            cbxFields.Items.Clear();
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if ((pMap.Layer[i] is FeatureLayer) && (pMap.Layer[i].Name == cbxLayers.Text))
                {
                    pFeatureLayer = pMap.Layer[i] as IFeatureLayer;
                    pFeatureClass = pFeatureLayer.FeatureClass;
                }
            }
            attList = get_FieldsString(pFeatureClass);
            foreach (string s in attList)
            {
                cbxFields.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fieldName = cbxFields.Text;
            UniqueValueRenderer(pFeatureLayer, fieldName);
            IActiveView pActiveView = pMap as IActiveView;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }
        public List<string> get_FieldsString(IFeatureClass pFeatureClass)
        {
            IFields pFields = pFeatureClass.Fields;
            IField pField;
            List<string> s = new List<string>();
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                pField = pFields.Field[i];
                if (pField.Type != esriFieldType.esriFieldTypeGeometry)
                    s.Add(pField.Name);
            }
            return s;
        }
        private void UniqueValueRenderer(IFeatureLayer pFeatureLayer, string fieldName)
        {
            IGeoFeatureLayer pGeoFeatureLayer = pFeatureLayer as IGeoFeatureLayer;
            ITable pTable = pFeatureLayer as ITable;
            int fieldNumber = pTable.FindField(fieldName);
            IUniqueValueRenderer pUniqueRenderer = new UniqueValueRendererClass();
            pUniqueRenderer.FieldCount = 1;
            pUniqueRenderer.set_Field(0, fieldName);

            //设置显示颜色的范围
            IRandomColorRamp pRandColorRamp = new RandomColorRampClass();
            pRandColorRamp.StartHue = 0;
            pRandColorRamp.MinValue = 85;
            pRandColorRamp.MinSaturation = 15;
            pRandColorRamp.EndHue = 360;
            pRandColorRamp.MaxValue = 100;
            pRandColorRamp.MaxSaturation = 30;

            //创建随机颜色带
            pRandColorRamp.Size = getUniqueValue(pFeatureLayer.FeatureClass, fieldName).Count;
            bool bSucess = false;
            pRandColorRamp.CreateRamp(out bSucess);

            IEnumColors pEnumColors = pRandColorRamp.Colors;
            IColor pNextUniqueColor = null;

            //属性唯一值
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(fieldName);
            ICursor pCursor = pFeatureLayer.FeatureClass.Search(pQueryFilter, false) as ICursor;
            IRow pNextRow = pCursor.NextRow();
            object codeValue = null;
            IRowBuffer pNextRowBuffer = null;

            IFillSymbol pFillSymbol = null;
            ILineSymbol pLineSymbol = null;
            IMarkerSymbol pMarkerSymbol = null;
            while (pNextRow != null)
            {
                pNextRowBuffer = pNextRow as IRowBuffer;
                codeValue = pNextRowBuffer.get_Value(fieldNumber);
                pNextUniqueColor = pEnumColors.Next();
                if (pNextUniqueColor == null)
                {
                    pEnumColors.Reset();
                    pNextUniqueColor = pEnumColors.Next();
                }
                switch (pGeoFeatureLayer.FeatureClass.ShapeType)
                {
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                        pMarkerSymbol = new SimpleMarkerSymbolClass();
                        pMarkerSymbol.Color = pNextUniqueColor;
                        pUniqueRenderer.AddValue(codeValue.ToString(), "", pMarkerSymbol as ISymbol);
                        pNextRow = pCursor.NextRow();
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                        pLineSymbol = new SimpleLineSymbolClass();
                        pLineSymbol.Color = pNextUniqueColor;
                        pUniqueRenderer.AddValue(codeValue.ToString(), "", pLineSymbol as ISymbol);
                        pNextRow = pCursor.NextRow();
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                        pFillSymbol = new SimpleFillSymbolClass();
                        pFillSymbol.Color = pNextUniqueColor;
                        pUniqueRenderer.AddValue(codeValue.ToString(), "", pFillSymbol as ISymbol);
                        pNextRow = pCursor.NextRow();
                        int k = pFillSymbol.Color.CMYK;
                        break;
                    default:
                        break;
                }
            }
            pGeoFeatureLayer.Renderer = pUniqueRenderer as IFeatureRenderer;

            //必须手动清除COM对象，否则会造成内存溢出（尤其是IQueryFilter,ICursor）
            Marshal.ReleaseComObject(pQueryFilter);
            Marshal.ReleaseComObject(pCursor);
            Marshal.ReleaseComObject(pEnumColors);
        }
        public static List<object> getUniqueValue(IFeatureClass pFeatureClass, string field)
        {
            string s = pFeatureClass.AliasName;
            List<object> uniqueValue = new List<object>();
            IFeatureCursor pCursor = pFeatureClass.Search(null, false);
            IDataStatistics pDataStat = new DataStatisticsClass();
            pDataStat.Field = field;
            pDataStat.Cursor = pCursor as ICursor;
            IEnumerator pEnumerator = pDataStat.UniqueValues;
            pEnumerator.Reset();
            while (pEnumerator.MoveNext())
            {
                uniqueValue.Add(pEnumerator.Current.ToString());
            }
            return uniqueValue;
        }
    }
}

