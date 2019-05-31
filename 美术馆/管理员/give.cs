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
    public partial class give : Form
    {
        public SqlConnection conn = null;
        private int userid;
        private int cid;
        exit page;
        public give(exit l, int id, int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.userid = userid;
            this.page = l;
            this.cid = id;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into 出馆表(藏品编号,操作员工号,来源详情,价值) values('" + this.cid + "','" + this.userid + "','" + textBox2.Text + "','" + textBox1.Text + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("提交成功", "提示");
            this.Close();
        }
    }
}
