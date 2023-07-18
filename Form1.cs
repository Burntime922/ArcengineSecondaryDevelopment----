using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace _2020114120王晨冲
{
    public partial class AttributeTable1 : Form
    {
		/// <summary>
		/// 根据图层字段创建一个只含字段的空DataTable
		/// </summary>
		/// <param name="pLayer"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static  AttributeTable1 attribute;
		public DataTable attributeTable;
		private MainForm mainForm;
		ILayer mlayer; 
		public AttributeTable1(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm= mainForm;
			mlayer = mainForm.layer;

		}

		public static void ZoomToFeatureLayerSelection(IFeature pFeat)
		{
			IMapControlDefault mapcontroldefault = (MainForm.mainForm.axMapControl1.Object as IMapControl2) as IMapControlDefault;
			IGeometry geometry = pFeat.Shape;
			IEnvelope pEnv = null;
			pEnv = geometry.Envelope;
			if (geometry.GeometryType != esriGeometryType.esriGeometryPoint)
			{
				pEnv.Expand(1.5, 1.5, true);
			}
			else
			{
				pEnv.Expand(5, 5, false);
			}
			mapcontroldefault.Extent = pEnv;

			mapcontroldefault.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);


		}
		public static DataTable CreateDataTableByLayer(ILayer pLayer, string tableName)
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

		/// <summary>
		/// 将GeoDatabase字段类型转换成.Net相应的数据类型
		/// </summary>
		/// <param name="fieldType">字段类型</param>
		/// <returns></returns>
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

		/// <summary>
		/// 获得图层的Shape类型
		/// </summary>
		/// <param name="pLayer">图层</param>
		/// <returns></returns>
		public static string getShapeType(ILayer pLayer)
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
		/// <summary>
		/// 填充DataTable中的数据
		/// </summary>
		/// <param name="pLayer"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static DataTable CreateDataTable(ILayer pLayer, string tableName)
		{
			//创建空DataTable
			DataTable pDataTable = CreateDataTableByLayer(pLayer, tableName);
			//取得图层类型
			string shapeType = getShapeType(pLayer);
			//创建DataTable的行对象
			DataRow pDataRow = null;
			//从ILayer查询到ITable
			ITable pTable = pLayer as ITable;
			ICursor pCursor = pTable.Search(null, false);
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
		/// <summary>
		/// 绑定DataTable到DataGridView
		/// </summary>
		/// <param name="player"></param>
		public void CreateAttributeTable(ILayer player)
		{
			string tableName;
			tableName = getValidFeatureClassName(player.Name);
			attributeTable = CreateDataTable(player, tableName);
			this.dataGridView1.DataSource = attributeTable;
			this.Text = "属性表[" + tableName + "]  " + "记录数：" + attributeTable.Rows.Count.ToString();
		}
		//因为DataTable的表名不允许含有“.”，因此我们用“_”替换。函数如下：
		/// <summary>
		/// 替换数据表名中的点
		/// </summary>
		/// <param name="FCname"></param>
		/// <returns></returns>
		public static string getValidFeatureClassName(string FCname)
		{
			int dot = FCname.IndexOf(".");
			if (dot != -1)
			{
				return FCname.Replace(".", "_");
			}
			return FCname;
		}
		public AttributeTable1()
        {
            InitializeComponent();
        }

        private void AttributeTable1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
		private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
			IQueryFilter pQuery = new QueryFilterClass();
			int count = this.dataGridView1.SelectedRows.Count;
			string val, col;
			col = this.dataGridView1.Columns[0].Name;
			//当只选中一行时
			if (count == 1)
			{
				val = this.dataGridView1.SelectedRows[0].Cells[col].Value.ToString();
				//设置高亮要素的查询条件
				pQuery.WhereClause = col + "=" + val;
			}
			else//选中多行
			{
				int i;
				string str;
				for (i = 0; i < count - 1; i++)
				{
					val = this.dataGridView1.SelectedRows[i].Cells[col].Value.ToString();
					str = col + "=" + val + "OR";
					pQuery.WhereClause += str;
				}
				//添加最后一个要素的条件
				val = this.dataGridView1.SelectedRows[i].Cells[col].Value.ToString();
				str = col + "=" + val;
				pQuery.WhereClause += str;

			}
			IFeatureLayer pFLayer = mlayer as IFeatureLayer;
			IFeatureClass pFeatCls = pFLayer.FeatureClass;
			IFeature pFeat = null;
			if (count == 1)
			{
				//ILayer pLayer = (ILayer)m_mapControl.CustomProperty;

				IFeatureCursor pFeatCur = pFeatCls.Search(pQuery, false);
				pFeat = pFeatCur.NextFeature();
				ZoomToFeatureLayerSelection(pFeat);
			}
			if (pFeat != null)
			{
				IArray geoArray = new ArrayClass();
				geoArray.Add(pFeat.ShapeCopy);
				//通过IHookActions闪烁要素集合 
				HookHelperClass m_pHookHelper = new HookHelperClass();
				m_pHookHelper.Hook = MainForm.mainForm.axMapControl1.Object;
				IHookActions hookActions = (IHookActions)m_pHookHelper;

				hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsPan);
				//hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsGraphic);
				//hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsZoom);
				//hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsCallout); 
				Application.DoEvents();
				m_pHookHelper.ActiveView.ScreenDisplay.UpdateWindow();
				hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsFlash);
			}

				IFeatureSelection pFeatSelection;
				pFeatSelection = pFLayer as IFeatureSelection;
			if (count == 1)
			{
				pFeatSelection.SelectFeatures(pQuery, esriSelectionResultEnum.esriSelectionResultNew, false);
				IViewRefresh viewRefresh = mainForm.axMapControl1.Map as IViewRefresh;
				viewRefresh.ProgressiveDrawing = true;
				viewRefresh.RefreshItem(mlayer);
			}

		}
    }
}
