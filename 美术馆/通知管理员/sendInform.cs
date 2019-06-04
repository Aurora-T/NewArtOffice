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

namespace 美术馆.通知管理员
{
    public partial class sendInform : Form
    {
        public SqlConnection conn = null;
        inform page;
        int userid;
        public sendInform(inform l,int userid)
        {
            InitializeComponent();
            this.page = l;
            this.userid = userid;
            this.conn = l.conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("通知标题未填写", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("通知内容未填写", "提示");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into 通知表(发布者工号,发布时间,标题,内容) values('" + this.userid + "','" + DateTime.Now.ToString("yyyy-mm-dd 00:00:00") + "','" + textBox1.Text + "','" + textBox2.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                this.Hide();
                this.page.Show();
                this.page.save();
            }
        }
    }
}
