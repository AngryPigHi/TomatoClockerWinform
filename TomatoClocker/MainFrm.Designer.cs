namespace TomatoClocker
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.btnStartOrEnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlanContent = new System.Windows.Forms.TextBox();
            this.txtDoneContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSurplusTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblDayCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartOrEnd
            // 
            this.btnStartOrEnd.Location = new System.Drawing.Point(27, 27);
            this.btnStartOrEnd.Name = "btnStartOrEnd";
            this.btnStartOrEnd.Size = new System.Drawing.Size(75, 23);
            this.btnStartOrEnd.TabIndex = 0;
            this.btnStartOrEnd.Text = "开始";
            this.btnStartOrEnd.UseVisualStyleBackColor = true;
            this.btnStartOrEnd.Click += new System.EventHandler(this.btnStartOrEnd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始时间：";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(99, 140);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(212, 23);
            this.txtStartTime.TabIndex = 2;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(421, 140);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(212, 23);
            this.txtEndTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "计划事宜：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "完成事宜：";
            // 
            // txtPlanContent
            // 
            this.txtPlanContent.Location = new System.Drawing.Point(99, 68);
            this.txtPlanContent.Multiline = true;
            this.txtPlanContent.Name = "txtPlanContent";
            this.txtPlanContent.Size = new System.Drawing.Size(212, 45);
            this.txtPlanContent.TabIndex = 7;
            // 
            // txtDoneContent
            // 
            this.txtDoneContent.Location = new System.Drawing.Point(421, 68);
            this.txtDoneContent.Multiline = true;
            this.txtDoneContent.Name = "txtDoneContent";
            this.txtDoneContent.Size = new System.Drawing.Size(212, 45);
            this.txtDoneContent.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "当前剩余时间：";
            // 
            // lblSurplusTime
            // 
            this.lblSurplusTime.AutoSize = true;
            this.lblSurplusTime.Location = new System.Drawing.Point(260, 30);
            this.lblSurplusTime.Name = "lblSurplusTime";
            this.lblSurplusTime.Size = new System.Drawing.Size(93, 17);
            this.lblSurplusTime.TabIndex = 10;
            this.lblSurplusTime.Text = "lblSurplusTime";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "当日统计：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(606, 296);
            this.dataGridView1.TabIndex = 12;
            // 
            // lblDayCount
            // 
            this.lblDayCount.AutoSize = true;
            this.lblDayCount.Location = new System.Drawing.Point(491, 30);
            this.lblDayCount.Name = "lblDayCount";
            this.lblDayCount.Size = new System.Drawing.Size(78, 17);
            this.lblDayCount.TabIndex = 13;
            this.lblDayCount.Text = "lblDayCount";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 515);
            this.Controls.Add(this.lblDayCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSurplusTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDoneContent);
            this.Controls.Add(this.txtPlanContent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartOrEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "番茄时钟";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartOrEnd;
        private Label label1;
        private TextBox txtStartTime;
        private TextBox txtEndTime;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPlanContent;
        private TextBox txtDoneContent;
        private Label label5;
        private Label lblSurplusTime;
        private Label label6;
        private DataGridView dataGridView1;
        private Label lblDayCount;
        private System.Windows.Forms.Timer timer1;
    }
}