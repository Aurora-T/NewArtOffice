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
    public partial class mgoodAt : Form
    {
        SqlConnection conn = null;
        modifyEmployee page;
        public mgoodAt(modifyEmployee page)
        {
            InitializeComponent();
            this.conn = page.conn;
            this.page = page;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("请选择专家擅长领域", "提示");
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("update 专家表 set 擅长领域 ='" + comboBox1.Text + "' where 擅长领域 is NULL", conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("添加成功", "提示");
                this.Hide();
                this.page.page.Show();
                this.page.page.save();
            }
        }
    }
}
