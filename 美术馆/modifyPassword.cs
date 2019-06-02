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

namespace 美术馆
{
    public partial class modifyPassword : Form
    {
        public SqlConnection conn = null;
        forgetPassword page;
        private int userid;
        public modifyPassword(forgetPassword l,int userid)
        {
            InitializeComponent();
            this.page = l;
            this.conn = l.conn;
            this.userid = userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            this.Hide();
            this.page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("密码不可为空", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("确认密码不可为空", "提示");
            }
            else if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("密码与确认密码不一致", "提示");
            }
            else if (textBox1.Text.Length < 6|| textBox1.Text.Length > 16)
            {
                MessageBox.Show("密码长度需为6-16位", "提示");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update 员工信息表 set 密码='"+textBox1.Text+"' where 工号='"+this.userid+"'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                textBox1.Text = "";
                textBox2.Text = "";
                this.Hide();
                this.page.returnBack();
                this.page.page.Show();
            }
        }
    }
}
