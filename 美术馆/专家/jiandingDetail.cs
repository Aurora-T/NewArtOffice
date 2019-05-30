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
    public partial class jiandingDetail : Form
    {
        public SqlConnection conn = null;
        public int userid;
        private int cid;
        public jianding page = null;
        public jiandingDetail(jianding l,int cid,int userid)
        {
            InitializeComponent();
            this.page = l;
            this.userid = userid;
            this.cid = cid;
            this.conn = l.conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price;
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("鉴定结果未选择", "提示");
            }
            else if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("鉴定价值未填写", "提示");
            }
            else if (richTextBox1.Text.Equals(""))
            {
                MessageBox.Show("鉴定备注未填写", "提示");
            }
            else if (!double.TryParse(textBox1.Text, out price))
            {
                MessageBox.Show("鉴定价值格式错误", "提示");
            }
            else
            {
                string result = "";
                if (radioButton1.Checked)
                {
                    result = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    result = radioButton2.Text;
                }
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                SqlCommand cmd1 = new SqlCommand("update 鉴定表 set 鉴定结果='" + result + "',鉴定价值='" + price + "',备注='" + richTextBox1.Text + "',鉴定时间='"+ DateTime.Now.ToString() +"' where 专家工号='" +sdr[0].ToString()+"' and 藏品编号='"+this.cid+"' and 鉴定结果 is NULL" , conn);
                sdr.Close();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                this.Close();
                this.page.Show();
                this.page.save();
            }
        }
    }
   
}
