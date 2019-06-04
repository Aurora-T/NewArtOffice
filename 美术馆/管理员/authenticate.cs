using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using 美术馆.管理员;

namespace 美术馆
{
    public partial class cangpinjianding : Form
    {
        public SqlConnection conn = null;
        private int id;
        private int userid;
        index page;
        public cangpinjianding(index l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = id;
            this.page = l;
            String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配'order by 征集时间";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            //得到选中行某列的值
            dataGridView1.ClearSelection();
            label4.Text = "";
            label11.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label11.Text = "";
            dataGridView1.ClearSelection();
            addCollection addclo = new addCollection(this);
            this.Hide();
            addclo.Show();
        }

        private void 搜索_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 藏品名称 ='" + text + "'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            label4.Text = "";
            label11.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;
                //得到选中行某列的值
                string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String sql = "select 编号,备注 from 征集表 where 藏品名称 ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                if (str != "")
                {
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    sdr.Read();
                    label11.Text = sdr[1].ToString();
                    this.id = Int32.Parse(sdr[0].ToString());
                    label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    sdr.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (text == "油画")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 类别='油画' order by 藏品名称";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "水彩")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 类别='水彩'order by 藏品名称 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "素描")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 类别='素描' order by 创作年代";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "国画")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 类别='国画' order by 创作年代 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "版画")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 类别='版画' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配' and 状态='未匹配' order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();
            label4.Text = "";
            label11.Text = "";
        }

        private void cangpinjianding_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        public void save()
        {
            String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配'";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            //得到选中行某列的值
            dataGridView1.ClearSelection();
            label4.Text = "";
            label11.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                label4.Text = "";
                label11.Text = "";
                dataGridView1.ClearSelection();
                matchingExpert mat = new matchingExpert(this, this.id, this.userid);
                this.Hide();
                mat.Show();
            }
            else
            {
                MessageBox.Show("未选择藏品", "提示");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label11.Text = "";
            dataGridView1.ClearSelection();
            this.Hide();
            this.page.Show();
        }
    }
}
