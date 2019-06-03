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
    public partial class inform : Form
    {
        public SqlConnection conn = null;
        private int userid;
        inform_main page;
        public inform(inform_main l, int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = id;
            this.page = l;
            String sql = "select 编号,发布者工号,标题,发布时间 from 通知表  order by 发布时间 desc";
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
                String sql = "select 编号,发布者工号,标题,发布时间 from 通知表  order by 发布时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                int temp = Int32.Parse(text.ToString());
                String sql = "select 编号,发布者工号,标题,发布时间 from 通知表 where 发布者工号='"+temp+"' order by 发布时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int informId = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                informDetail ind = new informDetail(this, this.userid,informId);
                ind.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("未选择通知");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int informId = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand("delete from 通知表 where 编号='"+informId+"'", conn);
                cmd.ExecuteNonQuery();
                this.save();
                MessageBox.Show("删除成功", "提示");
                
            }
            else
            {
                MessageBox.Show("未选择通知");
            }
        }
        public void save()
        {
            String sql = "select 编号,发布者工号,标题,发布时间 from 通知表  order by 发布时间 desc";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }
    }
}
