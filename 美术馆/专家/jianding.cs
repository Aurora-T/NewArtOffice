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

namespace 美术馆.专家
{
    public partial class jianding : Form
    {
        public SqlConnection conn = null;
        public int userid;
        public expert_main l = null;
        public jianding(expert_main l,int userid)
        {
            InitializeComponent();
            this.l = l;
            this.userid = userid;
            this.conn = l.conn;
            save();
        }

        private void jianding_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
        public void save()
        {
            String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='"+sdr[0].ToString()+ "' and 鉴定结果 is NULL order by 征集时间";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sdr.Close();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            label5.Text = "";
            label3.Text = "";
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            int n;
            if (text.Equals(""))
            {
                save();
            }
            else
            {
                if (!int.TryParse(text, out n))
                {
                    MessageBox.Show("请搜索输入纯数字");
                }
                else
                {
                    String sql1 = "select 专家编号 from 专家表 where 工号='" + this.userid + "'";
                    SqlCommand cmd = new SqlCommand(sql1, conn);
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    sdr.Read();
                    String sql = "select 鉴定表.藏品编号,征集表.藏品名称,类别,作者,创作年代,征集时间 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 专家工号='" + sdr[0].ToString() + "' and 鉴定结果 is NULL and 鉴定表.藏品编号='" + text + "'";
                    SqlCommand sc = new SqlCommand(sql, conn);
                    SqlDataAdapter myda = new SqlDataAdapter(sc);
                    DataTable dt = new DataTable();
                    sdr.Close();
                    myda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            label5.Text = "";
            label3.Text = "";
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;
                //得到选中行某列的值
                string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String sql = "select 备注 from 征集表 where 编号 ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                if (str != "")
                {
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    sdr.Read();
                    label5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    label3.Text = sdr[0].ToString();
                    sdr.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                jiandingDetail jd = new jiandingDetail(this, id, this.userid);
                this.Hide();
                jd.Show();
            }
            else
            {
                MessageBox.Show("未选择藏品", "提示");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jiandingHistory jh = new jiandingHistory(this, this.userid);
            this.Hide();
            jh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.l.Show();
        }
    }
}
