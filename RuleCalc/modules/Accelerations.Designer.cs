namespace RuleCalc.modules
{
    partial class Accelerations
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cgCLtb = new System.Windows.Forms.TextBox();
            this.cgXtb = new System.Windows.Forms.TextBox();
            this.cgBLtb = new System.Windows.Forms.TextBox();
            this.dgvAccelerations = new System.Windows.Forms.DataGridView();
            this.lcCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.axU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ayU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.azU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculateBT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccelerations)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calculateBT);
            this.groupBox1.Controls.Add(this.dgvAccelerations);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cgCLtb);
            this.groupBox1.Controls.Add(this.cgXtb);
            this.groupBox1.Controls.Add(this.cgBLtb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pt.3 Ch.4 Sec.3 3.3. Envelope accelerations (Edition 07-2018)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CG from BL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CG from CL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CG CGx";
            // 
            // cgCLtb
            // 
            this.cgCLtb.Location = new System.Drawing.Point(73, 51);
            this.cgCLtb.Name = "cgCLtb";
            this.cgCLtb.Size = new System.Drawing.Size(100, 20);
            this.cgCLtb.TabIndex = 2;
            this.cgCLtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.verifyInput);
            // 
            // cgXtb
            // 
            this.cgXtb.Location = new System.Drawing.Point(73, 25);
            this.cgXtb.Name = "cgXtb";
            this.cgXtb.Size = new System.Drawing.Size(100, 20);
            this.cgXtb.TabIndex = 1;
            this.cgXtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.verifyInput);
            // 
            // cgBLtb
            // 
            this.cgBLtb.Location = new System.Drawing.Point(73, 77);
            this.cgBLtb.Name = "cgBLtb";
            this.cgBLtb.Size = new System.Drawing.Size(100, 20);
            this.cgBLtb.TabIndex = 0;
            this.cgBLtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.verifyInput);
            // 
            // dgvAccelerations
            // 
            this.dgvAccelerations.AllowUserToAddRows = false;
            this.dgvAccelerations.AllowUserToDeleteRows = false;
            this.dgvAccelerations.AllowUserToResizeColumns = false;
            this.dgvAccelerations.AllowUserToResizeRows = false;
            this.dgvAccelerations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAccelerations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lcCol,
            this.axU,
            this.ayU,
            this.azU});
            this.dgvAccelerations.Location = new System.Drawing.Point(9, 114);
            this.dgvAccelerations.Name = "dgvAccelerations";
            this.dgvAccelerations.ReadOnly = true;
            this.dgvAccelerations.RowHeadersVisible = false;
            this.dgvAccelerations.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvAccelerations.Size = new System.Drawing.Size(294, 156);
            this.dgvAccelerations.TabIndex = 1;
            // 
            // lcCol
            // 
            this.lcCol.FillWeight = 157.5342F;
            this.lcCol.HeaderText = "Load combination";
            this.lcCol.Name = "lcCol";
            this.lcCol.ReadOnly = true;
            this.lcCol.Width = 115;
            // 
            // axU
            // 
            this.axU.FillWeight = 72.59828F;
            this.axU.HeaderText = "a x-U";
            this.axU.Name = "axU";
            this.axU.ReadOnly = true;
            this.axU.Width = 53;
            // 
            // ayU
            // 
            this.ayU.FillWeight = 82.29101F;
            this.ayU.HeaderText = "a y-U";
            this.ayU.Name = "ayU";
            this.ayU.ReadOnly = true;
            this.ayU.Width = 60;
            // 
            // azU
            // 
            this.azU.FillWeight = 87.57648F;
            this.azU.HeaderText = "a z-U";
            this.azU.Name = "azU";
            this.azU.ReadOnly = true;
            this.azU.Width = 64;
            // 
            // calculateBT
            // 
            this.calculateBT.Location = new System.Drawing.Point(411, 177);
            this.calculateBT.Name = "calculateBT";
            this.calculateBT.Size = new System.Drawing.Size(111, 47);
            this.calculateBT.TabIndex = 6;
            this.calculateBT.Text = "Calculate Accelerations";
            this.calculateBT.UseVisualStyleBackColor = true;
            this.calculateBT.Click += new System.EventHandler(this.calculateBT_Click);
            // 
            // Accelerations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 720);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Accelerations";
            this.Text = "Accelerations";
            this.Load += new System.EventHandler(this.Accelerations_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccelerations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox cgCLtb;
        private System.Windows.Forms.TextBox cgXtb;
        private System.Windows.Forms.TextBox cgBLtb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAccelerations;
        private System.Windows.Forms.DataGridViewTextBoxColumn lcCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn axU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ayU;
        private System.Windows.Forms.DataGridViewTextBoxColumn azU;
        private System.Windows.Forms.Button calculateBT;
    }
}