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
    public partial class zhanlan_history : Form
    {
        zhanlan_main main = null;
        public SqlConnection conn = null;
        public zhanlan_history(zhanlan_main main)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;

            //显示在展展览
            string d1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //从数据库按查询条件获取数据
            string sql1 = "SELECT 展览编号,展览名称,展厅编号,负责人编号,租金,开始时间,结束时间 FROM 展览安排表 where 开始时间<='" + d1 + "' and 结束时间>='" + d1 + "'";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr1[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr1[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr1[2].ToString();
                this.dataGridView1.Rows[index].Cells[3].Value = sdr1[3].ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = sdr1[4].ToString();
                this.dataGridView1.Rows[index].Cells[5].Value = sdr1[5].ToString();
                this.dataGridView1.Rows[index].Cells[6].Value = sdr1[6].ToString();
            }
            sdr1.Close();
        }

        //按时间查询
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString());
            string year = date.Year.ToString();
            string month = date.Month.ToString();
            if (month.Length == 1)
                month = "0" + month;
            string day = date.Day.ToString();
            if (day.Length == 1)
                day = "0" + day;
            string time = year + "-" + month + "-" + day;

            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //从数据库按查询条件获取充值记录
            string sql = "SELECT 展览编号,展览名称,展厅编号,负责人编号,租金,开始时间,结束时间 FROM 展览安排表 where (Datename(year,开始时间)+'-'+Datename(month, 开始时间) + '-' + Datename(day, 开始时间)) <= '" + time + "' and (Datename(year,结束时间)+'-'+Datename(month, 结束时间) + '-' + Datename(day, 结束时间)) >= '" + time + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr[2].ToString();
                this.dataGridView1.Rows[index].Cells[3].Value = sdr[3].ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = sdr[4].ToString();
                this.dataGridView1.Rows[index].Cells[5].Value = sdr[5].ToString();
                this.dataGridView1.Rows[index].Cells[6].Value = sdr[6].ToString();
            }
            sdr.Close();
        }

        //显示全部
        private void button2_Click(object sender, EventArgs e)
        {
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();

            //从数据库按查询条件获取记录
            string sql = "SELECT 展览编号,展览名称,展厅编号,负责人编号,租金,开始时间,结束时间 FROM 展览安排表";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr[2].ToString();
                this.dataGridView1.Rows[index].Cells[3].Value = sdr[3].ToString();
                this.dataGridView1.Rows[index].Cells[4].Value = sdr[4].ToString();
                this.dataGridView1.Rows[index].Cells[5].Value = sdr[5].ToString();
                this.dataGridView1.Rows[index].Cells[6].Value = sdr[6].ToString();
            }
            sdr.Close();
        }

        //点击展览编号显示展览详情
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1&& this.dataGridView1.CurrentRow.Cells[0].Value!=null)
            {
                int zno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                zhanlan_details details = new zhanlan_details(this, zno);
                this.Hide();
                details.Show();
            }
            else
                MessageBox.Show("未选中");
        }

        //点击叉号后关闭界面，退回到主界面
        void administrator_FormClosed(object sender, FormClosedEventArgs e)
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

        //为已有展览添加展览品
        private void button4_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.CurrentRow != null)
            {
                int zl= Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string sql = "SELECT count(展览品编号) FROM 展览品表 where 展览编号='" + zl + "'";
                SqlCommand Cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = Cmd.ExecuteReader();
                sdr.Read();
                int n = Int32.Parse(sdr[0].ToString());
                sdr.Close();
                //展厅容量
                int zt = Int32.Parse(this.dataGridView1.CurrentRow.Cells[2].Value.ToString());
                string sql1 = "SELECT 容量 FROM 展厅信息总表 where 展厅编号='"+zt+"'";
                SqlCommand Cmd1 = new SqlCommand(sql1, conn);
                SqlDataReader sdr1 = Cmd1.ExecuteReader();
                sdr1.Read();
                int m = Int32.Parse(sdr1[0].ToString());
                sdr1.Close();
                if (m == n)
                    MessageBox.Show("展厅已满");
                else
                {
                    add_old_zhanlanpn o = new add_old_zhanlanpn(this, zl);
                    this.Hide();
                    o.Show();
                }
            }
            else
                MessageBox.Show("未选中");
            
        }
    }
}
