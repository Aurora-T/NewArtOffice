﻿using System;
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
using 美术馆.通知管理员;

namespace 美术馆
{
    public partial class loginForm : Form
    {
        public SqlConnection conn = null;
        public loginForm()
        {
            InitializeComponent();
            string ConStr = "Data Source=101.132.124.13;Initial Catalog=美术馆;User ID=sa;Password=mjsmsg_123";
            conn = new SqlConnection(ConStr);
            conn.Open();
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
                        if (textBox2.Text == "111111")
                        {
                            MessageBox.Show("登录成功，请记得尽快修改初始密码与添加密保问题","提示");
                        }
                        else
                        {
                            MessageBox.Show("登录成功","提示");
                        }
                        
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
                        else if (position.Replace(" ", "").Equals("人事管理员"))
                        {
                            Personnel_main main = new Personnel_main(this, id);
                            this.Hide();
                            main.Show();
                        }
                        else if (position.Replace(" ", "").Equals("展览管理员"))
                        {
                            zhanlan_main main = new zhanlan_main(this, id);
                            this.Hide();
                            main.Show();
                        }
                        else if (position.Replace(" ", "").Equals("通知管理员"))
                        {
                            inform_main main = new inform_main(this, id);
                            this.Hide();
                            main.Show();
                        }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgetPassword fp = new forgetPassword(this);
            fp.Show();
            this.Hide();
        }

        /*//关闭界面后退出系统，关闭数据库连接
        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }*/
    }
}
