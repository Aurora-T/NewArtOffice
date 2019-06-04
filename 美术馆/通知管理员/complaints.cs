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
    public partial class complaints : Form
    {
        public SqlConnection conn = null;
        private int userid;
        inform_main page;
        public complaints(inform_main l, int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = id;
            this.page = l;
            String sql = "select 编号,ID,内容,时间,联系方式 from 投诉建议表  order by 时间 desc";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                String sql = "select 编号,ID,内容,时间,联系方式 from 投诉建议表  order by 时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                String sql = "select 编号,ID,内容,时间,联系方式 from 投诉建议表 where 编号='"+textBox1.Text+"' order by 时间 desc";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }
    }
}
