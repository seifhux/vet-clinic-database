namespace VetClinicApp
{
    partial class Form2
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
            this.btnInquiry1 = new System.Windows.Forms.Button();
            this.btnInquiry2 = new System.Windows.Forms.Button();
            this.btnInquiry3 = new System.Windows.Forms.Button();
            this.btnInquiry4 = new System.Windows.Forms.Button();
            this.btnInquiry5 = new System.Windows.Forms.Button();
            this.btnInquiry6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInquiry1
            // 
            this.btnInquiry1.Location = new System.Drawing.Point(226, 89);
            this.btnInquiry1.Name = "btnInquiry1";
            this.btnInquiry1.Size = new System.Drawing.Size(90, 33);
            this.btnInquiry1.TabIndex = 0;
            this.btnInquiry1.Text = "Inquiry 1";
            this.btnInquiry1.UseVisualStyleBackColor = true;
            this.btnInquiry1.Click += new System.EventHandler(this.btnInquiry1_Click);
            // 
            // btnInquiry2
            // 
            this.btnInquiry2.Location = new System.Drawing.Point(389, 89);
            this.btnInquiry2.Name = "btnInquiry2";
            this.btnInquiry2.Size = new System.Drawing.Size(90, 33);
            this.btnInquiry2.TabIndex = 1;
            this.btnInquiry2.Text = "Inquiry 2";
            this.btnInquiry2.UseVisualStyleBackColor = true;
            this.btnInquiry2.Click += new System.EventHandler(this.btnInquiry2_Click);
            // 
            // btnInquiry3
            // 
            this.btnInquiry3.Location = new System.Drawing.Point(555, 89);
            this.btnInquiry3.Name = "btnInquiry3";
            this.btnInquiry3.Size = new System.Drawing.Size(90, 33);
            this.btnInquiry3.TabIndex = 2;
            this.btnInquiry3.Text = "Inquiry 3";
            this.btnInquiry3.UseVisualStyleBackColor = true;
            this.btnInquiry3.Click += new System.EventHandler(this.btnInquiry3_Click);
            // 
            // btnInquiry4
            // 
            this.btnInquiry4.Location = new System.Drawing.Point(226, 149);
            this.btnInquiry4.Name = "btnInquiry4";
            this.btnInquiry4.Size = new System.Drawing.Size(90, 33);
            this.btnInquiry4.TabIndex = 3;
            this.btnInquiry4.Text = "Inquiry 4";
            this.btnInquiry4.UseVisualStyleBackColor = true;
            this.btnInquiry4.Click += new System.EventHandler(this.btnInquiry4_Click);
            // 
            // btnInquiry5
            // 
            this.btnInquiry5.Location = new System.Drawing.Point(389, 149);
            this.btnInquiry5.Name = "btnInquiry5";
            this.btnInquiry5.Size = new System.Drawing.Size(90, 33);
            this.btnInquiry5.TabIndex = 4;
            this.btnInquiry5.Text = "Inquiry 5";
            this.btnInquiry5.UseVisualStyleBackColor = true;
            this.btnInquiry5.Click += new System.EventHandler(this.btnInquiry5_Click);
            // 
            // btnInquiry6
            // 
            this.btnInquiry6.Location = new System.Drawing.Point(555, 149);
            this.btnInquiry6.Name = "btnInquiry6";
            this.btnInquiry6.Size = new System.Drawing.Size(90, 33);
            this.btnInquiry6.TabIndex = 5;
            this.btnInquiry6.Text = "Inquiry 6";
            this.btnInquiry6.UseVisualStyleBackColor = true;
            this.btnInquiry6.Click += new System.EventHandler(this.btnInquiry6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 272);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(884, 339);
            this.dataGridView1.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(23, 256);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(205, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Select an inquiry from above to show data";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnInquiry6);
            this.Controls.Add(this.btnInquiry5);
            this.Controls.Add(this.btnInquiry4);
            this.Controls.Add(this.btnInquiry3);
            this.Controls.Add(this.btnInquiry2);
            this.Controls.Add(this.btnInquiry1);
            this.Name = "Form2";
            this.Text = "Inquires Report";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInquiry1;
        private System.Windows.Forms.Button btnInquiry2;
        private System.Windows.Forms.Button btnInquiry3;
        private System.Windows.Forms.Button btnInquiry4;
        private System.Windows.Forms.Button btnInquiry5;
        private System.Windows.Forms.Button btnInquiry6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblStatus;
    }
}