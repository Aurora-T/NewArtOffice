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
        int id, jno, cno;
      
        public jiancha_details(jiancha jc,int id,int jno)
        {
            InitializeComponent();
            this.jc = jc;
            this.conn = jc.conn;
            this.id = id;//工号
            this.jno = jno;
            this.cno = jc.cno;

            //查询专家编号
            string sql = "SELECT 专家编号 FROM 专家表 where 工号='"+id+"'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            label3.Text = this.jno.ToString();
            label5.Text = sdr[0].ToString();
            sdr.Close();
        }

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


        //输入检查结果,选择下次检查时间，确定是否要维修
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            //输入检查结果和实际检查时间
            if (richTextBox1.Text == "")
                MessageBox.Show("检查结果不能为空");
            else
                i = 1;
            //确定下次检查时间，插入一条新记录，包括藏品编号和应该检查时间
            string d1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime date = DateTime.Parse(dateTimePicker2.Value.ToString());
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            if (month.Length == 1)
                month = "0" + month;
            string day = date.Day.ToString();
            if (day.Length == 1)
                day = "0" + day;
            string time = year + "-" + month + "-" + day;
            if (string.Compare(time, d1) == 1)
                j = 1;
            else
                MessageBox.Show("所选时间应晚于今天");
           
            if (i == 1 && j == 1)
            {
                //输入检查结果和检查结束时间
                string s = richTextBox1.Text.ToString().Replace(" ", "");
                string sql1 = "update 检查表 set 检查结果='" + s + "'  where 检查记录编号='" + jno + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                string sql2 = "update 检查表 set 检查结束时间='" + d1 + "'  where 检查记录编号='" + jno + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                //确定下次检查时间，插入一条新记录，包括藏品编号和应该检查时间
                string sql = "Insert Into 检查表(藏品编号,应该检查时间) Values (@cno,@time)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@cno", SqlDbType.Int);
                sp.Value = this.cno;
                sp = cmd.Parameters.Add("@time", SqlDbType.Char);
                sp.Value = time;
                cmd.ExecuteNonQuery();

                //确定是否需要修复
                if (radioButton1.Checked)
                {
                    //插入修复记录
                    string sql3 = "Insert Into 修复表(藏品编号,开始时间) Values (@cno,@time)";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    SqlParameter sp3 = cmd3.Parameters.Add("@cno", SqlDbType.Int);
                    sp3.Value = this.cno;
                    sp3 = cmd3.Parameters.Add("@time", SqlDbType.Char);
                    sp3.Value = d1;
                    cmd3.ExecuteNonQuery();
                }
                MessageBox.Show("检查成功");
            }
           
        }
    }
}
