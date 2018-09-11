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
            //------------------
            // Number "." only
            //------------------
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

        }


        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            modules.intro intro = new modules.intro();
            intro.TopLevel = false;
            intro.AutoScroll = true;
            panelMain.Controls.Add(intro);
            intro.Dock = DockStyle.Fill;
            intro.Show();
        }

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
        private void saveXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Information info = new Information();
                //info.Data1 = cCalcTB.Text;
                info.Data1 = modules.Pressure.SetValueForText1;
                // -->

                SaveXML.SaveData(info, "data.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
