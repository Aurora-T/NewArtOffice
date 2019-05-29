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
    public partial class arrange_jianchaexpert : Form
    {
        SqlConnection conn = null;
        int cno;
        int jno;
        public arrange_jianchaexpert(SqlConnection conn,int cno,int jno)
        {
            InitializeComponent();
            this.conn = conn;
            this.cno = cno;
            this.jno = jno;
        }

        //显示选定藏品信息及专家信息
        private void arrange_expert_Load(object sender, EventArgs e)
        {
            //藏品信息
            string sql = "SELECT 藏品编号,藏品名称,类型,风格,作者姓名,创作时间 FROM 藏品表 where 藏品编号 ='"+ cno+"' ";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            label9.Text = sdr[0].ToString();
            label11.Text = sdr[1].ToString();
            label6.Text = sdr[2].ToString();
            label13.Text = sdr[3].ToString();
            label4.Text = sdr[5].ToString();
            label8.Text = sdr[4].ToString();
            sdr.Close();

            //专家信息
            //清空原datagridview中的数据
            this.dataGridView1.Rows.Clear();
            //从数据库查询专家信息
            string sql1 = "SELECT 专家编号,工号,姓名,擅长领域 FROM 专家表 ";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            while (sdr1.Read())
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sdr1[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = sdr1[1].ToString();
                this.dataGridView1.Rows[index].Cells[2].Value = sdr1[2].ToString();
                this.dataGridView1.Rows[index].Cells[3].Value = sdr1[3].ToString();
            }
            sdr1.Close();
        }

        //将选中的专家进行匹配
        private void button1_Click(object sender, EventArgs e)
        {
            
            //曾被检查过,检查表里已有藏品编号和应该检查时间，更新数据
            if (jno!=-1)
            {
                int eno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string sql = "update 检查表(专家编号) Values (@eno) where 检查记录编号='"+jno+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@cno", SqlDbType.Int);
                sp.Value = this.cno;
                sp = cmd.Parameters.Add("@eno", SqlDbType.Int);
                sp.Value = eno;
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("分配成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("未成功，请重新分配");
                }
            }
            //从未被检查过，插入检查记录
            else
            {
                int eno = Int32.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string sql = "Insert Into 检查表(藏品编号,专家编号) Values (@cno,@eno)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter sp = cmd.Parameters.Add("@cno", SqlDbType.Int);
                sp.Value = this.cno;
                sp = cmd.Parameters.Add("@eno", SqlDbType.Int);
                sp.Value = eno;
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("分配成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("未成功，请重新分配");
                }
            }
        }
    }
}
