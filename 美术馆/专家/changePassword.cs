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
    public partial class changePassword : Form
    {
        public SqlConnection conn = null;
        expert_main page;
        private int userid;
        public changePassword(expert_main l, int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = userid;
            this.page = l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            this.page.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("旧密码不可为空", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("新密码不可为空", "提示");
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("确认密码不可为空", "提示");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("新密码与确认密码不一致", "提示");
            }
            else if (textBox2.Text.Length < 6 || textBox2.Text.Length > 10)
            {
                MessageBox.Show("密码长度需为6-10位", "提示");
            }
            else
            {
                String sql1 = "select 密码 from 员工信息表 where 工号 ='" + this.userid + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd1.ExecuteReader();
                sdr.Read();
                if (sdr[0].ToString().Trim() != textBox1.Text.Trim())
                {
                    sdr.Close();
                    MessageBox.Show("旧密码错误", "提示");
                }
                else
                {
                    sdr.Close();
                    SqlCommand cmd = new SqlCommand("update 员工信息表 set 密码='" + textBox2.Text.ToString() + "' where 工号='" + this.userid + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("提交成功", "提示");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    this.Hide();
                    this.page.Show();
                }
            }
        }
    }
}
