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
    public partial class lend : Form
    {
        public SqlConnection conn = null;
        private int userid;
        private int cid;
        private int gid;
        exit page;
        public lend(exit l, int id, int userid,int gid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = userid;
            this.page = l;
            this.cid = id;
            this.gid = gid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 藏品编号,起始时间,截止时间 from 外借表 where 藏品编号='" + cid + "' and (起始时间<=Convert.ToDateTime(datePicker2.Text).ToString('yyyy-MM-dd 00:00:00')  or 截止时间>=Convert.ToDateTime(datePicker1.Text).ToString('yyyy-MM-dd 00:00:00') )";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())         //从结果中找到
            {
                MessageBox.Show("该藏品外借中,'" + sdr[1].ToString()+ "'借出，'" + sdr[2].ToString()+ "'归还", "提示");
                sdr.Close();
            }
            else
            {
                string sql1 = "SELECT 藏品编号 from 修复表 where 藏品编号='" + cid + "' and 结束时间 is NULL";
                sdr.Close();
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader sdr1;
                sdr1 = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    MessageBox.Show("该藏品修复中，修复结束时间未知", "提示");
                    sdr.Close();
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into 外借表(藏品编号,操作员工号,外借美术馆编号,美术馆负责人姓名,联系方式,起始时间,截止时间) values('" + this.cid + "','" + this.userid + "','" + this.gid + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("yyyy-mm-dd") + "','" + dateTimePicker2.Value.ToString("yyyy-mm-dd") + "')", conn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("提交成功", "提示");
                    this.Close();
                }
            }
           
        }
    }
}
