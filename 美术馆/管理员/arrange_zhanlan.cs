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
        public SqlConnection conn = null;
        zhanlan_main main = null;
        int id,zt;
        public arrange_zhanlan(zhanlan_main  main)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.id = main.id;
            label2.Text = id.ToString();

            //显示空余展厅
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
            //从数据库按查询条件获取数据
            string sql = "SELECT 展厅编号,楼层,位置,容量,租金 FROM 展厅信息总表 where 展厅编号 not in(select 展厅编号 from 展览安排表 where (Datename(year,结束时间)+'-'+Datename(month, 结束时间) + '-' + Datename(day, 结束时间))>'" + date+ "' and (Datename(year,开始时间)+'-'+Datename(month, 开始时间) + '-' + Datename(day, 开始时间))<='"+date+"') ";
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
            }
            sdr.Close();
        }

        //添加展览品
        private void button2_Click(object sender, EventArgs e)
        {
            //将刚安排的展览编号传给添加展览品
            string sql = "SELECT top 1 展览编号 FROM 展览安排表 order by 展览编号 desc";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int zl = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            add_zhanlanpin add = new add_zhanlanpin(this,zl);
            this.Hide();
            add.Show();
        }

        //确定安排展览
        private void button1_Click(object sender, EventArgs e)
        {
            //起始时间
            DateTime date1 = DateTime.Parse(dateTimePicker1.Value.ToString());
            string year1 = date1.Year.ToString();
            string month1 = date1.Month.ToString();
            if (month1.Length == 1)
                month1 = "0" + month1;
            string day1 = date1.Day.ToString();
            if (day1.Length == 1)
                day1 = "0" + day1;
            string time1 = year1 + "-" + month1 + "-" + day1;
            //截止时间
            DateTime date2 = DateTime.Parse(dateTimePicker2.Value.ToString());
            string year2 = date2.Year.ToString();
            string month2 = date2.Month.ToString();
            if (month2.Length == 1)
                month2 = "0" + month2;
            string day2 = date2.Day.ToString();
            if (day2.Length == 1)
                day2 = "0" + day2;
            string time2 = year2 + "-" + month2 + "-" + day2;

            int flag1 = 0,flag2=0,flag3=0;
            if (string.Compare(time1, time2) == 1 || string.Compare(time1, time2) == 0)
                MessageBox.Show("截止时间应晚于起始时间");
            else
                flag1 = 1;
            if (textBox1.Text == "")
                MessageBox.Show("展览名称不能为空");          
            else
                flag2 = 1;
            if (label5.Text == "")
                MessageBox.Show("展厅编号不能为空");
            else
                flag3 = 1;
            if (flag1 == 1&&flag2==1&&flag3==1)
            {
                string sql = "Insert Into 展览安排表(展览名称,展厅编号,开始时间,结束时间,负责人编号,简介) Values (@name,@zt,@start,@end,@id,@jianjie)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@name", SqlDbType.Char);
                sp.Value = this.textBox1.Text;
                sp = cmd.Parameters.Add("@zt", SqlDbType.Int);
                sp.Value = this.label5.Text;
                sp = cmd.Parameters.Add("@start", SqlDbType.Char);
                sp.Value = time1;
                sp = cmd.Parameters.Add("@end", SqlDbType.Char);
                sp.Value = time2;
                sp = cmd.Parameters.Add("@id", SqlDbType.Char);
                sp.Value = this.label2.Text;
                sp = cmd.Parameters.Add("@jianjie", SqlDbType.Char);
                sp.Value = this.richTextBox1.Text;

                cmd.ExecuteNonQuery();
                MessageBox.Show("安排成功");
            }
            //安排展览后再添加展览品
            button2.Enabled = true;
        }

        private void arrange_zhanlan_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                main.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //选择展厅
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {      
                zt = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                label5.Text = zt.ToString();
            }
            else
                MessageBox.Show("未选中");
        }
    }
}
