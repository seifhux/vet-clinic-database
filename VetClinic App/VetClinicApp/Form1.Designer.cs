namespace VetClinicApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWhereColumn = new System.Windows.Forms.TextBox();
            this.txtWhereValue = new System.Windows.Forms.TextBox();
            this.txtSetColumn = new System.Windows.Forms.TextBox();
            this.txtSetValue = new System.Windows.Forms.TextBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.cmbJoin = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShowData = new System.Windows.Forms.Button();
            this.btnShowJoin = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReports = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtWhereColumn
            // 
            resources.ApplyResources(this.txtWhereColumn, "txtWhereColumn");
            this.txtWhereColumn.Name = "txtWhereColumn";
            // 
            // txtWhereValue
            // 
            resources.ApplyResources(this.txtWhereValue, "txtWhereValue");
            this.txtWhereValue.Name = "txtWhereValue";
            // 
            // txtSetColumn
            // 
            resources.ApplyResources(this.txtSetColumn, "txtSetColumn");
            this.txtSetColumn.Name = "txtSetColumn";
            // 
            // txtSetValue
            // 
            resources.ApplyResources(this.txtSetValue, "txtSetValue");
            this.txtSetValue.Name = "txtSetValue";
            // 
            // txtColumns
            // 
            resources.ApplyResources(this.txtColumns, "txtColumns");
            this.txtColumns.Name = "txtColumns";
            // 
            // txtValues
            // 
            resources.ApplyResources(this.txtValues, "txtValues");
            this.txtValues.Name = "txtValues";
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            resources.ApplyResources(this.cmbTable, "cmbTable");
            this.cmbTable.Name = "cmbTable";
            // 
            // cmbJoin
            // 
            this.cmbJoin.FormattingEnabled = true;
            resources.ApplyResources(this.cmbJoin, "cmbJoin");
            this.cmbJoin.Name = "cmbJoin";
            // 
            // btnInsert
            // 
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShowData
            // 
            resources.ApplyResources(this.btnShowData, "btnShowData");
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // btnShowJoin
            // 
            resources.ApplyResources(this.btnShowJoin, "btnShowJoin");
            this.btnShowJoin.Name = "btnShowJoin";
            this.btnShowJoin.UseVisualStyleBackColor = true;
            this.btnShowJoin.Click += new System.EventHandler(this.btnShowJoin_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            // 
            // btnReports
            // 
            resources.ApplyResources(this.btnReports, "btnReports");
            this.btnReports.Name = "btnReports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnShowJoin);
            this.Controls.Add(this.btnShowData);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.cmbJoin);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.txtValues);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtSetValue);
            this.Controls.Add(this.txtSetColumn);
            this.Controls.Add(this.txtWhereValue);
            this.Controls.Add(this.txtWhereColumn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWhereColumn;
        private System.Windows.Forms.TextBox txtWhereValue;
        private System.Windows.Forms.TextBox txtSetColumn;
        private System.Windows.Forms.TextBox txtSetValue;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ComboBox cmbJoin;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.Button btnShowJoin;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReports;
    }
}

