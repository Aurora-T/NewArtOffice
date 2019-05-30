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
    public partial class jianding : Form
    {
        public SqlConnection conn = null;
        public int userid;
        public expert_main l = null;
        public jianding(expert_main l,int userid)
        {
            InitializeComponent();
            this.l = l;
            this.userid = userid;
            this.conn = l.conn;
            save();
        }

        private void jianding_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        private void save()
        {
            String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='"+sdr[0].ToString()+ "' and 鉴定结果 is NULL";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sdr.Close();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
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
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL and 鉴定表.藏品编号='"+text+"'";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            if (text == "藏品编号升序")
            {
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL order by 藏品编号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品编号降序")
            {
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL order by 藏品编号 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作年代升序")
            {
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL order by 创作年代";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "创作年代降序")
            {
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL order by 创作年代 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "征集时间升序")
            {
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL order by 征集时间";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "征集时间降序")
            {
                String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                sdr.Read();
                String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL order by 征集时间 desc";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                sdr.Close();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();
        }
    }
}
