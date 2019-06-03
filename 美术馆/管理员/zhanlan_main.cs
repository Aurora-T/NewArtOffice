using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 美术馆.管理员
{
    public partial class zhanlan_main : Form
    {
        public SqlConnection conn = null;
        loginForm l = null;
        public int id;
        public zhanlan_main(loginForm l,int id)
        {
            InitializeComponent();
            this.l = l;
            this.conn = l.conn;
            this.id = id;
            label2.Text = id.ToString();
            
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

       

        //退出系统
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                l.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        //安排展览
        private void button1_Click(object sender, EventArgs e)
        {
            arrange_zhanlan zhanlan = new arrange_zhanlan(this);
            this.Hide();
            zhanlan.Show();
        }


        //查看展览记录
        private void button3_Click_1(object sender, EventArgs e)
        {
            zhanlan_history f = new zhanlan_history(this);
            this.Hide();
            f.Show();
        }
    }
}
