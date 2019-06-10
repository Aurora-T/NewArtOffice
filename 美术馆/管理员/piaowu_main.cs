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
    public partial class piaowu_main : Form
    {
        public int id;
        loginForm l = null;
        public SqlConnection conn = null;
        public piaowu_main(loginForm l,int id)
        {
            InitializeComponent();
            this.l = l;
            this.id = id;
            this.conn = l.conn;
            label2.Text = id.ToString();

            
        }
    

        //点击叉号后关闭界面，退回到主界面
        void administrator_FormClosed(object sender, FormClosedEventArgs e)
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

        //设置放票数
        private void button1_Click(object sender, EventArgs e)
        {
            piao_amount amount = new piao_amount(this);
            this.Hide();
            amount.Show();
        }

        //查看预约记录
        private void button2_Click(object sender, EventArgs e)
        {
            yuyue_record yuyue = new yuyue_record(this);
            this.Hide();
            yuyue.Show();
        }

        //查看取票记录
        private void button3_Click(object sender, EventArgs e)
        {
            qupiao_record qupiao = new qupiao_record(this);
            this.Hide();
            qupiao.Show();
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
    }
}
