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
    public partial class enter : Form
    {
        public SqlConnection conn = null;
        private int userid;
        public enter(index l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = id;
            String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' order by 征集时间";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                label4.Text = "";
            }
            else
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' and charindex('" + text + "',藏品名称)>=0";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                label4.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (text == "油画")
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' and 类别='油画' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "水彩")
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' and 类别='水彩' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "素描")
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' and 类别='素描' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "国画")
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' and 类别='国画' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "版画")
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' and 类别='版画' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            label4.Text = "";
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (str != "")
                {
                    label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
            }
        }

        private void enter_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                enterDetail ed = new enterDetail(this, id, this.userid);
                this.Hide();
                ed.Show();
            }
            else
            {
                MessageBox.Show("未选择藏品", "提示");
            }
        }
        public void save()
        {
            String sql = "select 编号,藏品名称,类别,征集时间 from 征集表 where 状态='已鉴定' order by 征集时间";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            label4.Text = "";
        }
    }
}
