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
    public partial class changeQuestion : Form
    {
        public SqlConnection conn = null;
        public index page;
        private int userid;
        public changeQuestion(index l, int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = userid;
            this.page = l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            this.page.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("未选择密保问题", "提示");
            }
            else if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("未输入密保问题答案", "提示");
            }
            else
            {
                String sql1 = "select 密保问题,密保问题的答案 from 员工信息表 where 工号 ='" + this.userid + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd1.ExecuteReader();
                sdr.Read();
                if(sdr[0].ToString()==comboBox1.Text&& sdr[1].ToString().Trim() == textBox1.Text.Trim())
                {
                    sdr.Close();
                    changeQuestionSecond change = new changeQuestionSecond(this, this.userid);
                    this.Hide();
                    change.Show();
                }
                else
                {
                    sdr.Close();
                    MessageBox.Show("密保错误", "提示");
                }
            }
        }
        public void clear()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
        }
    }
}
