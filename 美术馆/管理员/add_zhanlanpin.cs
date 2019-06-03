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
    public partial class add_zhanlanpin : Form
    {
        SqlConnection conn = null;
        arrange_zhanlan zhanlan = null;
        int zl;
        Image image = null;
        public add_zhanlanpin(arrange_zhanlan zhanlan,int zl)
        {
            InitializeComponent();
            this.zhanlan = zhanlan;
            this.conn = zhanlan.conn;
            this.zl = zl;

            label8.Text = zl.ToString();

        }

        private void add_zhanlanpin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                zhanlan.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //选择导入数据的方式
        private void radiobutton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            string sql = "SELECT count(展览品编号) FROM 展览品表 where 展览编号='" + zl + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int n = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            //展厅容量
            string sql1 = "SELECT 容量 FROM 展厅信息总表,展览安排表 where 展览安排表.展厅编号=展厅信息总表.展厅编号 and 展览编号='" + zl + "'";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            sdr1.Read();
            int m = Int32.Parse(sdr1[0].ToString());
            sdr1.Close();
            if (m>n)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                MessageBox.Show("还有" + (m - n).ToString() + "个空余量");
            }
            
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                MessageBox.Show("展厅已满");
            }
        }

        //手动添加展览品
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && image != null)
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
                sp.Value = this.label8.Text;
                sp = cmd.Parameters.Add("@zname", SqlDbType.Char);
                sp.Value = this.textBox1.Text;
                sp = cmd.Parameters.Add("@name", SqlDbType.Char);
                sp.Value = this.textBox2.Text;
                sp = cmd.Parameters.Add("@type", SqlDbType.Char);
                sp.Value = this.textBox3.Text;
                sp = cmd.Parameters.Add("@tel", SqlDbType.Char);
                sp.Value = this.textBox5.Text;
                //执行insert语句
                int ni = cmd.ExecuteNonQuery();
                if (ni > 0)
                    MessageBox.Show("添加成功");
            }
            else if (image == null)
                MessageBox.Show("请先上传图片");
            else
                MessageBox.Show("内容不能为空");
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT count(展览品编号) FROM 展览品表 where 展览编号='" + zl + "'";
            SqlCommand Cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = Cmd.ExecuteReader();
            sdr.Read();
            int n = Int32.Parse(sdr[0].ToString());
            sdr.Close();
            //展厅容量
            string sql1 = "SELECT 容量 FROM 展厅信息总表,展览安排表 where 展览安排表.展厅编号=展厅信息总表.展厅编号 and 展览编号='" + zl + "'";
            SqlCommand Cmd1 = new SqlCommand(sql1, conn);
            SqlDataReader sdr1 = Cmd1.ExecuteReader();
            sdr1.Read();
            int m = Int32.Parse(sdr1[0].ToString());
            sdr1.Close();

            if ( m > n)
            {
                label1.Text = "cv";
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                MessageBox.Show("还有" + (m - n).ToString() + "个空余量");
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                MessageBox.Show("展厅已满");
            }
        }
    }
}
