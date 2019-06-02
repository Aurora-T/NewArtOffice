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
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.预约日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人1姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人1身份证号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人2姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.同行人2身份证号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文新魏", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(156, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.预约日期,
            this.同行人1姓名,
            this.同行人1身份证号,
            this.同行人2姓名,
            this.同行人2身份证号,
            this.联系方式,
            this.状态,
            this.操作时间});
            this.dataGridView1.Location = new System.Drawing.Point(7, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(396, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // 编号
            // 
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            // 
            // 预约日期
            // 
            this.预约日期.HeaderText = "预约日期";
            this.预约日期.Name = "预约日期";
            // 
            // 同行人1姓名
            // 
            this.同行人1姓名.HeaderText = "同行人1姓名";
            this.同行人1姓名.Name = "同行人1姓名";
            // 
            // 同行人1身份证号
            // 
            this.同行人1身份证号.HeaderText = "同行人1身份证号";
            this.同行人1身份证号.Name = "同行人1身份证号";
            // 
            // 同行人2姓名
            // 
            this.同行人2姓名.HeaderText = "同行人2姓名";
            this.同行人2姓名.Name = "同行人2姓名";
            // 
            // 同行人2身份证号
            // 
            this.同行人2身份证号.HeaderText = "同行人2身份证号";
            this.同行人2身份证号.Name = "同行人2身份证号";
            // 
            // 联系方式
            // 
            this.联系方式.HeaderText = "联系方式";
            this.联系方式.Name = "联系方式";
            // 
            // 状态
            // 
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            // 
            // 操作时间
            // 
            this.操作时间.HeaderText = "操作时间";
            this.操作时间.Name = "操作时间";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(76, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预约日期";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // yuyue_record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 294);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 预约日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人1姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人1身份证号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人2姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 同行人2身份证号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 操作时间;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}