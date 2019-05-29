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
        public cangpinjianding(index l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = id;
            String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配'";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            //得到选中行某列的值
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addCollection addclo = new addCollection(this);
            this.Hide();
            addclo.Show();
        }

        private void 搜索_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 状态='未匹配'";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 where 藏品名称 ='" + text + "'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;
                //得到选中行某列的值
                string str = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                String sql = "select 编号,备注 from 征集表 where 藏品名称 ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                label11.Text = sdr[1].ToString();
                this.id = Int32.Parse(sdr[0].ToString());
                label4.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sdr.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (text == "藏品名称升序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 藏品名称";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品名称降序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 藏品名称 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作年代升序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 创作年代";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作年代降序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 创作年代 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "征集时间升序序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "征集时间降序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 征集时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品类别降序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 类别";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品类别降序")
            {
                String sql = "select 藏品名称,类别,作者,创作年代,征集时间 from 征集表 order by 类别 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            matchingExpert mat = new matchingExpert(this,this.id,this.userid);
            this.Hide();
            mat.Show();
        }
    }
}
