using ESRI.ArcGIS.Carto;
using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;


namespace _2020114120王晨冲
{

    public partial class QureyByattribute : Form
    {
        private static IQueryFilter queryFilter = new QueryFilterClass();
        private DataTable attributeTable;
        private MainForm mainForm;
        ILayer mlayer;
        private  QureyByattribute QBAttribute;
        private static IMap currentMap;
        private static IFeatureLayer currentFeatureLayer;
        string currentFieldName;
        
        public QureyByattribute(IMap pMap)
        {
            InitializeComponent();
            currentMap = pMap;
        }

        private static  DataTable SelectAttributeTable(ILayer pLayer, string tableName)
        {
            //创建一个DataTable表
            DataTable pDataTable = new DataTable(tableName);
            //取得ITable接口
            ITable pTable = pLayer as ITable;
            IField pField = null;
            DataColumn pDataColumn;
            //根据每个字段的属性建立DataColumn对象
            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                pField = pTable.Fields.get_Field(i);
                //新建一个DataColumn并设置其属性
                pDataColumn = new DataColumn(pField.Name);
                if (pField.Name == pTable.OIDFieldName)
                {
                    pDataColumn.Unique = true;//字段值是否唯一
                }
                //字段值是否允许为空
                pDataColumn.AllowDBNull = pField.IsNullable;
                //字段别名
                pDataColumn.Caption = pField.AliasName;
                //字段数据类型
                pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                //字段默认值
                pDataColumn.DefaultValue = pField.DefaultValue;
                //当字段为String类型是设置字段长度
                if (pField.VarType == 8)
                {
                    pDataColumn.MaxLength = pField.Length;
                }
                //字段添加到表中
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }
            return pDataTable;
        }
        public static string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";
                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";
                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";
                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";
                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeOID:
                    return "System.String";
                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";
                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeString:
                    return "System.String";
                default:
                    return "System.String";
            }
        }
        private static string getShapeType(ILayer pLayer)
        {
            IFeatureLayer pFeatLyr = (IFeatureLayer)pLayer;
            switch (pFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";
                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";
                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";
                default:
                    return "";
            }
        }

        private static DataTable CreateDataTable(ILayer pLayer, string tableName)
        {
            //创建空DataTable
            DataTable pDataTable = SelectAttributeTable(pLayer, tableName);
            //取得图层类型
            string shapeType = getShapeType(pLayer);
            //创建DataTable的行对象
            DataRow pDataRow = null;
            //从ILayer查询到ITable
            ITable pTable = pLayer as ITable;
            ICursor pCursor = pTable.Search(queryFilter, false);
            //取得ITable中的行信息
            IRow pRow = pCursor.NextRow();
            int n = 0;
            while (pRow != null)
            {
                //新建DataTable的行对象
                pDataRow = pDataTable.NewRow();
                for (int i = 0; i < pRow.Fields.FieldCount; i++)
                {
                    //如果字段类型为esriFieldTypeGeometry，则根据图层类型设置字段值
                    if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        pDataRow[i] = shapeType;
                    }
                    //当图层类型为Anotation时，要素类中会有esriFieldTypeBlob类型的数据，
                    //其存储的是标注内容，如此情况需将对应的字段值设置为Element
                    else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                    {
                        pDataRow[i] = "Element";
                    }
                    else
                    {
                        pDataRow[i] = pRow.get_Value(i);
                    }
                }
                //添加DataRow到DataTable
                pDataTable.Rows.Add(pDataRow);
                pDataRow = null;
                n++;
                //为保证效率，一次只装载最多条记录
                if (n == 2000)
                {
                    pRow = null;
                }
                else
                {
                    pRow = pCursor.NextRow();
                }
            }
            return pDataTable;
        }
        AttributeQureyTable attributeTable1 = new AttributeQureyTable();
        public void CreateAttributeTable(ILayer player)
        {
            string tableName;
            tableName = getValidFeatureClassName(player.Name);
            attributeTable = CreateDataTable(player, tableName);
            attributeTable1.dataGridView1.DataSource = attributeTable;
        }

        private static string getValidFeatureClassName(string FCname)
        {
            int dot = FCname.IndexOf(".");
            if (dot != -1)
            {
                return FCname.Replace(".", "_");
            }
            return FCname;
        }

        private void SelectFeatureByAttribute()
        {
            IFeatureSelection featureSelection = currentFeatureLayer as IFeatureSelection;
            queryFilter.WhereClause = txtSelectResult.Text;
            IActiveView activeView = currentMap as IActiveView;
            switch (comBoxSelectMethod.SelectedIndex)
            {
                case 0:
                    currentMap.ClearSelection();
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
                case 1:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    break;
                case 2:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultXOR, false);
                    break;
                case 3:
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    break;
                default:
                    currentMap.ClearSelection();
                    featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
            }
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxValue.Items.Clear();
            IQueryFilter pQueryfilter = new QueryFilterClass();
            IFeatureCursor pFeatureCursor = null;

            pQueryfilter.SubFields = currentFieldName;
            pFeatureCursor = currentFeatureLayer.FeatureClass.Search(pQueryfilter, true);
            IDataStatistics pDataStati = new DataStatisticsClass();
            pDataStati.Field = currentFieldName;
            pDataStati.Cursor = (ICursor)pFeatureCursor;

            IFields fields = currentFeatureLayer.FeatureClass.Fields;
            IField field = fields.get_Field(fields.FindField(currentFieldName));

            System.Collections.IEnumerator pEnumertaor = pDataStati.UniqueValues;
            pEnumertaor.Reset();
            while (pEnumertaor.MoveNext())
            {
                if (field.Type == esriFieldType.esriFieldTypeString)
                {
                    object obj = pEnumertaor.Current;
                    listBoxValue.Items.Add("\'" + obj.ToString() + "\'");

                }
                else
                {
                    object obj = pEnumertaor.Current;
                    listBoxValue.Items.Add(obj.ToString());
                }

            }
        }
        private ILayer pLayer1;
        private void QureyByAttribute_Load(object sender, EventArgs e)
        {
            string layerName;//设置临时变量存储图层名称
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                layerName = currentMap.get_Layer(i).Name;
                comboBoxLayerName.Items.Add(layerName);
            }
            //将comboxLayerName控件的默认选项设置为第一个图层名称
            comboBoxLayerName.SelectedIndex = 0;
            //将comboxselectMethod控件的默认选项设置为第一种选择方式
            comBoxSelectMethod.SelectedIndex = 0;
        }

        private void comboBoxLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxFields.Items.Clear();
            listBoxValue.Items.Clear();
            IField field;//设置临时变量存储使用IField接口的对象
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; i < compositeLayer.Count; j++)
                    {
                        //判断图层的名称是否与comBoxLayerName控件中选择的图层名称相同
                        if (compositeLayer.get_Layer(j).Name == comboBoxLayerName.SelectedItem.ToString())
                        {
                            //如果相同则设置为整个窗体使用的IFeatureLayer接口对象
                            currentFeatureLayer = compositeLayer.get_Layer(j) as IFeatureLayer;
                            break;
                        }
                    }
                }
                else
                {
                    //判断图层的名称是否与comboxLayerName控件中选择的图层名称相同
                    if (currentMap.get_Layer(i).Name == comboBoxLayerName.SelectedItem.ToString())
                    {
                        //如果相同则设置为整个窗体所使用的IFeatureLayer接口对象
                        currentFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                        pLayer1 = currentMap.get_Layer(i);
                        break;
                    }
                }
            }
            //使用IFeatureClass接口对该图层的所有属性字段进行遍历，并填充listboxField控件
            for (int i = 0; i < currentFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                //根据索引值获取图层的字段
                field = currentFeatureLayer.FeatureClass.Fields.get_Field(i);
                //排除SHAPE字段，并在其他字段名称前后添加字符“\”
                if (field.Name.ToUpper() != "SHAPE")
                    listBoxFields.Items.Add("\"" + field.Name + "\"");
            }
            //更新labelSelectResult控件中的图层名称信息
            lableSelectResult.Text = currentFeatureLayer.Name;
            //将显示where语句的文本内容清除
            txtSelectResult.Clear();
        }

        private void listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBoxFields.SelectedItem.ToString();
            str = str.Substring(1);
            str = str.Substring(0, str.Length - 1);
            currentFieldName = str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSelectResult.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectFeatureByAttribute();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectFeatureByAttribute();
            CreateAttributeTable(pLayer1);;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtSelectResult.Text += "" + bnt_equal.Text + "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtSelectResult.Text += "" + button7.Text + "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtSelectResult.Text += "" + button8.Text + "";
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            txtSelectResult.Text += listBoxFields.SelectedItem.ToString();
        }

        private void listBoxValue_DoubleClick(object sender, EventArgs e)
        {
            txtSelectResult.Text += listBoxValue.SelectedItem.ToString();
        }

        private void txtSelectResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
