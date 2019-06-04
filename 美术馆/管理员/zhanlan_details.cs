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

namespace 美术馆.管理员
{
    public partial class zhanlan_details : Form
    {
        SqlConnection conn = null;
        zhanlan_history h = null;
        int zl;
        public zhanlan_details(zhanlan_history h, int zl)
        {
            InitializeComponent();
            this.h = h;
            this.conn = h.conn;
            this.zl = zl;
            label2.Text = zl.ToString();
        }

        private void zhanlan_details_Load(object sender, EventArgs e)
        {
            Panel[] p = new Panel[500];
            Label[] l3 = new Label[500];
            Label[] l4 = new Label[500];
            Label[] l5 = new Label[500];
            Label[] l6 = new Label[500];
            Label[] l7 = new Label[500];
            Label[] l8 = new Label[500];
            Label[] l9 = new Label[500];
            Label[] l10 = new Label[500];
            int n = 1;
            PictureBox[] picture = new PictureBox[500];
            string sql = "Select 展览品名称,展览品作者姓名,展览品类别,联系方式,图片 from 展览品表 where 展览编号='"+zl+"'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                //面板
                p[n] = new Panel();
                p[n].Size = new System.Drawing.Size(145, 197);
                if (n % 2 == 1)
                    p[n].Location = new System.Drawing.Point(13, (n - 1) / 2 * 224 + 41);
                else
                    p[n].Location = new System.Drawing.Point(188, (n - 2) / 2 * 224 + 41);
                this.Controls.Add(p[n]);
                //label3
                l3[n] = new Label();
                l3[n].AutoSize = true;
                l3[n].Location = new System.Drawing.Point(4, 110);
                l3[n].Size = new System.Drawing.Size(41, 12);
                l3[n].Text = "名称：";
                p[n].Controls.Add(l3[n]);
                //label4
                l4[n] = new Label();
                l4[n].AutoSize = true;
                l4[n].Location = new System.Drawing.Point(51, 110);
                l4[n].Size = new System.Drawing.Size(41, 12);
                l4[n].Text = sdr[0].ToString();
                p[n].Controls.Add(l4[n]);
                //label5
                l5[n] = new Label();
                l5[n].AutoSize = true;
                l5[n].Location = new System.Drawing.Point(3, 131);
                l5[n].Size = new System.Drawing.Size(89, 12);
                l5[n].Text = "作者或负责人：";
                p[n].Controls.Add(l5[n]);
                //label6
                l6[n] = new Label();
                l6[n].AutoSize = true;
                l6[n].Location = new System.Drawing.Point(95, 131);
                l6[n].Size = new System.Drawing.Size(41, 12);
                l6[n].Text = sdr[1].ToString();
                p[n].Controls.Add(l6[n]);
                //label7
                l7[n] = new Label();
                l7[n].AutoSize = true;
                l7[n].Location = new System.Drawing.Point(4, 152);
                l7[n].Size = new System.Drawing.Size(41, 12);
                l7[n].Text = "类别：";
                p[n].Controls.Add(l7[n]);
                //label8
                l8[n] = new Label();
                l8[n].AutoSize = true;
                l8[n].Location = new System.Drawing.Point(51, 152);
                l8[n].Size = new System.Drawing.Size(41, 12);
                l8[n].Text = sdr[2].ToString();
                p[n].Controls.Add(l8[n]);
                //label9
                l9[n] = new Label();
                l9[n].AutoSize = true;
                l9[n].Location = new System.Drawing.Point(3, 174);
                l9[n].Size = new System.Drawing.Size(65, 12);
                l9[n].Text = "联系方式：";
                p[n].Controls.Add(l9[n]);
                //label10
                l10[n] = new Label();
                l10[n].AutoSize = true;
                l10[n].Location = new System.Drawing.Point(68, 174);
                l10[n].Size = new System.Drawing.Size(47, 12);
                l10[n].Text = sdr[3].ToString();
                p[n].Controls.Add(l10[n]);
                //图片
                picture[n] = new PictureBox();
                picture[n].Location = new System.Drawing.Point(15, 11);
                picture[n].Size = new System.Drawing.Size(112, 96);
                picture[n].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                picture[n].TabStop = false;
                if (sdr[4] != DBNull.Value)
                {
                    MemoryStream buf = new MemoryStream((byte[])sdr[4]);
                    Image image = Image.FromStream(buf, true);
                    picture[n].Image = image;
                }
                p[n].Controls.Add(picture[n]);

                n++;
            }
            sdr.Close();
        }

        private void zhanlan_details_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.h.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }
    }
}
