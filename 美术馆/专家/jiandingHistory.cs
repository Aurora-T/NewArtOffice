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

namespace 美术馆.专家
{
    public partial class jiandingHistory : Form
    {
        public SqlConnection conn = null;
        public int userid;
        public jianding page = null;
        public jiandingHistory(jianding l, int userid)
        {
            InitializeComponent();
            this.page = l;
            this.userid = userid;
            this.conn = l.conn;
            save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                save();
            }
            else
            {
                int n;
                if (!int.TryParse(text, out n))
                {
                    MessageBox.Show("请搜索输入纯数字");
                }
                else
                {
                    String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                    SqlCommand cmd = new SqlCommand(sql1, conn);
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    sdr.Read();
                    String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL  and 鉴定表.藏品编号='" + text + "' order by 鉴定时间 desc";
                    SqlCommand sc = new SqlCommand(sql, conn);
                    SqlDataAdapter myda = new SqlDataAdapter(sc);
                    DataTable dt = new DataTable();
                    sdr.Close();
                    myda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.ClearSelection();
                }
            }
            dataGridView1.ClearSelection();
        }
        private void save()
        {
            String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL order by 鉴定时间 desc";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sdr.Close();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (text == "油画")
            {
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL and 类别='油画' order by 鉴定时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "水彩")
            {
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL and 类别='水彩' order by 鉴定时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "素描")
            {
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL and 类别='素描'order by 鉴定时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "国画")
            {
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL and 类别='国画' order by 鉴定时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "版画")
            {
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,鉴定结果,鉴定价值,鉴定表.备注,鉴定时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is not NULL and 类别='版画' order by 鉴定时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                sdr.Close();
                save();
            }
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }
    }
}
