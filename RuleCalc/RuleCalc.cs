using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPT.classes;
using System.IO;
using System.Xml.Serialization;


namespace EPT
{
    public partial class RuleCalc : Form
    {
        public RuleCalc()
        {
            InitializeComponent();
            //-------------------
            // Number "." only
            //-------------------
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }
        //-------------------
        // Exit confirmation
        //-------------------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to close RuleCalc", "Close RuleCalc", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        //-------------------
        // loads intro form
        //-------------------
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            modules.intro intro = new modules.intro();
            intro.TopLevel = false;
            intro.AutoScroll = true;
            panelMain.Controls.Add(intro);
            intro.Dock = DockStyle.Fill;
            intro.Show();
        }
        //--------------------
        // Open Pressule tool
        //--------------------
        private void pressureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            modules.Pressure pressure = new modules.Pressure();
            pressure.TopLevel = false;
            pressure.AutoScroll = true;
            this.Controls.Add(pressure);
            this.Controls.Add(menuStrip);
            pressure.Dock = DockStyle.Fill;
            pressure.Show();
        }
        //--------------
        // Save to XML
        //--------------
        public void saveXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modules.Pressure.lppSave != "")
            {
                try
                {

                    Information info = new Information();
                    
                    info.lppData = modules.Pressure.lppSave;
                    info.lData = modules.Pressure.lSave;
                    info.bData = modules.Pressure.bSave;
                    info.dData = modules.Pressure.dSave;
                    info.vData = modules.Pressure.vSave;
                    info.cbData = modules.Pressure.cbSave;
                    info.tbalData = modules.Pressure.tbalSave;
                    info.tscData = modules.Pressure.tscSave;
                    info.gmData = modules.Pressure.gmSave;
                    info.krData = modules.Pressure.krSave;
                    info.saData = modules.Pressure.saSave;
                    info.frData = modules.Pressure.frSave;
                    info.bkData = modules.Pressure.bkSave;

                    // -->

                    SaveXML.SaveData(info, "data.xml");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select module first!");
            }
        }

        private void aboutRuleCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rules: DNV-GL July 2018\nAutor: Lukasz Swiercz\nRuleCalc: beta 0.1");
        }
    }
}
