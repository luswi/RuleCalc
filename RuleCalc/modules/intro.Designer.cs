namespace EPT.modules
{
    partial class intro
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
            this.rTB_Info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(238, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select module...";
            // 
            // rTB_Info
            // 
            this.rTB_Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTB_Info.Enabled = false;
            this.rTB_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rTB_Info.ForeColor = System.Drawing.Color.Red;
            this.rTB_Info.Location = new System.Drawing.Point(242, 292);
            this.rTB_Info.Name = "rTB_Info";
            this.rTB_Info.Size = new System.Drawing.Size(354, 42);
            this.rTB_Info.TabIndex = 1;
            this.rTB_Info.Text = "Be aware that this software base on DNV-GL rules.\nYou use it on your own responsi" +
    "bilities.";
            // 
            // intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 554);
            this.Controls.Add(this.rTB_Info);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "intro";
            this.Text = "intro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rTB_Info;
    }
}