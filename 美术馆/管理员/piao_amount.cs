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
    public partial class piao_amount : Form
    {
        public int id;
        piaowu_main main = null;
        public SqlConnection conn = null;
        public piao_amount(piaowu_main main)
        {
            InitializeComponent();
            this.main = main;
            this.id = main.id;
            this.conn = main.conn;
            label2.Text = id.ToString();

            //现在的放票数
            string d = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "select 票数 from 放票数表 where 起始时间<'"+d+" 'and 截止时间>'"+d+"'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            label4.Text = sdr[0].ToString();
            sdr.Close();
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

        //设置放票数
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
            int flag1 = 0,flag2 = 0;
            if (string.Compare(time1, time2) == 1 || string.Compare(time1, time2) == 0)
                MessageBox.Show("截止时间应晚于起始时间");
            else
                flag1 = 1;
            if (textBox1.Text == "")
                MessageBox.Show("票数不能为空");
            else
                flag2 = 1;
            if(flag1==1&&flag2==1)
            {
                int amount = Int32.Parse(textBox1.Text);
                string sql = "insert into 放票数表(起始时间,截止时间,票数,操作员工号) Values(@time1,@time2,@amount,@id)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@time1", SqlDbType.Char);
                sp.Value = time1;
                sp = cmd.Parameters.Add("@time2", SqlDbType.Char);
                sp.Value = time2;
                sp = cmd.Parameters.Add("@amount", SqlDbType.Char);
                sp.Value = amount;
                sp = cmd.Parameters.Add("@id", SqlDbType.Char);
                sp.Value = id;
                cmd.ExecuteReader();
                MessageBox.Show("设置成功");              
            }

        }
    }
}
