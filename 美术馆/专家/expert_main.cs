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
            label4.Text = id.ToString();
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
            jianding jianding = new jianding(this, this.id);
            this.Hide();
            jianding.Show();
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
            xiufu j = new xiufu(this);
            this.Hide();
            j.Show();
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeInformation change = new changeInformation(this, this.id);
            this.Hide();
            change.Show();
        }

        private void 修改密保问题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeQuestion change = new changeQuestion(this, this.id);
            this.Hide();
            change.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePassword change = new changePassword(this, this.id);
            this.Hide();
            change.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
