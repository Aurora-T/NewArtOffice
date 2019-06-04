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
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("起始时间与当前时间矛盾", "提示");
            }
            else if (dateTimePicker1.Value>dateTimePicker2.Value)
            {
                MessageBox.Show("起始时间与截止时间矛盾", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请填写负责人姓名", "提示");
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("请填写负责人联系电话", "提示");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^[1]+[3,5,7,8]+\d{9}"))
            {
                MessageBox.Show("负责人联系电话格式错误", "提示");
            }
            else
            {
                string sql = "SELECT 藏品编号,起始时间,截止时间 from 外借表 where 藏品编号='" + this.cid + "' and ((convert(varchar(10),起始时间,20)<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "' and convert(varchar(10),截止时间,20)>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "') or (convert(varchar(10),截止时间,20)>='" + dateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00") + "' and convert(varchar(10),起始时间,20)<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00") + "') or (convert(varchar(10),起始时间,20)>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "' and convert(varchar(10),截止时间,20)<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd 00:00:00") + "'))";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                if (sdr.Read())         //从结果中找到
                {
                    MessageBox.Show("该藏品外借中,'" + sdr[1].ToString() + "'借出，'" + sdr[2].ToString() + "'归还", "提示");
                    sdr.Close();
                }
                else
                {
                    sdr.Close();
                    string sql1 = "SELECT 藏品编号 from 修复表 where 藏品编号='" + this.cid + "' and 结束时间 is NULL";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.CommandType = CommandType.Text;
                    SqlDataReader sdr1;
                    sdr1 = cmd1.ExecuteReader();
                    if (sdr1.Read())
                    {
                        MessageBox.Show("该藏品修复中，修复结束时间未知", "提示");
                        sdr1.Close();
                    }
                    else
                    {
                        string sql4 = "SELECT 藏品表.藏品编号,出馆表.出馆时间  from 藏品表,出馆表 where 藏品表.藏品编号=出馆表.藏品编号 and 藏品表.藏品编号='" + this.cid + "' and 藏品表.状态='出馆' and convert(varchar(10),出馆时间,20)<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00")+"'";
                        sdr1.Close();
                        SqlCommand cmd4 = new SqlCommand(sql4, conn);
                        cmd4.CommandType = CommandType.Text;
                        SqlDataReader sdr4;
                        sdr4 = cmd4.ExecuteReader();
                        if (sdr4.Read())         //从结果中找到
                        {
                            MessageBox.Show("该藏品于'" + sdr4[1].ToString() + "'赠送其他美术馆", "提示");
                            sdr4.Close();
                        }
                        else
                        {
                            sdr4.Close();
                            SqlCommand cmd2 = new SqlCommand("insert into 外借表(藏品编号,操作员工号,外借美术馆编号,美术馆负责人姓名,联系方式,起始时间,截止时间) values('" + this.cid + "','" + this.userid + "','" + this.gid + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59") + "')", conn);
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("提交成功", "提示");
                            this.Hide();
                            this.page.Show();
                        }
                    }
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }
    }
}
