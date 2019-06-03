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
    public partial class informDetail : Form
    {
        public SqlConnection conn = null;
        public inform page;
        int userid;
        int informid;
        public informDetail(inform l, int id,int informId)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.userid = id;
            this.informid = informId;
            String sql = "select 发布者工号,发布时间,标题,内容 from 通知表 where 编号 ='" + this.informid+ "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            label2.Text = informId.ToString();
            label4.Text = sdr[0].ToString();
            label6.Text = sdr[1].ToString();
            textBox1.Text = sdr[2].ToString();
            textBox2.Text = sdr[3].ToString();
            sdr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("update 通知表 set 发布者工号='"+this.userid+"',发布时间='"+DateTime.Now.ToString()+"',标题='"+textBox1.Text+"',内容= '"+textBox2.Text+"' where 编号='"+ this.informid+"'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功", "提示");
                this.Hide();
                this.page.Show();
                this.page.save();
            }
        }
    }
}
