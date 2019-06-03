namespace 美术馆.管理员
{
    partial class yuyue_record
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人1姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人1身份证号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人2姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人2身份证号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.微信号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文新魏", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(208, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "预约记录";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.编号,
            this.同行人1姓名,
            this.同行人1身份证号,
            this.同行人2姓名,
            this.同行人2身份证号,
            this.微信号,
            this.身份证号,
            this.姓名,
            this.操作时间,
            this.状态});
            this.dataGridView1.Location = new System.Drawing.Point(41, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(487, 175);
            this.dataGridView1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(104, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预约日期";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // 编号
            // 
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            // 
            // 同行人1姓名
            // 
            this.同行人1姓名.HeaderText = "同行人1姓名";
            this.同行人1姓名.Name = "同行人1姓名";
            this.同行人1姓名.Width = 110;
            // 
            // 同行人1身份证号
            // 
            this.同行人1身份证号.HeaderText = "同行人1身份证号";
            this.同行人1身份证号.Name = "同行人1身份证号";
            this.同行人1身份证号.Width = 140;
            // 
            // 同行人2姓名
            // 
            this.同行人2姓名.HeaderText = "同行人2姓名";
            this.同行人2姓名.Name = "同行人2姓名";
            this.同行人2姓名.Width = 110;
            // 
            // 同行人2身份证号
            // 
            this.同行人2身份证号.HeaderText = "同行人2身份证号";
            this.同行人2身份证号.Name = "同行人2身份证号";
            this.同行人2身份证号.Width = 140;
            // 
            // 微信号
            // 
            this.微信号.HeaderText = "微信号";
            this.微信号.Name = "微信号";
            // 
            // 身份证号
            // 
            this.身份证号.HeaderText = "身份证号";
            this.身份证号.Name = "身份证号";
            // 
            // 姓名
            // 
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            // 
            // 操作时间
            // 
            this.操作时间.HeaderText = "操作时间";
            this.操作时间.Name = "操作时间";
            // 
            // 状态
            // 
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            // 
            // yuyue_record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("华文新魏", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "yuyue_record";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预约记录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.yuyue_record_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人1姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人1身份证号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人2姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人2身份证号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 微信号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身份证号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 操作时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
    }
}