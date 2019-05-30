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
    public partial class yuyue_record : Form
    {
        SqlConnection conn = null;
        piaowu_main main = null;
        int id;
        public yuyue_record(piaowu_main main)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.id = main.id;
        }

        private void yuyue_record_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
