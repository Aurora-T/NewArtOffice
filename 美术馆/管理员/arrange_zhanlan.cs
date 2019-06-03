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
    public partial class arrange_zhanlan : Form
    {
        SqlConnection conn = null;
        zhanlan_main main = null;
        int id,zl;
        public arrange_zhanlan(zhanlan_main  main)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.id = main.id;
            label2.Text = id.ToString();
        }

        //添加展览品
        private void button2_Click(object sender, EventArgs e)
        {
            //将刚安排的展览编号传给添加展览品
            add_zhanlanpin add = new add_zhanlanpin(this,zl);
            this.Hide();
            add.Show();
        }

        //确定安排展览
        private void button1_Click(object sender, EventArgs e)
        {

            //安排展览后再添加展览品
            button2.Enabled = true;
        }

        //选择展厅
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int zt;
            if (this.dataGridView1.CurrentRow != null)
            {      
                zt = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                label5.Text = zt.ToString();
            }
            else
                MessageBox.Show("未选中");
        }
    }
}
