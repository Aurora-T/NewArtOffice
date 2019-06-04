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
    public partial class add_old_zhanlanpn : Form
    {
        SqlConnection conn = null;
        int zl;
        zhanlan_history h = null;
        Image image = null;
        public add_old_zhanlanpn(zhanlan_history h, int zl)
        {
            InitializeComponent();
            this.h = h;
            this.conn = h.conn;
            this.zl = zl;
            label2.Text = zl.ToString();
        }

        private void add_old_zhanlanpn_FormClosed(object sender, FormClosedEventArgs e)
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
                    int ni = cmd.ExecuteNonQuery();
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
    }
}
