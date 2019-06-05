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
    public partial class arrange_zhanlan : Form
    {
        zhanlan_main main = null;
        int id,zt;
        public SqlConnection conn = null;

        public arrange_zhanlan(zhanlan_main main, int id)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.id = id;
            this.label2.Text = id.ToString();

            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //显示空余展厅
            string d1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "SELECT 展厅编号,楼层,位置,面积,容量,租金 FROM 展厅信息总表 where 展厅编号 not in(select 展厅编号 from 展览安排表 where 开始时间<='" + d1 + "' and 结束时间>'" + d1 + "')";
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
            }
            sdr.Close();
        }

        //安排展览
        private void button1_Click(object sender, EventArgs e)
        {
            
            string time1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //截止时间
            string time2= dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");

            int flag1 = 0, flag2 = 0,flag3=0;
            if (string.Compare(time1, time2) == 1 || string.Compare(time1, time2) == 0)
                MessageBox.Show("截止时间应晚于起始时间");
            else
                flag1 = 1;
            if (textBox1.Text == "")
                MessageBox.Show("展览名称不能为空");
            else
                flag2 = 1;
            if (label5.Text == "***")
                MessageBox.Show("必须选择展厅编号");
            else
                flag3 = 1;
            if (flag1 == 1 && flag2 == 1&&flag3==1)
            {
                string sql = "insert into 展览安排表(展览名称,展厅编号,开始时间,结束时间,负责人编号,简介) Values(@zname,@zt,@start,@end,@id,@jianjie)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@zname", SqlDbType.Char);
                sp.Value = textBox1.Text;
                sp = cmd.Parameters.Add("@zt", SqlDbType.Char);
                sp.Value = zt;
                sp = cmd.Parameters.Add("@start", SqlDbType.Char);
                sp.Value = time1;
                sp = cmd.Parameters.Add("@end", SqlDbType.Char);
                sp.Value = time2;
                sp = cmd.Parameters.Add("@id", SqlDbType.Int);
                sp.Value = id;
                sp = cmd.Parameters.Add("@jianjie", SqlDbType.Char);
                sp.Value = richTextBox1.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("安排成功");
            }

            button2.Enabled = true;
        }

        //显示开始时间时的空余的展厅
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;

            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //显示空余展厅
            DateTime date1 = DateTime.Parse(dateTimePicker1.Value.ToString());
            string d = date1.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "SELECT 展厅编号,楼层,位置,面积,容量,租金 FROM 展厅信息总表 where 展厅编号 not in(select 展厅编号 from 展览安排表 where 开始时间<='" + d + "' and 结束时间>'" + d + "')";
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
            }
            sdr.Close();
        }

        //为刚安排的展览添加展览品
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT top 1 展览编号 FROM 展览安排表  order by 展览编号 desc";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int zl = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            add_zanlanpin add_Zanlanpin = new add_zanlanpin(this, zl);
            this.Hide();
            add_Zanlanpin.Show();
        }

        private void arrange_zhanlan_FormClosed(object sender, FormClosedEventArgs e)
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

        private void arrange_zhanlan_Load(object sender, EventArgs e)
        {

        }

        //选择展厅
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1&& this.dataGridView1.CurrentRow.Cells[0].Value!=null)
            {
                zt = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                label5.Text = zt.ToString();
            }
            else
                MessageBox.Show("未选中");
        }
    }
}
