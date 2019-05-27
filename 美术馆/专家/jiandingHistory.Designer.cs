namespace 美术馆.专家
{
    partial class jiandingHistory
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
            this.藏品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.藏品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.作者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创作年代 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.鉴定结果 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.鉴定价值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.鉴定备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.藏品图片 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.鉴定时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.藏品编号,
            this.藏品名称,
            this.类型,
            this.作者,
            this.创作年代,
            this.鉴定结果,
            this.鉴定价值,
            this.鉴定备注,
            this.藏品图片,
            this.鉴定时间});
            this.dataGridView1.Location = new System.Drawing.Point(22, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(843, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // 藏品编号
            // 
            this.藏品编号.HeaderText = "藏品编号";
            this.藏品编号.Name = "藏品编号";
            this.藏品编号.Width = 80;
            // 
            // 藏品名称
            // 
            this.藏品名称.HeaderText = "藏品名称";
            this.藏品名称.Name = "藏品名称";
            this.藏品名称.Width = 80;
            // 
            // 类型
            // 
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.Width = 80;
            // 
            // 作者
            // 
            this.作者.HeaderText = "作者";
            this.作者.Name = "作者";
            this.作者.Width = 80;
            // 
            // 创作年代
            // 
            this.创作年代.HeaderText = "创作年代";
            this.创作年代.Name = "创作年代";
            this.创作年代.Width = 80;
            // 
            // 鉴定结果
            // 
            this.鉴定结果.HeaderText = "鉴定结果";
            this.鉴定结果.Name = "鉴定结果";
            this.鉴定结果.Width = 80;
            // 
            // 鉴定价值
            // 
            this.鉴定价值.HeaderText = "鉴定价值";
            this.鉴定价值.Name = "鉴定价值";
            this.鉴定价值.Width = 80;
            // 
            // 鉴定备注
            // 
            this.鉴定备注.HeaderText = "鉴定备注";
            this.鉴定备注.Name = "鉴定备注";
            this.鉴定备注.Width = 80;
            // 
            // 藏品图片
            // 
            this.藏品图片.HeaderText = "藏品图片";
            this.藏品图片.Name = "藏品图片";
            this.藏品图片.Width = 80;
            // 
            // 鉴定时间
            // 
            this.鉴定时间.HeaderText = "鉴定时间";
            this.鉴定时间.Name = "鉴定时间";
            this.鉴定时间.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入藏品信息：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(215, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 28);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(626, 42);
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
            "藏品编号正序",
            "藏品编号逆序",
            "藏品类型正序",
            "藏品类型逆序",
            "作者正序",
            "作者逆序",
            "创作年代正序",
            "创作年代逆序",
            "鉴定时间正序",
            "鉴定时间逆序"});
            this.comboBox1.Location = new System.Drawing.Point(708, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // jiandingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "jiandingHistory";
            this.Text = "jiandingHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 作者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创作年代;
        private System.Windows.Forms.DataGridViewTextBoxColumn 鉴定结果;
        private System.Windows.Forms.DataGridViewTextBoxColumn 鉴定价值;
        private System.Windows.Forms.DataGridViewTextBoxColumn 鉴定备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品图片;
        private System.Windows.Forms.DataGridViewTextBoxColumn 鉴定时间;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}