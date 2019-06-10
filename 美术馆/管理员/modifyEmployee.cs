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
    public partial class modifyEmployee : Form
    {
        public SqlConnection conn = null;
        public employee page;
        int userid;
        int stid;
        public modifyEmployee(employee l, int stid, int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.userid = userid;
            this.stid = stid;
            String sql = "select 姓名,性别,职位,datediff(year,substring(身份证号,7,4),getdate()) 年龄,入职时间 from 员工信息表 where 工号 ='" + stid + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            label2.Text = stid.ToString();
            label4.Text = sdr[0].ToString();
            label8.Text = sdr[1].ToString();
            label9.Text = sdr[2].ToString();
            label11.Text= sdr[3].ToString();
            label13.Text = sdr[4].ToString();
            sdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if(text=="专家"|| text == "藏品管理员"|| text == "人事管理员" || text == "票务管理员" || text == "展览管理员" || text == "通知管理员" || text == "财务管理员")
            {
                SqlCommand cmd = new SqlCommand("update 员工信息表 set 职位='"+ text+"' where 工号='"+this.stid+"'", conn);
                cmd.ExecuteNonQuery();
                if (text == "专家")
                {
                    mgoodAt goo = new mgoodAt(this);
                    this.Hide();
                    goo.Show();
                }
                else
                {
                    MessageBox.Show("提交成功", "提示");
                    this.Hide();
                    this.page.Show();
                    this.page.save();
                }
                
            }
            else
            {
                MessageBox.Show("未选择修改职位", "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }
    }
}
