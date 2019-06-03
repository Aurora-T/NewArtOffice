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
    public partial class forgetPassword : Form
    {
        public SqlConnection conn = null;
        public loginForm page;
        public forgetPassword(loginForm l)
        {
            InitializeComponent();
            this.page = l;
            this.conn = l.conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入账号信息", "提示");
            }
            else if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("请选择密保问题", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请输入密保问题答案", "提示");
            }
            else
            {
                int id = Int32.Parse(textBox1.Text.ToString());
                string sql = "SELECT 工号,密保问题,密保问题的答案 from 员工信息表 where 工号='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                if (sdr.Read())         //从结果中找到
                {
                    if (sdr[0].ToString().Trim() == textBox1.Text.Trim() && sdr[1].ToString().Trim() == comboBox1.Text.Trim() && sdr[2].ToString().Trim() == textBox2.Text.Trim())
                    {
                        sdr.Close();
                        modifyPassword mp = new modifyPassword(this, id);
                        mp.Show();
                        this.Hide();
                    }
                    else
                    {
                        sdr.Close();
                        MessageBox.Show("密保错误", "提示");
                    }
                }
                else
                {
                    sdr.Close();
                    MessageBox.Show("用户名不存在", "提示");
                }
            }
        }
        public void returnBack()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
