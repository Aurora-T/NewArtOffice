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
    public partial class jiancha : Form
    {
        public SqlConnection conn = null;
        public int id,cno,jno;
        public expert_main main = null;
        public jiancha(expert_main main)
        {
            InitializeComponent();
            this.main = main;
            this.id = main.id;
            this.conn = main.conn;
        }

        //检查藏品
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null && this.dataGridView1.CurrentRow.Cells[1].Value != null)
            {
                jno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                jiancha_details jd = new jiancha_details(this);
                this.Close();
                jd.Show();
            }
            else
                MessageBox.Show("未选中");
        }

        private void jiancha_Load(object sender, EventArgs e)
        {
            label3.Text = this.id.ToString();
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            string sql = "SELECT 检查记录编号,藏品编号,应该检查时间 FROM 检查表 where 专家编号 is  not NULL and 实际检查时间 is NULL";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr[2].ToString();
            }
            sdr.Close();
        }

        //点击某个单元格时，提示藏品信息
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                int cno = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                cangpin c = new cangpin(conn,cno);
                c.ShowDialog();
            }
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

        //刷新界面
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = this.id.ToString();
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            string sql = "SELECT 检查记录编号,藏品编号,应该检查时间 FROM 检查表 where 专家编号 is  not NULL and 实际检查时间 is NULL";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr[2].ToString();
            }
            sdr.Close();
        }
    }
}
