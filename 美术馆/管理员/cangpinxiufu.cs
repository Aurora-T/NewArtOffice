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
    public partial class cangpinxiufu : Form
    {
        index i = null;
        SqlConnection conn = null;
        public cangpinxiufu(index i)
        {
            InitializeComponent();
            this.i = i;
            this.conn = i.conn;
        }

        //查询要安排修复的藏品
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 编号,开始时间,藏品编号 FROM 修复表 where 专家编号 is NULL";
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


        //点击叉号后关闭界面，退回到record界面
        void administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.i.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }

        }

        //安排专家
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null&&this.dataGridView1.CurrentRow.Cells[1].Value!= null)
            {
                int xno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                int cno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                arrange_xiufuexpert arrange = new arrange_xiufuexpert(this.conn, cno, xno);
                arrange.ShowDialog();
            }
            else
                MessageBox.Show("未选中");
        }

        //刷新界面
        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 编号,开始时间,藏品编号 FROM 修复表 where 专家编号 is NULL";
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
