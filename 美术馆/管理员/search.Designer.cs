namespace 美术馆.管理员
{
    partial class search
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.藏品编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.藏品名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.作者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.创作年代 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.楼层 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.区域 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.藏品图片 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.楼层,
            this.区域,
            this.藏品图片,
            this.备注,
            this.状态});
            this.dataGridView1.Location = new System.Drawing.Point(37, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(954, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入藏品信息：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 28);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "排序：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(662, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(841, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Excel导出";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // 藏品编号
            // 
            this.藏品编号.HeaderText = "藏品编号";
            this.藏品编号.Name = "藏品编号";
            this.藏品编号.Width = 90;
            // 
            // 藏品名称
            // 
            this.藏品名称.HeaderText = "藏品名称";
            this.藏品名称.Name = "藏品名称";
            this.藏品名称.Width = 90;
            // 
            // 类型
            // 
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.Width = 90;
            // 
            // 作者
            // 
            this.作者.HeaderText = "作者";
            this.作者.Name = "作者";
            this.作者.Width = 90;
            // 
            // 创作年代
            // 
            this.创作年代.HeaderText = "创作年代";
            this.创作年代.Name = "创作年代";
            this.创作年代.Width = 90;
            // 
            // 楼层
            // 
            this.楼层.HeaderText = "楼层";
            this.楼层.Name = "楼层";
            this.楼层.Width = 90;
            // 
            // 区域
            // 
            this.区域.HeaderText = "区域";
            this.区域.Name = "区域";
            this.区域.Width = 90;
            // 
            // 藏品图片
            // 
            this.藏品图片.HeaderText = "藏品图片";
            this.藏品图片.Name = "藏品图片";
            this.藏品图片.Width = 90;
            // 
            // 备注
            // 
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.Width = 90;
            // 
            // 状态
            // 
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            // 
            // search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "search";
            this.Text = "search";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 作者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创作年代;
        private System.Windows.Forms.DataGridViewTextBoxColumn 楼层;
        private System.Windows.Forms.DataGridViewTextBoxColumn 区域;
        private System.Windows.Forms.DataGridViewTextBoxColumn 藏品图片;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
    }
}