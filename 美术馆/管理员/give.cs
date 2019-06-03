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
    public partial class give : Form
    {
        public SqlConnection conn = null;
        private int userid;
        private int cid;
        private int gid;
        exit page;
        public give(exit l, int id, int userid,int gid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = userid;
            this.page = l;
            this.cid = id;
            this.gid = gid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("出馆时间与当前时间矛盾", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("请填写负责人姓名", "提示");
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("请填写负责人联系电话", "提示");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[1]+[3,5,7,8]+\d{9}"))
            {
                MessageBox.Show("负责人联系电话格式错误", "提示");
            }
            else
            {
                string sql4 = "SELECT 藏品表.藏品编号,出馆表.出馆时间  from 藏品表,出馆表 where 藏品表.藏品编号=出馆表.藏品编号 and 藏品表.藏品编号='" + this.cid + "' and 藏品表.状态='出馆'";
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
                    string sql = "SELECT 藏品编号,起始时间,截止时间 from 外借表 where 藏品编号='" + this.cid + "' and convert(varchar(10),截止时间,20)>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())         //从结果中找到
                    {
                        MessageBox.Show("该藏品外借中,'" + sdr[2].ToString() + "'归还", "提示");
                        sdr.Close();
                    }
                    else
                    {
                        string sql1 = "SELECT 藏品编号 from 修复表 where 藏品编号='" + this.cid + "' and 结束时间 is NULL";
                        sdr.Close();
                        SqlCommand cmd1 = new SqlCommand(sql1, conn);
                        cmd1.CommandType = CommandType.Text;
                        SqlDataReader sdr1;
                        sdr1 = cmd.ExecuteReader();
                        if (sdr1.Read())
                        {
                            MessageBox.Show("该藏品修复中", "提示");
                            sdr1.Close();
                        }
                        else
                        {
                            sdr1.Close();
                            SqlCommand cmd2 = new SqlCommand("insert into 出馆表(藏品编号,操作员工号,出馆时间,美术馆编号) values('" + this.cid + "','" + this.userid + "','" + dateTimePicker1.Value + "','" + this.gid + "')", conn);
                            cmd2.ExecuteNonQuery();
                            SqlCommand cmd3 = new SqlCommand("update 藏品表 set 状态='出馆' where 藏品编号='" + this.cid + "'", conn);
                            cmd3.ExecuteNonQuery();
                            MessageBox.Show("提交成功", "提示");
                            this.Hide();
                            this.page.Show();
                            this.page.save();
                        }
                    }
                }
            }
            
        }
    }
}
