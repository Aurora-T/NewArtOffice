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
    public partial class changeInformation : Form
    {
        public SqlConnection conn = null;
        index page;
        private int userid;
        public changeInformation(index l, int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = userid;
            this.page = l;
            String sql = "select 姓名,性别,身份证号,职位,联系方式 from 员工信息表 where 工号 ='" + this.userid + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            label2.Text = userid.ToString();
            label8.Text = sdr[0].ToString();
            label9.Text = sdr[1].ToString();
            label10.Text = sdr[2].ToString();
            label11.Text = sdr[3].ToString();
            textBox1.Text = sdr[4].ToString();
            sdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.page.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("联系电话不可为空", "提示");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[1]+[3,5,7,8]+\d{9}"))
            {
                MessageBox.Show("联系电话格式错误", "提示");
            }
            else
            {
    
                    SqlCommand cmd = new SqlCommand("update 员工信息表 set 联系方式='" + textBox1.Text + "' where 工号='" + this.userid + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("提交成功", "提示");
                    textBox1.Text = "";
                    this.Hide();
                    this.page.Show();
                }
            }
        }
}
