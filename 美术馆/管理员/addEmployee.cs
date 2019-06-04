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
    public partial class addEmployee : Form
    {
        public SqlConnection conn = null;
        public Personnel_main page;
        int userid;
        public addEmployee(Personnel_main l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.userid = id;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("员工姓名未填写", "提示");
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("员工性别未选择", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("员工联系电话未填写", "提示");
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("员工身份证号码未填写", "提示");
            }
            else if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("员工职位未选择", "提示");
            }
            else if (textBox3.Text.ToString().Length!=18)
            {
                MessageBox.Show("员工身份证号码格式错误", "提示");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^[1]+[3,5,7,8]+\d{9}"))
            {
                MessageBox.Show("员工联系电话格式错误", "提示");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"(^\d{18}$)|(^\d{15}$)"))
            {
                MessageBox.Show("员工身份证号码格式错误", "提示");
            }
            else
            {
                string gender = "";
                if (radioButton1.Checked)
                {
                    gender = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    gender = radioButton2.Text;
                }
                SqlCommand cmd = new SqlCommand("insert into 员工信息表(姓名,密码,性别,联系方式,身份证号,职位,入职时间,密保问题,密保问题的答案) values('" + textBox1.Text + "','111111','" + gender + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + DateTime.Now.ToString() + "','你的优点是什么？','玛迦山美术馆')", conn);
                cmd.ExecuteNonQuery();
                if (comboBox1.Text.Equals("专家"))
                {
                    goodAt goo = new goodAt(this);
                    this.Hide();
                    goo.Show();
                }
                else
                {
                    MessageBox.Show("提交成功", "提示");
                    this.Hide();
                    this.page.Show();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }
    }
}
