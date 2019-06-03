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
    public partial class changeQuestionSecond : Form
    {
        public SqlConnection conn = null;
        changeQuestion page;
        private int userid;
        public changeQuestionSecond(changeQuestion page,int userid)
        {
            InitializeComponent();
            this.conn = page.conn;
            this.userid = userid;
            this.page = page;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("未选择新密保问题", "提示");
            }
            else if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("未输入密保问题答案", "提示");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update 员工信息表 set 密保问题='" + comboBox1.Text.ToString() + "',密保问题的答案='" + textBox1.Text + "' where 工号='" + this.userid + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                textBox1.Text = "";
                this.Hide();
                this.page.clear();
                this.page.page.Show();

            }
        }
    }
}
