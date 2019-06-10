using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 美术馆.管理员
{
    public partial class zhanlan_main : Form
    {
        public SqlConnection conn = null;
        loginForm l = null;
        int id;
        public zhanlan_main(loginForm l,int id)
        {
            InitializeComponent();
            this.l = l;
            this.conn = l.conn;
            this.id = id;

            label2.Text = id.ToString();
        }

        //退出系统
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("成功退出系统！");
                this.Close();
                l.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        private void zhanlan_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.l.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        //安排展览
        private void button2_Click(object sender, EventArgs e)
        {
            arrange_zhanlan z = new arrange_zhanlan(this,id);
            this.Hide();
            z.Show();
        }

        //展览记录
        private void button1_Click(object sender, EventArgs e)
        {
            zhanlan_history h = new zhanlan_history(this);
            this.Hide();
            h.Show();
        }
    }
}
