namespace RuleCalc
{
    partial class RuleCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleCalc));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pressureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accelerationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimumThicknessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutRuleCalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moduleToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(674, 24);
            this.menuStrip.TabIndex = 19;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveXMLToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveXMLToolStripMenuItem
            // 
            this.saveXMLToolStripMenuItem.Name = "saveXMLToolStripMenuItem";
            this.saveXMLToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveXMLToolStripMenuItem.Text = "Save XML";
            this.saveXMLToolStripMenuItem.Click += new System.EventHandler(this.saveXMLToolStripMenuItem_Click);
            // 
            // moduleToolStripMenuItem
            // 
            this.moduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pressureToolStripMenuItem,
            this.accelerationsToolStripMenuItem,
            this.minimumThicknessToolStripMenuItem});
            this.moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
            this.moduleToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.moduleToolStripMenuItem.Text = "Module";
            // 
            // pressureToolStripMenuItem
            // 
            this.pressureToolStripMenuItem.Name = "pressureToolStripMenuItem";
            this.pressureToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.pressureToolStripMenuItem.Text = "Pressure";
            this.pressureToolStripMenuItem.Click += new System.EventHandler(this.pressureToolStripMenuItem_Click);
            // 
            // accelerationsToolStripMenuItem
            // 
            this.accelerationsToolStripMenuItem.Name = "accelerationsToolStripMenuItem";
            this.accelerationsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.accelerationsToolStripMenuItem.Text = "Accelerations";
            this.accelerationsToolStripMenuItem.Click += new System.EventHandler(this.accelerationsToolStripMenuItem_Click);
            // 
            // minimumThicknessToolStripMenuItem
            // 
            this.minimumThicknessToolStripMenuItem.Name = "minimumThicknessToolStripMenuItem";
            this.minimumThicknessToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.minimumThicknessToolStripMenuItem.Text = "Minimum thickness";
            this.minimumThicknessToolStripMenuItem.Click += new System.EventHandler(this.minimumThicknessToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutRuleCalcToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutRuleCalcToolStripMenuItem
            // 
            this.aboutRuleCalcToolStripMenuItem.Name = "aboutRuleCalcToolStripMenuItem";
            this.aboutRuleCalcToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aboutRuleCalcToolStripMenuItem.Text = "About RuleCalc";
            this.aboutRuleCalcToolStripMenuItem.Click += new System.EventHandler(this.aboutRuleCalcToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(0, 27);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(788, 712);
            this.panelMain.TabIndex = 20;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // RuleCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 751);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "RuleCalc";
            this.Text = "RuleCalc";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduleToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem pressureToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutRuleCalcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accelerationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimumThicknessToolStripMenuItem;
    }
}

