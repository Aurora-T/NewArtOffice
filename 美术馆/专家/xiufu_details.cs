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
    public partial class xiufu_details : Form
    {
        xiufu x = null;
        SqlConnection conn = null;
        int xno, id;
        public xiufu_details(xiufu x,int xno)
        {
            InitializeComponent();
            this.x = x;
            this.conn = x.conn;
            this.xno = xno;
            this.id = x.id;
            label3.Text = xno.ToString();
            //查询专家编号
            string sql = "SELECT 专家编号 FROM 专家表 where 工号='" + id + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            label5.Text = sdr[0].ToString();
            sdr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                //输入修复详情和修复结束时间
                string s = richTextBox1.Text.ToString().Replace(" ", "");
                string d = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string sql1 = "update 修复表 set 修复情况='" + s + "'  where 编号='" + xno + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                string sql2 = "update 修复表 set 结束时间='" + d + "'  where 编号='" + xno + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("修复成功");
                richTextBox1.Text = "";
            }
            else
                MessageBox.Show("修复详情不能为空");
        }

        private void jiancha_details_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.x.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }
    }
}
