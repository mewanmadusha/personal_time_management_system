namespace w1626661
{
    partial class EventView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headinglbl = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAdEvent = new w1626661.dynamic.RoundButton();
            this.lablename = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenarateMonth = new w1626661.dynamic.RoundButton();
            this.btnGenarateWeek = new w1626661.dynamic.RoundButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.26273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.73727F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 593);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.btnGenarateWeek);
            this.panel1.Controls.Add(this.btnGenarateMonth);
            this.panel1.Controls.Add(this.headinglbl);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnAdEvent);
            this.panel1.Controls.Add(this.lablename);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 587);
            this.panel1.TabIndex = 1;
            // 
            // headinglbl
            // 
            this.headinglbl.AutoSize = true;
            this.headinglbl.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headinglbl.ForeColor = System.Drawing.Color.White;
            this.headinglbl.Location = new System.Drawing.Point(20, 15);
            this.headinglbl.Name = "headinglbl";
            this.headinglbl.Size = new System.Drawing.Size(254, 19);
            this.headinglbl.TabIndex = 10;
            this.headinglbl.Text = "MANAGE UPCOMING  EVENTS";
            this.headinglbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(254)))));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(108, 477);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(84, 79);
            this.btnHome.TabIndex = 9;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAdEvent
            // 
            this.btnAdEvent.BackColor = System.Drawing.Color.White;
            this.btnAdEvent.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(254)))));
            this.btnAdEvent.Location = new System.Drawing.Point(55, 400);
            this.btnAdEvent.Name = "btnAdEvent";
            this.btnAdEvent.Size = new System.Drawing.Size(180, 52);
            this.btnAdEvent.TabIndex = 7;
            this.btnAdEvent.Text = "ADD NEW EVENT";
            this.btnAdEvent.UseVisualStyleBackColor = false;
            this.btnAdEvent.Click += new System.EventHandler(this.btnAdcontact_Click);
            // 
            // lablename
            // 
            this.lablename.AutoSize = true;
            this.lablename.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablename.ForeColor = System.Drawing.Color.White;
            this.lablename.Location = new System.Drawing.Point(103, 166);
            this.lablename.Name = "lablename";
            this.lablename.Size = new System.Drawing.Size(80, 28);
            this.lablename.TabIndex = 6;
            this.lablename.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "#Event Manager App";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(310, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(669, 587);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnGenarateMonth
            // 
            this.btnGenarateMonth.BackColor = System.Drawing.Color.Transparent;
            this.btnGenarateMonth.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenarateMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(254)))));
            this.btnGenarateMonth.Location = new System.Drawing.Point(55, 255);
            this.btnGenarateMonth.Name = "btnGenarateMonth";
            this.btnGenarateMonth.Size = new System.Drawing.Size(180, 52);
            this.btnGenarateMonth.TabIndex = 11;
            this.btnGenarateMonth.Text = "Following Month Events Report";
            this.btnGenarateMonth.UseVisualStyleBackColor = false;
            this.btnGenarateMonth.Click += new System.EventHandler(this.btnGenarateMonth_Click);
            // 
            // btnGenarateWeek
            // 
            this.btnGenarateWeek.BackColor = System.Drawing.Color.Transparent;
            this.btnGenarateWeek.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenarateWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(138)))), ((int)(((byte)(254)))));
            this.btnGenarateWeek.Location = new System.Drawing.Point(55, 313);
            this.btnGenarateWeek.Name = "btnGenarateWeek";
            this.btnGenarateWeek.Size = new System.Drawing.Size(180, 52);
            this.btnGenarateWeek.TabIndex = 12;
            this.btnGenarateWeek.Text = "Following Week Events Report";
            this.btnGenarateWeek.UseVisualStyleBackColor = false;
            this.btnGenarateWeek.Click += new System.EventHandler(this.btnGenarateWeek_Click);
            // 
            // EventView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 593);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EventView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headinglbl;
        private System.Windows.Forms.Button btnHome;
        private dynamic.RoundButton btnAdEvent;
        private System.Windows.Forms.Label lablename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private dynamic.RoundButton btnGenarateWeek;
        private dynamic.RoundButton btnGenarateMonth;
    }
}