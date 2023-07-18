using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace _2020114120王晨冲
{
    public partial class spin : Form
    {
        public spin()
        {
            InitializeComponent();
        }
        double angle = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
             angle = angle + Convert.ToDouble(textBox1.Text);
            if (angle < 0 )
                textBox1.Text = "请重新输入正确角度（0-360）";
            else {
                double dRotationAngle = angle; //获取旋转的角度
                MainForm.mainForm.Spin(angle);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void spin_Load(object sender, EventArgs e)
        {

        }
    }
}
