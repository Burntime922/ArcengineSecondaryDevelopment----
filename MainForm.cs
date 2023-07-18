using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;


namespace _2020114120王晨冲
{
    public sealed partial class MainForm : Form
    {
        public static MainForm mainForm;
        #region class private members
        private IMapControl3 m_mapControl;
        private IToolbarMenu m_menuMap = new ToolbarMenuClass();
        private IToolbarMenu m_menuLayer = new ToolbarMenuClass();
        private ITOCControl2 m_tocControl = new TOCControlClass();
        private string m_mapDocumentName = string.Empty;
        public ILayer layer = null;


        //定义声明变量
        IPoint pMoveRectPoint;
        bool bCanDrag;
        IEnvelope pEnv;


        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }
        #endregion

        public void OpenEagelEyeForm()
        {
            axMapControl2.Visible = true;
        }
        public void Spin(double angle)
        {
            double dRotationAngle = angle; //获取旋转的角度
            //赋值给 axMapControl1.Rotation，实现地图旋转
            axMapControl1.Rotation = dRotationAngle;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null); //局部刷新
        }

        private void CopyToPageLayout()
        {
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            object copyFromMap = axMapControl1.Map;
            object copiedMap = pObjectCopy.Copy(copyFromMap);//复制地图到copiedMap中
            object copyToMap = axMapControl2.ActiveView.FocusMap;
            pObjectCopy.Overwrite(copiedMap, ref copyToMap); //复制地图
            axMapControl2.ActiveView.Refresh();
        }
        #region 各类专题图均用的函数
        /// <summary>
        /// 获得颜色的函数
        /// </summary>
        /// <param name="r">红色Red</param>
        /// <param name="g">绿色Green</param>
        /// <param name="b">蓝色Blue</param>
        /// <returns>返回颜色</returns>
        /// <summary>
        /// 获取渲染图层
        /// </summary>
        /// <param name="layerName">图层名字</param>
        /// <returns>图层</returns>
        private IGeoFeatureLayer getGeoLayer(string layerName)
        {
            ILayer pLayer; //定义图层
            IGeoFeatureLayer pGeoFeatureLayer; //定义要素图层  Geo？
                                               //遍历图层
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                pLayer = axMapControl1.get_Layer(i);
                //若当前图层不为空且与与layerName的值相同
                if (pLayer != null && pLayer.Name == layerName)
                {
                    //强转成IGeoFeatureLayer
                    pGeoFeatureLayer = pLayer as IGeoFeatureLayer;
                    //返回pGeoFeatureLayer对象
                    return pGeoFeatureLayer;
                }
            }
            return null; //返回null
        }
        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
        #endregion

        //定义用于获取颜色的GetRgbColor方法
        private IRgbColor GetRgbColor(int intR, int intG, int intB)
        {
            IRgbColor pRgbColor = null;
            if (intR < 0 || intR > 255 || intG < 0 || intG > 255 || intB < 0 || intB > 255)
            {
                return pRgbColor;
            }
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = intR;
            pRgbColor.Green = intG;
            pRgbColor.Blue = intB;
            return pRgbColor;
        }

        //在鹰眼地图上面画矩形框
        private void DrawRectangle(IEnvelope pEnvelope)
        {
            //在绘制前，清除鹰眼中之前绘制的矩形框
            IGraphicsContainer pGraphicsContainer = axMapControl1.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            //得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            //设置矩形框（实质为中间透明度面）
            IRgbColor pColor = new RgbColorClass();
            pColor = GetRgbColor(255, 0, 0);
            pColor.Transparency = 255;
            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 2;
            pOutLine.Color = pColor;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            //向鹰眼中添加矩形框
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            //刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            pGraphicsContainer.DeleteAllElements();
        }

        private void zoomIn()
        {
            IEnvelope pEnv = axMapControl1.TrackRectangle();
            pEnv = axMapControl1.Extent;
            pEnv.Expand(0.5, 0.5, true);
            axMapControl1.Extent = pEnv;
        }

        private void zoomOut()
        {
            IEnvelope pEnv = axMapControl1.TrackRectangle();
            pEnv = axMapControl1.Extent;
            pEnv.Expand(2, 2, true);
            axMapControl1.Extent = pEnv;
        }
        private void SynchronizeEagleEye()
        {
            if (axMapControl2.LayerCount > 0)
            {
                axMapControl2.ClearLayers();
            }
            //设置鹰眼和主地图的坐标系统一致
            axMapControl2.SpatialReference = axMapControl1.SpatialReference;
            for (int i = axMapControl1.LayerCount - 1; i >= 0; i--)
            {
                //使鹰眼视图与数据视图的图层上下顺序保持一致
                ILayer pLayer = axMapControl1.get_Layer(i);
                if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                {
                    ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                    for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                    {
                        ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                        IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            //由于鹰眼地图较小，所以过滤点图层不添加
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                                && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                            {
                                axMapControl2.AddLayer(pLayer);
                            }
                        }
                    }
                }
                else
                {
                    IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    if (pFeatureLayer != null)
                    {
                        if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                            && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                        {
                            axMapControl2.AddLayer(pLayer);
                        }
                    }
                }
                //设置鹰眼地图全图显示  
                axMapControl2.Extent = axMapControl1.FullExtent;
                pEnv = axMapControl1.Extent as IEnvelope;
                DrawRectangle(pEnv);
                axMapControl2.ActiveView.Refresh();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            axMapControl1.Map.Name = "图层";
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            m_tocControl = (ITOCControl2)axTOCControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
            axToolbarControl1.AddItem(new buffer(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconAndText);

            //将标签当成按钮添加到工具条
            this.axToolbarControl1.AddItem(new openmap(), -1, 1, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new addLayer(), -1, 3, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new save(), -1, 5, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new blowup(), -1, 7, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new smaller(), -1, 9, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new pull(), -1, 11, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new fullmap(), -1, 13, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            this.axToolbarControl1.AddItem(new measure(), -1, 15, false, -1, esriCommandStyles.esriCommandStyleTextOnly);
            //将鹰眼添加到工具条
            this.axToolbarControl1.AddItem(new eagleeye(), -1, 16, false, -1, esriCommandStyles.esriCommandStyleIconAndText);
            
            m_menuLayer.SetHook(m_mapControl);
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();

            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }


        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            this.axMapControl1.MapUnits = ESRI.ArcGIS.esriSystem.esriUnits.esriMeters;
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
            IPoint pPoint = new ESRI.ArcGIS.Geometry.Point();
            pPoint.PutCoords(e.mapX, e.mapY);
            axMapControl1.ActiveView.ScreenDisplay.RotateMoveTo(pPoint);    //旋转到鼠标的位置
            axMapControl1.ActiveView.ScreenDisplay.RotateTimer(); //可以忽略
            toolStripStatusLabel1.Text = "   1:" + ((long)axMapControl1.MapScale).ToString() + "  ";
        }

        private void axToolbarControl1_OnMouseDown(object sender, IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = new MapClass();

            object other = new object();
            object index = new object();

            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            //弹出右键菜单
            if (e.button != 2) return;

            if (item == esriTOCControlItem.esriTOCControlItemMap)
                m_tocControl.SelectItem(map, null);
            else m_tocControl.SelectItem(layer, null);
            m_mapControl.CustomProperty = layer;
            if (item == esriTOCControlItem.esriTOCControlItemLayer)
            {
                //动态添加OpenAttributeTable菜单项
                m_menuLayer.AddItem(new OpenAttributeTable(layer), -1, 0, true, esriCommandStyles.esriCommandStyleTextOnly);
                m_menuLayer.AddItem(new ZoomToLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
                m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);
                //移除OpenAttributeTable菜单项，以防止重复添加
                m_menuLayer.Remove(0);
                m_menuLayer.Remove(0);

            }


        }


        private int select = 0;
        private int spinjudge = 0;
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            ITopologicalOperator pTopo;
            IGeometry pGeometry;
            IFeature pFeature;
            IFeatureLayer pFeatureLayer;
            IFeatureCursor pCursor;
            ISpatialFilter pFilter;
            DataTable dataTable;
            IPoint pPoint;
            if(axToolbarControl2.Visible==false)
            { 
            for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
            {
                int isOpenOrClose = 0;
                pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                pTopo = pPoint as ITopologicalOperator;
                double m_Radius = 1;
                pGeometry = pTopo.Buffer(m_Radius);
                if (pGeometry == null)
                    continue;
                axMapControl1.Map.SelectByShape(pGeometry, null, true);//第三个参数为是否只选中一个
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null); //选中要素高亮显示
                pFilter = new SpatialFilterClass();
                pFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                pFilter.Geometry = pGeometry;
                pFeatureLayer = axMapControl1.Map.get_Layer(i) as IFeatureLayer;
                pCursor = pFeatureLayer.Search(pFilter, false);
                pFeature = pCursor.NextFeature();
                string fieldName;
                FeatureAttribute f = new FeatureAttribute();
                if (pFeature != null)
                {
                    if (Application.OpenForms["FeatureAttribute"] == null)
                    {
                        f.Show();
                        isOpenOrClose++;
                    }
                    else
                    {
                        if (isOpenOrClose >= 1)//这里主要控制子窗体不会重复弹出
                        {
                            Application.OpenForms["FeatureAttribute"].Dispose();
                        }
                        f.Show();
                    }
                    DataRow datarow;
                    dataTable = new DataTable();
                    for (int k = 0; k < 2; k++)
                    {
                        if (k == 0)
                        {
                            dataTable.Columns.Add("属性");
                        }
                        if (k == 1)
                        {
                            dataTable.Columns.Add("值");
                        }
                    }
                    for (int j = 0; j < pFeature.Fields.FieldCount; j++)
                    {
                        datarow = dataTable.NewRow();
                        for (int m = 0; m < 2; m++)
                        {
                            if (m == 0)
                            {
                                fieldName = pFeature.Fields.get_Field(j).Name;
                                datarow[m] = fieldName;
                            }
                            if (m == 1)
                            {
                                if (pFeature.Fields.get_Field(j).Name == "Shape")
                                {
                                    if (pFeature.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
                                    {
                                        datarow[m] = "点";
                                    }
                                    if (pFeature.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline)
                                    {
                                        datarow[m] = "线";
                                    }
                                    if (pFeature.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon)
                                    {
                                        datarow[m] = "面";
                                    }
                                }
                                else
                                {
                                    datarow[m] = pFeature.get_Value(j).ToString();
                                }
                            }
                        }
                        dataTable.Rows.Add(datarow);
                    }
                    f.dataGridView1.DataSource = dataTable;
                    f.textBox1.Text = pFeatureLayer.Name;
                    f.dataGridView1.Refresh();
                    pFeature = null;
                    break;

                }



                if (spinjudge == 1)
                {
                    IPoint mPoint = new ESRI.ArcGIS.Geometry.Point();
                    mPoint.PutCoords(e.mapX, e.mapY);//获取当前鼠标通过点击输入的位置
                    IPoint pCentrePoint = new ESRI.ArcGIS.Geometry.Point();
                    pCentrePoint.PutCoords(axMapControl1.Extent.XMin + axMapControl1.ActiveView.Extent.Width / 2,
                    axMapControl1.Extent.YMax - axMapControl1.ActiveView.Extent.Height / 2); //获取图像的中心位置
                    axMapControl1.ActiveView.ScreenDisplay.RotateStart(mPoint, pCentrePoint); //开始旋转
                    spinjudge = 0;
                }

                IGeometry pGeom = null;
                if (select != 0)
                {
                    switch (select)
                    {
                        case 1:
                            pGeom = axMapControl1.TrackLine(); break;
                        case 2:
                            pGeom = axMapControl1.TrackRectangle(); break;
                        case 3:
                            pGeom = axMapControl1.TrackCircle(); break;
                        case 4:
                            pGeom = axMapControl1.TrackPolygon(); break;
                    }
                    axMapControl1.Map.SelectByShape(pGeom, null, false);
                    axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                    axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null); //选中要素高亮显示
                    select = 0;
                }


            }
        }
    }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (axMapControl2.Map.LayerCount > 0)
            {
                //按下鼠标左键移动矩形框
                if (e.button == 1)
                {
                    //如果指针落在鹰眼的矩形框中，标记可移动
                    if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
                    {
                        bCanDrag = true;
                    }
                    pMoveRectPoint = new PointClass();
                    pMoveRectPoint.PutCoords(e.mapX, e.mapY);  //记录点击的第一个点的坐标
                }
                //按下鼠标右键绘制矩形框
                else if (e.button == 2)
                {
                    IEnvelope pEnvelope = axMapControl2.TrackRectangle();

                    IPoint pTempPoint = new PointClass();
                    pTempPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);
                    axMapControl1.Extent = pEnvelope;
                    //矩形框的高宽和数据试图的高宽不一定成正比，这里做一个中心调整
                    axMapControl1.CenterAt(pTempPoint);
                }
            }
        }


        private void axMapControl2_OnMouseMove_1(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
            {
                //如果鼠标移动到矩形框中，鼠标换成小手，表示可以拖动
                axMapControl2.MousePointer = esriControlsMousePointer.esriPointerHand;
                if (e.button == 2)  //如果在内部按下鼠标右键，将鼠标演示设置为默认样式
                {
                    axMapControl2.MousePointer = esriControlsMousePointer.esriPointerDefault;
                }
            }
            else
            {
                //在其他位置将鼠标设为默认的样式
                axMapControl2.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }

            if (bCanDrag)
            {
                double Dx, Dy;  //记录鼠标移动的距离
                Dx = e.mapX - pMoveRectPoint.X;
                Dy = e.mapY - pMoveRectPoint.Y;
                pEnv.Offset(Dx, Dy); //根据偏移量更改 pEnv 位置
                pMoveRectPoint.PutCoords(e.mapX, e.mapY);
                DrawRectangle(pEnv);
                axMapControl1.Extent = pEnv;
            }
        }

        private void axMapControl1_OnExtentUpdated_1(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //得到当前视图范围
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        private void axMapControl2_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1 && pMoveRectPoint != null)
            {
                if (e.mapX == pMoveRectPoint.X && e.mapY == pMoveRectPoint.Y)
                {
                    axMapControl1.CenterAt(pMoveRectPoint);
                }
                bCanDrag = false;
            }
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView pActiveView = (IActiveView)axMapControl2.ActiveView.FocusMap;
            IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
            displayTransformation.VisibleBounds = axMapControl1.Extent;
            axMapControl2.ActiveView.Refresh();
            CopyToPageLayout();
            
        }

        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            double dRotationAngle = axMapControl1.ActiveView.ScreenDisplay.RotateStop(); //获取旋转的角度
            //赋值给 axMapControl1.Rotation，实现地图旋转
            axMapControl1.Rotation = dRotationAngle;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null); //局部刷新
        }

        private void 旋转ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new spin().Show();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 点选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void 线选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select = 1;
        }

        private void 框选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select = 2;
        }

        private void 圆选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select = 3;
        }

        private void 多边形选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select = 4;
        }

        private void 自由旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spinjudge = 1;
        }

        private void 按属性查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new QureyByattribute(axMapControl1.Map).Show();
        }

        private void 缓冲区分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 要素编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 开始编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axToolbarControl2.Visible = true;
        }

        private void 停止编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axToolbarControl2.Visible = false;
        }



        private void 图层渲染器ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new UniqueValue(axMapControl1.Map).Show();
        }

        login Login = new login();

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}