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
    public partial class employee : Form
    {
        public SqlConnection conn = null;
        Personnel_main page;
        int userid;
        int stid;
        public employee(Personnel_main l, int id)
        {
            InitializeComponent();
            this.conn = l.conn;
            this.page = l;
            this.userid = id;
            save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            if (text.Equals(""))
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            else
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where charindex('" + text+ "',姓名)>0 or charindex(姓名,'" + text + "')>0 order by 工号";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
            }
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
            comboBox1.Text = "--请选择--";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = comboBox1.Text;
            textBox1.Text = "";
            if (text == "专家")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='专家' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "藏品管理员")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='藏品管理员' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "人事管理员")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='人事管理员' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "展览管理员")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='展览管理员' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "票务管理员")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='票务管理员' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "通知管理员")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='通知管理员' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (text == "财务管理员")
            {
                String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 where 职位='财务管理员' order by 工号";
                SqlCommand sc = new SqlCommand(sql, conn);
                SqlDataAdapter myda = new SqlDataAdapter(sc);
                DataTable dt = new DataTable();
                myda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                save();
            }
            dataGridView1.ClearSelection();
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                modifyEmployee moEm = new modifyEmployee(this, this.stid, this.userid);
                this.Hide();
                moEm.Show();
            }
            else
            {
                MessageBox.Show("未选择员工", "提示");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                DialogResult result=MessageBox.Show("确认删除吗", "提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("delete from 员工信息表  where 工号='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("删除成功", "提示");
                    save();
                }

            }
            else
            {
                MessageBox.Show("未选择员工", "提示");
            }
        }
        public void save()
        {
            String sql = "select 工号,姓名,性别,datediff(year,substring(身份证号,7,4),getdate()) 年龄,职位,入职时间 from 员工信息表 order by 工号";
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataAdapter myda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            myda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            label4.Text = "";
            label6.Text = "";
            label8.Text = "";
        }

        private void employee_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count != 0)
            {
                int intRow = dataGridView1.SelectedCells[0].RowIndex;
                //得到选中行某列的值
                string str = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (str != "")
                {
                    this.stid = Int32.Parse(str);
                    label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    label6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    label8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.page.Show();
        }
    }
}
