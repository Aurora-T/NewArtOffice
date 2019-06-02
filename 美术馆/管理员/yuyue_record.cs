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
    public partial class yuyue_record : Form
    {
        SqlConnection conn = null;
        piaowu_main main = null;
        int id;
        public yuyue_record(piaowu_main main)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.id = main.id;
        }

        private void yuyue_record_FormClosed(object sender, FormClosedEventArgs e)
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

        //查询某一天的预约记录
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

            //从数据库查询已到检查时间但未安排并且现在在馆内的藏品
            string sql = "SELECT 编号,预约日期,同行人1姓名,同行人1身份证号,同行人2姓名,同行人2身份证号,联系方式,状态 FROM 预约表 where (Datename(year,操作时间)+'-'+Datename(month, 操作时间) + '-' + Datename(day, 操作时间)) = '" + time + "'";
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
                this.dataGridView1.Rows[index].Cells[7].Value = sdr[7].ToString();
            }
            sdr.Close();
        }
    }
}
