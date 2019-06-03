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
    public partial class Personnel_main : Form
    {
        public SqlConnection conn = null;
        private int id;
        public loginForm l = null;
        public Personnel_main(loginForm l, int id)
        {
            InitializeComponent();
            this.l = l;
            this.conn = l.conn;
            this.id = id;
            label2.Text = id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEmployee addEm = new addEmployee(this, this.id);
            this.Hide();
            addEm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee emp = new employee(this, this.id);
            this.Hide();
            emp.Show();
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeInformationp change = new changeInformationp(this, this.id);
            this.Hide();
            change.Show();
        }

        private void 修改密保问题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeQuestionp change = new changeQuestionp(this, this.id);
            this.Hide();
            change.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePasswordp change = new changePasswordp(this, this.id);
            this.Hide();
            change.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                l.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }
    }
}
