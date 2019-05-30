using System;
using System.Collections;
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
    public partial class exit : Form
    {
        public SqlConnection conn = null;
        private int userid;
        index page;
        public exit(index l, int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = id;
            this.page = l;
            String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            load_gallery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 and 藏品表.藏品编号='" + text+"'";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (text == "藏品编号升序")
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 order by 藏品表.藏品编号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品编号降序")
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 order by 藏品表.藏品编号 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作时间升序")
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 order by 创作时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作时间降序")
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 order by 创作时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "鉴定价值升序")
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 order by 价值";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "鉴定价值降序")
            {
                String sql = "select 藏品表.藏品编号,藏品名称,藏品类型,作者姓名,创作时间,价值 from 藏品表,入馆表 where 藏品表.入馆编号=入馆表.编号 order by 价值 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (str != "")
                {
                    string sql1 = "SELECT 备注 from 藏品表 where 藏品编号='" + str + "'";
                    SqlCommand cmd = new SqlCommand(sql1, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    sdr.Read();
                    label5.Text = sdr[0].ToString();
                    sdr.Close();
                }
            }
        }

        private void exit_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addGallery ag = new addGallery(this);
            ag.Show();
            this.Close();
        }
        private void load_gallery()
        {
            ArrayList list = new ArrayList();
            string str = "select distinct 名称 from 美术馆表 ";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //dr[0]表示取结果的第一列，dr[1]就是第二列
                list.Add(dr[0].ToString().Trim());
            }
            comboBox2.DataSource = list;
            //comboBox2.SelectedIndex = 0;
        }
    }
}
