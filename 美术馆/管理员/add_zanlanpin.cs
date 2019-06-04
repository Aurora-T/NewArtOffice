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
    public partial class add_zanlanpin : Form
    {
        SqlConnection conn = null;
        int zl;
        arrange_zhanlan a = null;
        Image image = null;
        public add_zanlanpin(arrange_zhanlan a,int zl)
        {
            InitializeComponent();
            this.a = a;
            this.conn = a.conn;
            this.zl = zl;
            this.label2.Text = zl.ToString();
        }

        private void add_zanlanpin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        //文件导入
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            //已有展览品
            string sql = "SELECT count(展览品编号) FROM 展览品表 where 展览编号='" + zl + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int n = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            //展厅容量           
            string sql1 = "SELECT 容量 FROM 展厅信息总表 where 展厅编号 =(select 展厅编号 from 展览安排表 where 展览编号='" + zl + "')";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            sdr1.Read();
            int m = Int32.Parse(sdr1[0].ToString());
            sdr1.Close();
            if (m == n)
                MessageBox.Show("展厅已满");
            else
            {
                MessageBox.Show("还有" + (m - n).ToString() + "个空余");
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
        }

        //输入
        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            //已有展览品
            string sql = "SELECT count(展览品编号) FROM 展览品表 where 展览编号='" + zl + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int n = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            //展厅容量           
            string sql1 = "SELECT 容量 FROM 展厅信息总表 where 展厅编号 =(select 展厅编号 from 展览安排表 where 展览编号='" + zl + "')";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            sdr1.Read();
            int m = Int32.Parse(sdr1[0].ToString());
            sdr1.Close();
            if (m == n)
                MessageBox.Show("展厅已满");
            else
            {
                MessageBox.Show("还有" + (m - n).ToString()+ "个空余");
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
        }

        //上传图片
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                image = Image.FromFile(path);
            }
        }

        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && image != null)
            {
                try
                {
                    string sql = "Insert Into 展览品表(展览编号,展览品名称,展览品作者姓名,展览品类别,联系方式,图片) Values (@zl,@zname,@name,@type,@tel,@Picture)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    //插入图片
                    MemoryStream mstream = new MemoryStream();
                    image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteData = new Byte[mstream.Length];
                    mstream.Position = 0;
                    mstream.Read(byteData, 0, byteData.Length);
                    mstream.Close();
                    SqlParameter param = new SqlParameter("@Picture", SqlDbType.VarBinary, byteData.Length);
                    param.Value = byteData;
                    cmd.Parameters.Add(param);
                    //插入其他数据
                    SqlParameter sp = cmd.Parameters.Add("@zl", SqlDbType.Int);
                    sp.Value = this.zl;
                    sp = cmd.Parameters.Add("@zname", SqlDbType.Char);
                    sp.Value = this.textBox1.Text;
                    sp = cmd.Parameters.Add("@name", SqlDbType.Char);
                    sp.Value = this.textBox2.Text;
                    sp = cmd.Parameters.Add("@type", SqlDbType.Char);
                    sp.Value = this.textBox3.Text;
                    sp = cmd.Parameters.Add("@tel", SqlDbType.Char);
                    sp.Value = this.textBox4.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            else if (image == null)
                MessageBox.Show("请上传图片");
            else
                MessageBox.Show("内容不能为空");
        }

        //导入Excel文件
        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "server = (local); uid = sa; pwd = sa; database = db_test";
            System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                TransferData(fd.FileName, "student", connString);
            }
        }
    }
}
