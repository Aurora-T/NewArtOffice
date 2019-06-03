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
    public partial class addGallery : Form
    {
        public SqlConnection conn = null;
        exit page;
        public addGallery(exit l)
        {
            InitializeComponent();
            this.page = l;
            this.conn = l.conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("美术馆名称未填写", "提示");
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("美术馆地址未填写", "提示");
            }
            else if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("美术馆邮政编码未填写", "提示");
            }
            else if (radioButton1.Checked==false && radioButton2.Checked==false)
            {
                MessageBox.Show("美术馆类型未选择", "提示");
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
                SqlCommand cmd = new SqlCommand("insert into 美术馆表(名称,地址,邮政编码,类型) values('" + textBox1.Text + "','" +  textBox2.Text + "','" + textBox3.Text + "','" + type  + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                this.Hide();
                this.page.Show();
                this.page.load_gallery();
            }
        }
    }
}
