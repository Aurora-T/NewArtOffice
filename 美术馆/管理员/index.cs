﻿using System;
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
        public index(loginForm l,int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.id = id;
        }
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

        private void button3_Click(object sender, EventArgs e)
        {
            cangpinxiufu jiancha = new cangpinxiufu(this);
            this.Hide();
            jiancha.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enter ruguan = new enter(this, this.id);
            this.Hide();
            ruguan.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exit chuguan = new exit(this, this.id);
            this.Hide();
            chuguan.Show();
        }
    }
}
