namespace 美术馆.管理员
{
    partial class exit
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.藏品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.藏品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.作品作者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创作年代 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.鉴定价值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.藏品图片 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入藏品信息：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 28);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.藏品编号,
            this.藏品名称,
            this.类型,
            this.作品作者,
            this.创作年代,
            this.鉴定价值,
            this.藏品图片,
            this.状态});
            this.dataGridView1.Location = new System.Drawing.Point(21, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(683, 460);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "赠送";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(785, 485);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "外借";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--请选择--",
            "藏品编号正序",
            "藏品编号逆序",
            "创作年代正序",
            "创作年代逆序",
            "鉴定价值正序",
            "鉴定价值逆序"});
            this.comboBox1.Location = new System.Drawing.Point(498, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "排序：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(329, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 28);
            this.button4.TabIndex = 8;
            this.button4.Text = "搜索";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(720, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 173);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选定藏品简介：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 146);
            this.label5.TabIndex = 0;
            this.label5.Text = "label5";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(720, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 136);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请选择美术馆：";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(74, 90);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 28);
            this.button5.TabIndex = 2;
            this.button5.Text = "添加美术馆";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "中国美术馆",
            "北京美术馆",
            "上海美术馆",
            "杭州美术馆",
            "天津美术馆",
            "山东美术馆"});
            this.comboBox2.Location = new System.Drawing.Point(28, 45);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(217, 26);
            this.comboBox2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 0;
            // 
            // 藏品编号
            // 
            this.藏品编号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.藏品编号.HeaderText = "藏品编号";
            this.藏品编号.Name = "藏品编号";
            this.藏品编号.Width = 80;
            // 
            // 藏品名称
            // 
            this.藏品名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.藏品名称.HeaderText = "藏品名称";
            this.藏品名称.Name = "藏品名称";
            this.藏品名称.Width = 80;
            // 
            // 类型
            // 
            this.类型.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.Width = 80;
            // 
            // 作品作者
            // 
            this.作品作者.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.作品作者.HeaderText = "作品作者";
            this.作品作者.Name = "作品作者";
            this.作品作者.Width = 80;
            // 
            // 创作年代
            // 
            this.创作年代.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.创作年代.HeaderText = "创作年代";
            this.创作年代.Name = "创作年代";
            this.创作年代.Width = 80;
            // 
            // 鉴定价值
            // 
            this.鉴定价值.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.鉴定价值.HeaderText = "鉴定价值";
            this.鉴定价值.Name = "鉴定价值";
            this.鉴定价值.Width = 80;
            // 
            // 藏品图片
            // 
            this.藏品图片.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.藏品图片.HeaderText = "藏品图片";
            this.藏品图片.Name = "藏品图片";
            this.藏品图片.Width = 80;
            // 
            // 状态
            // 
            this.状态.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            this.状态.Width = 80;
            // 
            // exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "exit";
            this.Text = "exit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 作品作者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创作年代;
        private System.Windows.Forms.DataGridViewTextBoxColumn 鉴定价值;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品图片;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
    }
}