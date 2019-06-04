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

namespace 美术馆.通知管理员
{
    public partial class inform_main : Form
    {
        public SqlConnection conn = null;
        private int id;
        public loginForm page = null;
        public inform_main(loginForm l, int id)
        {
            InitializeComponent();
            this.page = l;
            this.conn = l.conn;
            this.id = id;
            label2.Text = id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inform inf = new inform(this, this.id);
            this.Hide();
            inf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            complaints com = new complaints(this, this.id);
            this.Hide();
            com.Show();
        }
        void administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.page.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }

        }
    }
}
