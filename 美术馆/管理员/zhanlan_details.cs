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
        zhanlan_history main = null;
        int zno;
        public zhanlan_details(zhanlan_history main,int zno)
        {
            InitializeComponent();
            this.main = main;
            this.conn = main.conn;
            this.zno = zno;
            label2.Text = zno.ToString();
        }

        //显示展览详情
        private void zhanlan_details_Load(object sender, EventArgs e)
        {
            int n = 1;
            Panel[] p = new Panel[500];
            Label[] l3 = new Label[500];
            Label[] l4 = new Label[500];
            Label[] l5 = new Label[500];
            Label[] l6 = new Label[500];
            Label[] l7 = new Label[500];
            Label[] l8 = new Label[500];
            PictureBox[] pic = new PictureBox[500];
            string sql = "Select 展览品名称,展览品作者姓名,展览品类别,图片 from 展览品表 where 展览编号='"+zno+"'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            while (sdr.Read())
            {
                //面板
                p[n] = new Panel();
                p[n].BackColor = System.Drawing.Color.Transparent;
                p[n].Name = "panel1";
                p[n].Size = new System.Drawing.Size(130, 189);
                if(n%2==1)
                    p[n].Location = new System.Drawing.Point(22, (n - 1) / 2 * 216 + 36);
                else
                    p[n].Location = new System.Drawing.Point(177, (n - 2) / 2 * 216 + 36);
                this.Controls.Add(p[n]);
                //label3名称
                l3[n] = new Label();
                l3[n].AutoSize = true;
                l3[n].Location = new System.Drawing.Point(3, 120);
                l3[n].Name = "label3";
                l3[n].Size = new System.Drawing.Size(41, 12);
                l3[n].Text = "名称：";
                p[n].Controls.Add(l3[n]);
                //label6展览品名称
                l6[n] = new Label();
                l6[n].AutoSize = true;
                l6[n].Location = new System.Drawing.Point(45, 120);
                l6[n].Name = "label6";
                l6[n].Size = new System.Drawing.Size(89, 12);
                l6[n].Text = sdr[0].ToString();
                p[n].Controls.Add(l6[n]);
                //label4作者
                l4[n] = new Label();
                l4[n].AutoSize = true;
                l4[n].Location = new System.Drawing.Point(3, 143);
                l4[n].Name = "label4";
                l4[n].Size = new System.Drawing.Size(41, 12);
                l4[n].Text = "作者：";
                p[n].Controls.Add(l4[n]);
                //label7作者姓名
                l7[n] = new Label();
                l7[n].AutoSize = true;
                l7[n].Location = new System.Drawing.Point(45, 143);
                l7[n].Name = "label7";
                l7[n].Size = new System.Drawing.Size(41, 12);
                l7[n].Text = sdr[1].ToString();
                p[n].Controls.Add(l7[n]);
                //label5类别
                l5[n] = new Label();
                l5[n].AutoSize = true;
                l5[n].Location = new System.Drawing.Point(3, 165);
                l5[n].Name = "label5";
                l5[n].Size = new System.Drawing.Size(41, 12);
                l5[n].Text = "类别：";
                p[n].Controls.Add(l5[n]);
                //label8展览品类别
                l8[n] = new Label();
                l8[n].AutoSize = true;
                l8[n].Location = new System.Drawing.Point(45, 165);
                l8[n].Name = "label8";
                l8[n].Size = new System.Drawing.Size(41, 12);
                l8[n].Text = sdr[2].ToString();
                p[n].Controls.Add(l8[n]);
                //图片
                pic[n] = new PictureBox();
                pic[n].Location = new System.Drawing.Point(15, 11);
                pic[n].Name = "pictureBox1";
                pic[n].Size = new System.Drawing.Size(100, 97);
                pic[n].TabStop = false;
                if (sdr[3]!=null)
                {
                    MemoryStream buf = new MemoryStream((byte[])sdr[3]);
                    Image image = Image.FromStream(buf, true);
                    pic[n].Image = image;
                }
                pic[n].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                p[n].Controls.Add(pic[n]);

                n++;
            }
            sdr.Close();
        }

        private void zhanlan_details_FormClosed(object sender, FormClosedEventArgs e)
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
