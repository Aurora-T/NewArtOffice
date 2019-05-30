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
    public partial class index : Form
    {
        public SqlConnection conn = null;
        private int id;
        public loginForm l = null;
        public index(loginForm l,int id)
        {
            InitializeComponent();
            this.l = l;
            this.conn = l.conn;
            this.id = id;
        }
        //分配鉴定
        private void button1_Click(object sender, EventArgs e)
        {
            cangpinjianding jianding = new cangpinjianding(this,this.id);
            this.Hide();
            jianding.Show();
        }

        //分配检查
        private void button2_Click(object sender, EventArgs e)
        {
            cangpinjiancha jiancha = new cangpinjiancha(this);
            this.Hide();
            jiancha.Show();
        }
        //分配修复
        private void button3_Click(object sender, EventArgs e)
        {
            cangpinxiufu jiancha = new cangpinxiufu(this);
            this.Hide();
            jiancha.Show();
        }

        //入馆
        private void button4_Click(object sender, EventArgs e)
        {
            enter ruguan = new enter(this, this.id);
            this.Hide();
            ruguan.Show();
        }

        //出馆
        private void button5_Click(object sender, EventArgs e)
        {
            exit chuguan = new exit(this, this.id);
            this.Hide();
            chuguan.Show();
        }

        //点击按钮退出系统，关闭数据库连接
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                l.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        //点击叉号后关闭界面，退回到登录界面
        void administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.l.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }

        }
    }
}
