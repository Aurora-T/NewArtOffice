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
        public matchingExpert(cangpinjianding l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.collectid = id;
            String sql = "select 类别 from 征集表 where 编号='"+id+"'";
            SqlCommand cmd = new SqlCommand(sql, this.conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            String sqll = "select 工号,姓名,擅长领域,count(*) 待鉴定藏品数 from 专家表,鉴定表 where 专家表.工号=鉴定表.专家工号 and CHARINDEX(擅长领域'"+sdr[0].ToString()+ "')>=0 and 鉴定结果=NULL group by 专家表.工号,姓名,擅长领域";
            SqlCommand sc = new SqlCommand(sqll, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sdr.Close();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            //得到选中行某列的值
            dataGridView1.ClearSelection();
            
        }
    }
}
