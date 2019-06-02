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
using 美术馆.专家;

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
                int flag=0;
                string ConStr = "Data Source=223.104.190.215;Initial Catalog=美术馆;User ID=sa;Password=";
                conn = new SqlConnection(ConStr);
                conn.Open();
                string sql = "SELECT 职位,工号,密码 from 员工信息表 where 工号='" + userid  + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())         //从结果中找到
                {
                    if (sdr[1].ToString().Trim() == textBox1.Text.Trim())
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)               
                {                
                    if (sdr[2].ToString().Replace(" ","") == textBox2.Text.Replace(" ",""))
                    {
                        MessageBox.Show("成功登录");
                        string position = sdr[0].ToString();
                        int id = Int32.Parse(textBox1.Text);
                        if (position.Replace(" ","").Equals("藏品管理员"))
                        {
                            index i = new index(this, id);
                            this.Hide();
                            i.Show();
                        }
                        else if (position.Replace(" ", "").Equals("专家"))
                        {
                            expert_main main = new expert_main(this, id);
                            this.Hide();
                            main.Show();
                        }
                        else if (position.Replace(" ", "").Equals("票务管理员"))
                        {
                            piaowu_main main = new piaowu_main(this,id);
                            this.Hide();
                            main.Show();
                        }
                        //else if (position.Replace(" ", "").Equals("通知管理员"))
                        //{
                        //    expert_main main = new expert_main(this, id);
                        //    this.Hide();
                        //    main.Show();
                        //}
                    }
                    else
                    {
                        MessageBox.Show("密码错误", "提示");
                        textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("用户名不存在", "提示");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                sdr.Close();
            }
        }

        /*//关闭界面后退出系统，关闭数据库连接
        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }*/
    }
}
