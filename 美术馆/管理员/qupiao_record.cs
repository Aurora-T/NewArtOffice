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
    public partial class qupiao_record : Form
    {
        SqlConnection conn = null;
        int id;
        piaowu_main main = null;
        public qupiao_record(piaowu_main main)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.id = main.id;
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
            string sql = "SELECT 票号,出票时间,参观者姓名,参观者身份证号 FROM 取票表 where (Datename(year,出票时间)+'-'+Datename(month, 出票时间) + '-' + Datename(day, 出票时间)) = '" + time + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr[2].ToString();
                this.dataGridView1.Rows[index].Cells[3].Value = sdr[4].ToString();               
            }
            sdr.Close();
        }

        //显示全部
        private void button2_Click(object sender, EventArgs e)
        {
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();

            //从数据库按查询条件获取充值记录
            string sql = "SELECT 票号,出票时间,参观者姓名,参观者身份证号 FROM 取票表 order by 出票时间 desc";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr[2].ToString();
                this.dataGridView1.Rows[index].Cells[3].Value = sdr[4].ToString();
            }
            sdr.Close();
        }
    }
}
