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

namespace 美术馆.专家
{
    public partial class expert_main : Form
    {
        public SqlConnection conn = null;
        public int id;
        public loginForm l = null;
        public expert_main(loginForm l,int id)
        {
            this.l = l;
            this.id = id;
            this.conn = l.conn;
            InitializeComponent();
        }

        //点击退出后断开数据库连接，直接退出系统
        private void button6_Click(object sender, EventArgs e)
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

        //点击叉号退回登录界面
        private void index_FormClosed(object sender, FormClosedEventArgs e)
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

        //鉴定藏品
        private void button1_Click(object sender, EventArgs e)
        {

        }
        //检查藏品
        private void button2_Click(object sender, EventArgs e)
        {
            jiancha j = new jiancha(this);
            this.Hide();
            j.Show();
        }
        //修复藏品
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
