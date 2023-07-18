using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020114120王晨冲
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1.获取用户
            string uname = textuser.Text.Trim();
            string upsw = textpsw.Text.Trim();

            // 2.判断是否为空
            if (string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("请输入账号", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //判空语句IsNullOrEmpty，提示窗口MessageBox
                return;
            }
            if (string.IsNullOrEmpty(upsw))
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //进行连接
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/Users/Administrator/Desktop/2020114120/login.mdb");
            con.Open();

            //创建command 查询sql
            string Access = "select * from [login] where 账号='" + this.textuser.Text + "'and 密码='" + this.textpsw.Text + "'";
            OleDbCommand cmd = new OleDbCommand(Access, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            //判断输入的用户名和密码是否和数据库用户表中的数据一致
            if (dr.Read())
            {
                uname = textuser.Text;
                upsw = textpsw.Text;
                //一旦连接成功了就弹出窗口
                MessageBox.Show("登录成功！", "登录提示", MessageBoxButtons.OK);
                this.Hide();
                MainForm form2 = new MainForm();
                form2.Show();
            }
            else
            {
                //信息错误，判断条件不成立
                MessageBox.Show("密码错误", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
  
    }
}
