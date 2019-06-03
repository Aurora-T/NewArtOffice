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
                SqlCommand cmd2 = new SqlCommand("update 藏品表 set 备注='"+textBox3.Text+"' where 入馆编号=(select 编号 from 入馆表 where 藏品编号='"+this.cid+"')", conn);
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
