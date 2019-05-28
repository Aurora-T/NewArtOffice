using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using 美术馆.管理员;

namespace 美术馆
{
    public partial class cangpinjianding : Form
    {
        SqlConnection conn = null;
        public cangpinjianding(index l)
        {
            InitializeComponent();
            this.conn = l.conn;
            String sql = "select 藏品编号,类别,作者,创作年代,征集时间 from 征集表";
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addCollection addclo = new addCollection();
            this.Hide();
            addclo.Show();
        }

        private void 搜索_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 where 藏品编号 ='" +text+"'"; 
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn); 
            DataTable dt = new DataTable();
            myda.Fill(dt); 
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;

                int intColumn = dataGridView1.SelectedCells[0].ColumnIndex;

                //得到选中行某列的值
                string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                MessageBox.Show(str);
                String sql = "select 备注 from 征集表 where 藏品编号 ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                label11.Text = sdr[0].ToString();
                label4.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sdr.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.SelectedText;
            if (text == "藏品编号升序")
            {
                String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 order by 藏品编号";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品编号降序")
            {
                String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 order by 藏品编号 desc";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作年代升序")
            {
                String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 order by 创作年代";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作年代降序")
            {
                String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 order by 创作年代 desc";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "征集时间降序")
            {
                String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 order by 征集时间";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "征集时间降序")
            {
                String sql = "select 藏品编号,类型,作者,创作年代,征集时间 from 征集表 order by 征集时间 desc";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
