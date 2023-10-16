using RuleCalc.classes;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;


namespace RuleCalc
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
        //--------------------------
        // Open Accelerations tool
        //--------------------------
        private void accelerationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            modules.Accelerations accelerations = new modules.Accelerations();
            accelerations.TopLevel = false;
            accelerations.AutoScroll = true;
            this.Controls.Add(accelerations);
            this.Controls.Add(menuStrip);
            accelerations.Dock = DockStyle.Fill;
            accelerations.Show();

        }
        //--------------------------
        // Open Minimum thickness tool
        //--------------------------
        private void minimumThicknessToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Controls.Clear();
            modules.MinimumThickness minimumThickness = new modules.MinimumThickness();
            minimumThickness.TopLevel = false;
            minimumThickness.AutoScroll = true;
            this.Controls.Add(minimumThickness);
            this.Controls.Add(menuStrip);
            minimumThickness.Dock = DockStyle.Fill;
            minimumThickness.Show();
        }
        //--------------
        // Save to XML
        //--------------
        public void saveXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modules.ShipData.lppSave != "")
            {
                try
                {

                    Information info = new Information();

                    info.lppData = modules.ShipData.lppSave;
                    info.lData = modules.ShipData.lSave;
                    info.bData = modules.ShipData.bSave;
                    info.dData = modules.ShipData.dSave;
                    info.vData = modules.ShipData.vSave;
                    info.cbData = modules.ShipData.cbSave;
                    info.tbalData = modules.ShipData.tbalSave;
                    info.tscData = modules.ShipData.tscSave;
                    info.gmData = modules.ShipData.gmSave;
                    info.krData = modules.ShipData.krSave;
                    info.saData = modules.ShipData.saSave;
                    info.frData = modules.ShipData.frSave;
                    info.bkData = modules.ShipData.bkSave;

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
            MessageBox.Show("Rules: DNV-GL July 2018\nAuthor: Lukasz Swiercz\nRuleCalc: beta 0.4");
        }
        //--------------------------
        // Open Ship Data tool..
        //--------------------------
        private void shipDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Controls.Clear();
            modules.ShipData shipData = new modules.ShipData();
            shipData.TopLevel = false;
            shipData.AutoScroll = true;
            this.Controls.Add(shipData);
            this.Controls.Add(menuStrip);
            shipData.Dock = DockStyle.Fill;
            shipData.Show();
        }

        private void RuleCalc_Load(object sender, EventArgs e)
        {

        }
    }
}
