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
    public partial class zhanlan_main : Form
    {
        public SqlConnection conn = null;
        loginForm l = null;
        public int id;
        public zhanlan_main(loginForm l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.l = l;
            this.id = id;
            label2.Text = id.ToString();
        }

        //显示在展展览
        private void zhanlan_main_Load(object sender, EventArgs e)
        {
            string d1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //从数据库按查询条件获取数据
            string sql = "SELECT 展览编号,展览名称,展厅编号,负责人编号,租金,开始时间,结束时间 FROM 展览表 where 开始时间<='"+d1+"' and 结束时间>='"+d1+"'";
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

        private void zhanlan_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.l.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        //点击展览编号显示展览详情
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                int zno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                zhanlan_details details = new zhanlan_details(this, zno);
                this.Hide();
                details.Show();
            }
        }

        //退出系统
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                l.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        //安排展览
        private void button1_Click(object sender, EventArgs e)
        {
            arrange_zhanlan zhanlan = new arrange_zhanlan(this);
            this.Hide();
            zhanlan.Show();
        }
    }
}
