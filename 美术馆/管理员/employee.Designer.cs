namespace 美术馆.管理员
{
    partial class employee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.员工工号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年龄 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.职位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.权限 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.员工工号,
            this.姓名,
            this.性别,
            this.年龄,
            this.职位,
            this.权限,
            this.身份证号码});
            this.dataGridView1.Location = new System.Drawing.Point(32, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(709, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // 员工工号
            // 
            this.员工工号.HeaderText = "员工工号";
            this.员工工号.Name = "员工工号";
            this.员工工号.Width = 95;
            // 
            // 姓名
            // 
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.Width = 95;
            // 
            // 性别
            // 
            this.性别.HeaderText = "性别";
            this.性别.Name = "性别";
            this.性别.Width = 95;
            // 
            // 年龄
            // 
            this.年龄.HeaderText = "年龄";
            this.年龄.Name = "年龄";
            this.年龄.Width = 95;
            // 
            // 职位
            // 
            this.职位.HeaderText = "职位";
            this.职位.Name = "职位";
            this.职位.Width = 95;
            // 
            // 权限
            // 
            this.权限.HeaderText = "权限";
            this.权限.Name = "权限";
            this.权限.Width = 95;
            // 
            // 身份证号码
            // 
            this.身份证号码.HeaderText = "身份证号码";
            this.身份证号码.Name = "身份证号码";
            this.身份证号码.Width = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入员工信息：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(201, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 28);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "排序：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--请选择--",
            "员工工号正序",
            "员工工号逆序",
            "姓名正序",
            "姓名逆序",
            "年龄正序",
            "年龄逆序",
            "职位正序",
            "职位逆序",
            "权限正序",
            "权限逆序"});
            this.comboBox1.Location = new System.Drawing.Point(587, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(784, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "添加员工";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(784, 293);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "修改权限";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(755, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 201);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已选择员工：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 5;
            this.label8.Text = "？？？";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "职位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "***";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "？？？";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "员工工号：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(784, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 28);
            this.button4.TabIndex = 9;
            this.button4.Text = "删除员工";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "employee";
            this.Text = "employee";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 员工工号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年龄;
        private System.Windows.Forms.DataGridViewTextBoxColumn 职位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 权限;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身份证号码;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
    }
}