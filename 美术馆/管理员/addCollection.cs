﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 美术馆.管理员
{
    public partial class addCollection : Form
    {
        SqlConnection conn = null;
        cangpinjianding page;
        Image image = null;
        public addCollection(cangpinjianding l)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price;
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("藏品名称未填写", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("理想价格未填写", "提示");
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("联系人姓名未填写", "提示");
            }
            else if (textBox4.Text.Equals(""))
            {
                MessageBox.Show("联系人电话未填写", "提示");
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
            {
                MessageBox.Show("藏品类型未填写", "提示");
            }
            else if (!double.TryParse(textBox2.Text, out price))
            {
                MessageBox.Show("理想价格格式错误", "提示");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"^[1]+[3,5,7,8]+\d{9}"))
            {
                MessageBox.Show("联系电话格式错误", "提示");
            }
            else
            {
                string type = "";
                if (radioButton1.Checked)
                {
                    type = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    type = radioButton2.Text;
                }
                else if (radioButton3.Checked)
                {
                    type = radioButton3.Text;
                }
                else if (radioButton4.Checked)
                {
                    type = radioButton4.Text;
                }
                else if (radioButton5.Checked)
                {
                    type = radioButton5.Text;
                }
                SqlCommand cmd = null;
                if (image != null)
                {
                    cmd= new SqlCommand("insert into 征集表(藏品名称,类别,作者,创作年代,理想价格,联系人姓名,联系方式,备注,藏品图片) values('" + textBox1.Text + "','" + type + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "',@picture)", conn);
                    MemoryStream mstream = new MemoryStream();
                    image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteData = new Byte[mstream.Length];
                    mstream.Position = 0;
                    mstream.Read(byteData, 0, byteData.Length);
                    mstream.Close();
                    SqlParameter param = new SqlParameter("@picture", SqlDbType.VarBinary, byteData.Length);
                    param.Value = byteData;
                    cmd.Parameters.Add(param);
                }
                else
                    cmd = new SqlCommand("insert into 征集表(藏品名称,类别,作者,创作年代,理想价格,联系人姓名,联系方式,备注) values('" + textBox1.Text + "','" + type + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "')", conn);                
                cmd.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                this.Hide();
                this.page.Show();
                this.page.save();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = this.openFileDialog1.FileName;
                image = Image.FromFile(path);
                MessageBox.Show("图片上传成功！");
            }
        }
    }
}
