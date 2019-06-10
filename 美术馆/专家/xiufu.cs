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
    public partial class xiufu : Form
    {
        public SqlConnection conn = null;
        public int id;
        public int cno;
        public int xno;
        public expert_main main = null;
        public xiufu(expert_main main)
        {
            InitializeComponent();
            this.main = main;
            this.id = main.id;
            this.conn = main.conn;
        }

        private void xiufu_Load(object sender, EventArgs e)
        {
            label3.Text = this.id.ToString();
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //查询专家编号
            string sql = "SELECT 专家编号 FROM 专家表 where 工号='" + id + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int zno = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            string sql1 = "SELECT 编号,藏品编号 FROM 修复表 where 专家编号 ='" + zno + "' and 修复情况 is NULL";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr1[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr1[1].ToString();
            }
            sdr1.Close();
        }

        private void 修复_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null && this.dataGridView1.CurrentRow.Cells[1].Value != null)
            {
                xno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                xiufu_details jd = new xiufu_details(this,xno);
                this.Hide();
                jd.Show();
            }
            else
                MessageBox.Show("未选中");
        }
        //刷新
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = this.id.ToString();
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //查询专家编号
            string sql = "SELECT 专家编号 FROM 专家表 where 工号='" + id + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int zno = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            string sql1 = "SELECT 编号,藏品编号 FROM 修复表 where 专家编号 ='" + zno + "' and 修复情况 is NULL";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr1[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr1[1].ToString();
            }
            sdr1.Close();
        }

        //点击某个单元格时，提示藏品信息
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells[1].Value != null)
            {
                int cno = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                cangpin c = new cangpin(conn, cno);
                c.ShowDialog();
                button1.Enabled = true;
            }
            else
                MessageBox.Show("未选中！");
        }

        private void jiancha_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }
    }
}
