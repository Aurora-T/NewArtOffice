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
    public partial class jiancha_details : Form
    {
        jiancha jc = null;
        SqlConnection conn = null;
        int id, jno,cno;

        private void jiancha_details_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.jc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        public jiancha_details(jiancha jc,int id,int jno)
        {
            InitializeComponent();
            this.jc = jc;
            this.conn = jc.conn;
            this.id = id;
            this.jno = jno;
            this.cno = jc.cno;
            label3.Text = this.jno.ToString();
            label5.Text = this.id.ToString();
        }

        //输入检查结果,选择下次检查时间，确定是否要维修
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0, k = 0, j = 0, m = 0;
            //输入检查结果和实际检查时间
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("检查结果不能为空");
            }
            else
            {
                string s = richTextBox1.Text.ToString().Replace(" ", "");
                string d = DateTime.Now.ToString("yyyy-MM-dd");
                string sql1 = "update 检查表 set 检查结果='" + s + "'  where 检查记录编号='" + jno + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                i = cmd1.ExecuteNonQuery();
                string sql2 = "update 检查表 set 实际检查时间='" + d + "'  where 检查记录编号='" + jno + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                k = cmd2.ExecuteNonQuery();
            }
            //确定下次检查时间，插入一条新记录，包括藏品编号和应该检查时间
            string d1 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString());
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            if (month.Length == 1)
                month = "0" + month;
            string day = date.Day.ToString();
            if (day.Length == 1)
                day = "0" + day;
            string time = year + "-" + month + "-" + day;
            if (string.Compare(time,d1)==1)
            {
                string sql = "Insert Into 检查表(藏品编号,应该检查时间) Values (@cno,@time)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@cno", SqlDbType.Int);
                sp.Value = this.cno;
                sp = cmd.Parameters.Add("@time", SqlDbType.Char);
                sp.Value = time;
                j = cmd.ExecuteNonQuery();
            }
            else
                MessageBox.Show("所选时间应晚于今天");
            //确定是否需要修复
            if (radioButton1.Checked)
            {
                string sql2 = "Insert Into 修复表(藏品编号) Values (@cno)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                SqlParameter sp2 = cmd2.Parameters.Add("@cno", SqlDbType.Int);
                sp2.Value = this.cno;
                m = cmd2.ExecuteNonQuery();
                label6.Text = "是";
            }
            else
                m = -1;

            if (i > 0 && k > 0 && j > 0 && m > 0 || m == -1)
                MessageBox.Show("检查成功");
            else
            {
                MessageBox.Show("未成功");
            }
        }
    }
}
