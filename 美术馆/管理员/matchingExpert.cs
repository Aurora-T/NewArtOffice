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
    public partial class matchingExpert : Form
    {
        SqlConnection conn = null;
        cangpinjianding page;
        int collectid;
        int id;
        public matchingExpert(cangpinjianding l,int id,int userid)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.collectid = id;
            this.id = userid;
            String sql = "select 类别,藏品名称,理想价格 from 征集表 where 编号='"+id+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            label2.Text = sdr[1].ToString();
            label6.Text = sdr[0].ToString();
            label4.Text = sdr[2].ToString();
            String sqll = "select 专家表.工号,专家表.姓名,专家表.擅长领域,count(*) 待鉴定藏品数 from 专家表 left join 鉴定表 on 专家表.专家编号=鉴定表.专家工号  where CHARINDEX('" + sdr[0].ToString() + "',专家表.擅长领域)>=0 and 鉴定表.鉴定结果 is NULL  group by 专家表.工号 ,专家表.姓名,专家表.擅长领域";
            SqlCommand sc = new SqlCommand(sqll, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sdr.Close();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            //得到选中行某列的值
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)//添加
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dataGridView2.Rows[index].Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dataGridView2.Rows[index].Cells[2].Value = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dataGridView2.Rows[index].Cells[3].Value = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                dataGridView2.ClearSelection();
                dataGridView1.ClearSelection();
            }
        }

        private void button2_Click(object sender, EventArgs e)//移除
        {
            if (dataGridView2.SelectedCells.Count != 0)
            {
                int intRow = dataGridView2.SelectedCells[0].RowIndex;
                //得到选中行某列的值
                string[] strArray = { dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString(), dataGridView2.CurrentRow.Cells[2].Value.ToString(), dataGridView2.CurrentRow.Cells[3].Value.ToString() };
                ((DataTable)dataGridView1.DataSource).Rows.Add(strArray);
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = dataGridView2.RowCount;
            for(int i = 0; i < row-1; i++)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                dataGridView2.Rows[index].Cells[1].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dataGridView2.Rows[index].Cells[2].Value = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dataGridView2.Rows[index].Cells[3].Value = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                dataGridView2.ClearSelection();
                dataGridView1.ClearSelection();
                //string[] strArray = { dataGridView2.Rows[i].Cells[0].Value.ToString(), dataGridView2.Rows[i].Cells[1].Value.ToString(), dataGridView2.Rows[i].Cells[2].Value.ToString(), dataGridView2.Rows[i].Cells[3].Value.ToString() };
                //((DataTable)dataGridView1.DataSource).Rows.Add(strArray);
                //dataGridView2.Rows.RemoveAt(dataGridView2.Rows[i].Index);
            }
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView2.RowCount;
            if ((row - 1) == 0)
            {
                MessageBox.Show("未添加专家匹配", "提示");
            }
            else
            {
                for (int i = 0; i < row - 1; i++)
                {
                    String sql = "select 专家编号 from 专家表 where 工号='" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "'";
                    SqlCommand cm = new SqlCommand(sql, conn);
                    cm.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cm.ExecuteReader();
                    sdr.Read();
                    SqlCommand cmd = new SqlCommand("insert into 鉴定表(专家工号,藏品编号,管理员工号) values('" + sdr[0].ToString() + "','" + this.collectid + "','" + this.id  + "')", conn);
                    sdr.Close();
                    cmd.ExecuteNonQuery();
                    dataGridView2.Rows.RemoveAt(dataGridView2.Rows[i].Index);
                }
                SqlCommand cmdd = new SqlCommand("update 征集表 set 状态='已匹配' where 编号= '" + this.collectid+"'", conn);
                cmdd.ExecuteNonQuery();
                MessageBox.Show("提交成功", "提示");
                this.Close();
                this.page.Show();
                this.page.save();
            }
        }
    }
}
