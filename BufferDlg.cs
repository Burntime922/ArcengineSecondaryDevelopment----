using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;

namespace _2020114120王晨冲
{
    public partial class BufferDlg : Form
    {
        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr wnd,uint Msg,IntPtr wParam,IntPtr lParam);
        private IMapControl4 MapControl;
        private IHookHelper m_hookHelper = null;
        private const uint WM_VSCROLL = 0x0115;
        private const uint SB_BOTTOM = 7;
        public BufferDlg(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
            MapControl = m_hookHelper as IMapControl4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BufferDlg_Load(object sender, EventArgs e)
        {
            if (null == m_hookHelper || null == m_hookHelper.Hook || 0 == m_hookHelper.FocusMap.LayerCount)
                return;
            //加载地图中所有要素到combo
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                cboLayers.Items.Add(layer.Name);
            }
            //默认选择第一个图层
            if (cboLayers.Items.Count > 0)
                cboLayers.SelectedIndex = 0;
            string tempDir = System.IO.Path.GetTempPath();
            txtOutputPath.Text = System.IO.Path.Combine(tempDir, ((string)cboLayers.SelectedItem + "_buffer.shp"));
            //设置默认的缓冲单位 
            int units = Convert.ToInt32(m_hookHelper.FocusMap.MapUnits);
            cboUnits.SelectedIndex = units;
        }

        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";
            IEnumLayer layers = m_hookHelper.FocusMap.get_Layers(uid, true);

            return layers;
        }

        private void ScrollToBottom()
        {
            PostMessage((IntPtr)txtMessages.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, (IntPtr)IntPtr.Zero);
        }

        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }

            return null;
        }

        private void btnOutputLayer_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile (*.shp)|*.shp";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "Output Layer";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = (string)cboLayers.SelectedItem + "_buffer.shp";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputPath.Text = saveDlg.FileName;
        }

        private string ReturnMessages(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private void btnBuffer_Click(object sender, EventArgs e)
        {
            double bufferDistance;
            //将输入距离的字符型转换为double类型
            double.TryParse(txtBufferDistance.Text, out bufferDistance);
            if (0.0 == bufferDistance)
            {
                MessageBox.Show("缓冲距离有错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //判断输出路径是否合法
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtOutputPath.Text)) ||
              ".shp" != System.IO.Path.GetExtension(txtOutputPath.Text))
            {
                MessageBox.Show("输出路径有问题！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            //判断图层个数
            if (m_hookHelper.FocusMap.LayerCount == 0)
                return;

            //从地图中获取图层
            IFeatureLayer layer = GetFeatureLayer((string)cboLayers.SelectedItem);
            if (null == layer)
            {
                txtMessages.Text += "Layer " + (string)cboLayers.SelectedItem + "找不到!\r\n";
                return;
            }

            //文本框拖到底部
            ScrollToBottom();
            //消息框中添加消息
            txtMessages.Text += "缓冲图层: " + layer.Name + "\r\n";

            txtMessages.Text += "\r\n正在获取地学处理器，请稍等...\r\n";
            txtMessages.Text += DateTime.Now.ToString() + "\r\n";
            txtMessages.Update();
            //获得地学处理器的一个实例
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            txtMessages.Text += "开始进行缓冲区分析...\r\n";
            txtMessages.Update();

            //创建缓冲区工具的一个实例
            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(layer, txtOutputPath.Text, Convert.ToString(bufferDistance) + " " + (string)cboUnits.SelectedItem);

            //执行缓冲区分析
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(buffer, null);
            if (results.Status != esriJobStatus.esriJobSucceeded)
            {
                txtMessages.Text += "图层缓冲失败: " + layer.Name + "\r\n";
            }
            txtMessages.Text += ReturnMessages(gp);
            //scroll the textbox to the bottom
            ScrollToBottom();

            txtMessages.Text += "\r\n完成.\r\n";
            txtMessages.Text += "-----------------------------------------------------------------------------------------\r\n";
            //scroll the textbox to the bottom
            ScrollToBottom();
        }
    }
}
