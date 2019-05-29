using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using 美术馆.管理员;

namespace 美术馆
{
    public partial class loginForm : Form
    {
        public SqlConnection conn = null;
        public loginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userid = textBox1.Text;
            string password = textBox2.Text;
            if (userid.Equals("") || password.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else
            {
                string ConStr = "Data Source=101.132.124.13;Initial Catalog=美术馆;User ID=sa;Password=123";
                conn = new SqlConnection(ConStr);
                conn.Open();
                string sql = "SELECT 职位,工号,密码 from 员工信息表 where 工号='" + userid  + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                if (sdr.Read())         //从结果中找到
                {
                    if (sdr[2].ToString().Trim() == textBox2.Text.Trim())
                    {
                        MessageBox.Show("登录成功", "提示");
                        if (sdr[0].ToString() == "藏品管理员")
                        {
                            int id = Int32.Parse(sdr[1].ToString());
                            index main = new index(this, id);
                            this.Hide();
                            main.Show();
                        }
                        //else if (sdr[0].ToString() == "专家")
                        //{
                        //    mainForm_admin main = new mainForm_admin();
                        //    this.Hide();
                        //    main.Show();
                        //}
                        //else if (sdr[0].ToString() == "人事管理员")
                        //{
                        //    mainForm_admin main = new mainForm_admin();
                        //    this.Hide();
                        //    main.Show();
                        //}
                        //else if (sdr[0].ToString() == "财务管理员")
                        //{
                        //    mainForm_admin main = new mainForm_admin();
                        //    this.Hide();
                        //    main.Show();
                        //}
                        //else if (sdr[0].ToString() == "展览管理员")
                        //{
                        //    mainForm_admin main = new mainForm_admin();
                        //    this.Hide();
                        //    main.Show();
                        //}
                    }
                    else
                    {
                        MessageBox.Show("密码错误", "提示");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在", "提示");
                    return;
                }
                sdr.Close();
            }
        }
    }
}
