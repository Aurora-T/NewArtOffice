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
    public partial class cangpinjiancha : Form
    {
        public SqlConnection conn = null;
        index i = null;
        public int cno;
        public cangpinjiancha(index i)
        {
            InitializeComponent();
            this.i = i;
            this.conn = i.conn;
        }

        //按条件查询藏品，安排检查
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString());
            string d1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();

            //从数据库查询已到检查时间但未安排并且现在在馆内的藏品
            string sql = "SELECT 检查记录编号,藏品编号,应该检查时间 FROM 检查表 where 专家编号 is NULL and 应该检查时间='" + date + "' or 应该检查时间 < '" + date + "' and 藏品编号 not in(select 藏品编号 from 外借表 where 起始时间>'" + d1 + "'  and 截止时间<'" + d1 + "' or 截止时间='" + d1 + "')";
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
            //查询从未检查过并且在馆内的藏品
            string sql1 = "SELECT 藏品表.藏品编号 FROM 藏品表 where 藏品表.藏品编号 not in(select 藏品编号 from 检查表) and 藏品表.藏品编号 not in(select 藏品编号 from 外借表 where 起始时间>'" + d1 + "'  and 截止时间<'" + d1 + "' or 截止时间='" + d1 + "')";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr1[0].ToString();
            }
            sdr1.Close();
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

        //选中一个藏品编号，为其分配专家
        private void button2_Click(object sender, EventArgs e)
        {
            int jno = -1;
            if (this.dataGridView1.CurrentRow != null&&this.dataGridView1.CurrentRow.Cells[1].Value!= null)
            {
                if (this.dataGridView1.CurrentRow.Cells[0].Value != null)
                    jno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                arrange_jianchaexpert arrange = new arrange_jianchaexpert(this.conn, cno, jno);
                arrange.ShowDialog();
            }
            else
                MessageBox.Show("未选中");
        }

        //刷新界面
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString());
            string d1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();

            //从数据库查询已到检查时间但未安排并且在馆内的藏品
            string sql = "SELECT 检查记录编号,藏品编号,应该检查时间 FROM 检查表 where 专家编号 is NULL and 应该检查时间='" + date + "' or 应该检查时间 < '" + date + "' and 藏品编号 not in(select 藏品编号 from 外借表 where 起始时间<'" + d1 + "' or 起始时间='" + d1 + "' and 截止时间>'" + d1 + "' )";
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
            //查询从未检查过并且在馆内的藏品
            string sql1 = "SELECT 藏品表.藏品编号 FROM 藏品表 where 藏品表.藏品编号 not in(select 藏品编号 from 检查表) and 藏品表.藏品编号 not in(select 藏品编号 from 外借表 where 起始时间<'" + d1 + "'  or 起始时间='" + d1 + "'  and 截止时间>'" + d1 + "')";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr1[0].ToString();
            }
            sdr1.Close();
        }
    }
}
