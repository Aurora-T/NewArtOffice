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
    public partial class confirmEnter : Form
    {
        public SqlConnection conn = null;
        private int userid;
        private int cid;
        private enterDetail page;
        public confirmEnter(enterDetail page,int cid,int userid)
        {
            InitializeComponent();
            this.conn = page.conn;
            this.page = page;
            this.userid = userid;
            this.cid = cid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("")||textBox3.Text.Equals(""))
            {
                MessageBox.Show("存在必要信息未填写", "提示");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into 入馆表(藏品编号,操作员工号,来源详情,价值) values('" + this.cid + "','" + this.userid + "','" + textBox2.Text + "','" + textBox1.Text + "')", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("update 征集表 set 状态='入馆' where 编号='" + this.cid + "'", conn);
                cmd1.ExecuteNonQuery();
                String sql = "select 藏品名称,类别,作者,创作年代,藏品图片 from 征集表 where 编号 ='" + this.cid + "'";
                SqlCommand cmd3 = new SqlCommand(sql, conn);
                cmd3.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd3.ExecuteReader();
                sdr.Read();
                SqlCommand cmd2 = new SqlCommand("insert into 藏品表(藏品名称,类别,作者姓名,创作年代,图片,备注) values('" + sdr[0].ToString() + "','" + sdr[1].ToString() + "','" + sdr[2].ToString() + "','" + sdr[3].ToString() + "','"+ sdr[4].ToString() + "','"+textBox3.Text.ToString()+"')", conn);
                sdr.Close();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                this.Hide();
                this.page.page.Show();
                this.page.page.save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.page.Show();
        }
    }
}
