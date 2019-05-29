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
    public partial class enterDetail : Form
    {
        public SqlConnection conn = null;
        private int userid;
        private int cid;
        private enter page;
        public enterDetail(enter l,int id,int userid)
        {
            InitializeComponent();
            this.page = l;
            this.conn = l.conn;
            this.userid = userid;
            this.cid = id;
            String sql = "select 专家工号,专家表.姓名,鉴定结果,鉴定价值,备注 from 鉴定表,专家表 where 鉴定表.专家工号=专家表.专家编号 and 鉴定表.藏品编号='"+this.cid+"'";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            string sql1 = "SELECT count(*),理想价格 from 征集表 left join 鉴定表 on 鉴定表.藏品编号=征集表.编号 where 鉴定结果='真' and 征集表.编号='" + id + "'group by 理想价格";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            label2.Text = this.cid.ToString();
            if (sdr.HasRows == false)
            {
                label8.Text = "0";
            }
            else
            {
                label8.Text = sdr[0].ToString();
            }
            sdr.Close();
            string sql2 = "SELECT count(*),理想价格 from 鉴定表,征集表 where 鉴定表.藏品编号=征集表.编号 and 鉴定结果='假' and 征集表.编号='" + id + "'group by 理想价格";
            SqlCommand cmd1 = new SqlCommand(sql2, conn);
            cmd1.CommandType = CommandType.Text;
            SqlDataReader sdr1;
            sdr1 = cmd1.ExecuteReader();
            sdr1.Read();
            if (sdr1.HasRows == false)
            {
                label10.Text = "0";
            }
            else
            {
                label10.Text = sdr1[0].ToString();
            }
            sdr1.Close();
        }

        private void button1_Click(object sender, EventArgs e)//入馆
        {
            confirmEnter ce = new confirmEnter(this,this.cid,this.userid);
            ce.ShowDialog();    
        }

        private void button2_Click(object sender, EventArgs e)//退回
        {
            SqlCommand cmd1 = new SqlCommand("update 征集表 set 状态='退回' where 编号='" + this.cid + "'", conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("提交成功", "提示");
            this.Close();
            this.page.Show();
            this.page.save();
        }

        private void button3_Click(object sender, EventArgs e)//重新鉴定
        {
            SqlCommand cmd1 = new SqlCommand("update 征集表 set 状态='未匹配' where 编号='" + this.cid + "'", conn);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("提交成功", "提示");
            this.Close();
            this.page.Show();
            this.page.save();
        }
        public void save()
        {
            this.Close();
            this.page.Show();
            this.page.save();
        }
    }
}
