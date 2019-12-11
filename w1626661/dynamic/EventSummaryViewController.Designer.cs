namespace w1626661.dynamic
{
    partial class EventSummaryViewController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedLable1 = new w1626661.dynamic.RoundedPanel();
            this.lblDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedLable2 = new w1626661.dynamic.RoundedPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedLable1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.roundedLable2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 553F));
            this.tableLayoutPanel1.Controls.Add(this.roundedLable1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 113);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // roundedLable1
            // 
            this.roundedLable1.BackColor = System.Drawing.Color.SkyBlue;
            this.roundedLable1.Controls.Add(this.lblFullDate);
            this.roundedLable1.Controls.Add(this.lblDate);
            this.roundedLable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedLable1.Location = new System.Drawing.Point(3, 3);
            this.roundedLable1.Name = "roundedLable1";
            this.roundedLable1.Size = new System.Drawing.Size(166, 107);
            this.roundedLable1.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(48, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(107, 37);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "label1";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.roundedLable2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTitle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDescription, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(175, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.12329F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.87671F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(547, 107);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // roundedLable2
            // 
            this.roundedLable2.BackColor = System.Drawing.Color.SkyBlue;
            this.roundedLable2.Controls.Add(this.lblTime);
            this.roundedLable2.Location = new System.Drawing.Point(3, 3);
            this.roundedLable2.Name = "roundedLable2";
            this.roundedLable2.Size = new System.Drawing.Size(541, 47);
            this.roundedLable2.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(158, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(84, 28);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "label1";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(254)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 53);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(541, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(3, 78);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(541, 29);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "label2";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFullDate
            // 
            this.lblFullDate.AutoSize = true;
            this.lblFullDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullDate.ForeColor = System.Drawing.Color.White;
            this.lblFullDate.Location = new System.Drawing.Point(45, 68);
            this.lblFullDate.Name = "lblFullDate";
            this.lblFullDate.Size = new System.Drawing.Size(72, 23);
            this.lblFullDate.TabIndex = 1;
            this.lblFullDate.Text = "label1";
            this.lblFullDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventSummaryViewController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EventSummaryViewController";
            this.Size = new System.Drawing.Size(725, 113);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedLable1.ResumeLayout(false);
            this.roundedLable1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.roundedLable2.ResumeLayout(false);
            this.roundedLable2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public RoundedPanel roundedLable1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public RoundedPanel roundedLable2;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.Label lblFullDate;
    }
}
