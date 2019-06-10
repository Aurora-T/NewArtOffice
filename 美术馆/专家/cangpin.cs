using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 美术馆.专家
{
    public partial class cangpin : Form
    {
        SqlConnection conn = null;
        int cno;
        public cangpin(SqlConnection conn,int cno)
        {
            InitializeComponent();
            this.conn = conn;
            this.cno = cno;

            //藏品信息
            string sql = "SELECT 藏品编号,藏品名称,藏品类型,作者姓名,创作时间,图片 FROM 藏品表 where 藏品编号 ='" + cno + "' ";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            label9.Text = sdr[0].ToString();
            label11.Text = sdr[1].ToString();
            label6.Text = sdr[2].ToString();
            label8.Text = sdr[3].ToString();
            label4.Text = sdr[4].ToString();
            if (sdr[5] != DBNull.Value)
            {
                MemoryStream buf = new MemoryStream((byte[])sdr[5]);
                Image image = Image.FromStream(buf, true);
                pictureBox1.Image = image;
            }
            sdr.Close();
        }
    }
}
