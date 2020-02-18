using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using RuleCalc.classes;


namespace RuleCalc.modules
{
    public partial class MinimumThickness : Form
    {
        public MinimumThickness()
        {
            InitializeComponent();
        }

        private void MinimumThickness_Load(object sender, EventArgs e)
        {

            dgv_StifAndBra1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            dgv_element_shell.Rows.Add("Shell");
            dgv_element_deck.Rows.Add("Deck");
            dgv_element_innerB.Rows.Add("Inner bottom");
            dgv_element_bulkheads.Rows.Add("Bulkheads");
            dgv_element_bulkheadsStifAndBra.Rows.Add("Stiffeners and attached end brackets");


            dgv_shell1.Rows.Add("Keel");
            dgv_shell1.Rows.Add("Bottom and bilge");
            dgv_shell2.Rows.Add("From upper end of bilge plating to TSC + 4.6 m");
            dgv_shell2.Rows.Add("From TSC + 4.6 m to TSC + 6.9 m");
            dgv_shell2.Rows.Add("From TSC + 6.9 m to TSC + 9.2 m");
            dgv_shell2.Rows.Add("Elsewhere6)");
            dgv_shell3.Rows.Add("Sea chest boundaries");
            dgv_shell_ss.Rows.Add("Side shell and superstructure side");
            dgv_deck1.Rows.Add("Weather deck1),2),3),4), strength deck2),3) and platform deck in machinery space");
            dgv_deck1.Rows.Add("Boundary for cargo tanks, water ballast tanks and hold intended for cargo in bulk");
            dgv_deck1.Rows.Add("Other decks3),4),5)");
            dgv_innerB1.Rows.Add("Cargo spaces loaded through cargo hatches except container holds");
            dgv_innerB1.Rows.Add("Other spaces");

            dgv_bulkheads1.Rows.Add("Bulkheads for cargo tanks, water ballast tanks and hold intended for cargo in bulk");
            dgv_bulkheads1.Rows.Add("Peak bulkheads and machinery space end bulkheads");
            dgv_bulkheads1.Rows.Add("Watertight bulkheads and other tanks bulkheads");
            dgv_bulkheads1.Rows.Add("Non-tight bulkheads in tanks");
            dgv_bulkheads1.Rows.Add("Other non-tight bulkheads");
            dgv_bulkheads1.Rows.Add("Walls in accommodation");

            dgv_StifAndBra1.Rows.Add("Tank boundary");
            dgv_StifAndBra1.Rows.Add("Structures in deckhouse and superstructure and decks for vessels with more than 2 continuous decks above 0.7 D from baseline");
            dgv_StifAndBra1.Rows.Add("Other structure");


            dgv_other.Rows.Add("Tripping brackets");
            dgv_other.Rows.Add("Bottom centerline girder and lower strake of centerline wash bulkhead");
            dgv_other.Rows.Add("Other bottom girders");
            dgv_other.Rows.Add("Floors");
            dgv_other.Rows.Add("PSM supporting side shell, ballast tank, cargo tank and hold intended for cargo in bulk2),3)");
            dgv_other.Rows.Add("Other PSM");
            dgv_other.Rows.Add("PSM in peak tanks");


            //clear selected 1st row
            dgv_element_shell.CurrentCell = null;
            dgv_element_deck.CurrentCell = null;
            dgv_element_innerB.CurrentCell = null;
            dgv_element_bulkheads.CurrentCell = null;
            dgv_bulkheads1.CurrentCell = null;
            dgv_shell_ss.CurrentCell = null;
            dgv_shell1.CurrentCell = null;
            dgv_shell2.CurrentCell = null;
            dgv_shell3.CurrentCell = null;
            dgv_deck1.CurrentCell = null;
            dgv_innerB1.CurrentCell = null;
            dgv_element_bulkheadsStifAndBra.CurrentCell = null;
            dgv_StifAndBra1.CurrentCell = null;
            dgv_other.CurrentCell = null;



            this.dgv_element_bulkheads.ColumnHeadersVisible = false;
            this.dgv_bulkheads1.ColumnHeadersVisible = false;
            this.dgv_shell_ss.ColumnHeadersVisible = false;
            this.dgv_shell1.ColumnHeadersVisible = false;
            this.dgv_shell2.ColumnHeadersVisible = false;
            this.dgv_shell3.ColumnHeadersVisible = false;
            this.dgv_element_shell.ColumnHeadersVisible = false;
            this.dgv_element_deck.ColumnHeadersVisible = false;
            this.dgv_deck1.ColumnHeadersVisible = false;
            this.dgv_element_innerB.ColumnHeadersVisible = false;
            this.dgv_innerB1.ColumnHeadersVisible = false;
            this.dgv_element_bulkheadsStifAndBra.ColumnHeadersVisible = false;
            this.dgv_StifAndBra1.ColumnHeadersVisible = false;
            this.dgv_other.ColumnHeadersVisible = false;

            if(File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Information info = (Information)xs.Deserialize(read);

                //load data
                double lruleVAR = Convert.ToDouble(info.lData);
                double kNS = 1;
                double k32 = 0.72;
                double k36 = 0.66;

                dgv_shell1.Rows[0].Cells[1].Value = Math.Round((5 + 0.05 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                dgv_shell1.Rows[1].Cells[1].Value = Math.Round((4.5 + 0.035 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;

                dgv_shell1.Rows[0].Cells[2].Value = Math.Round((5 + 0.05 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                dgv_shell1.Rows[1].Cells[2].Value = Math.Round((4.5 + 0.035 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;

                dgv_shell1.Rows[0].Cells[3].Value = Math.Round((5 + 0.05 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                dgv_shell1.Rows[1].Cells[3].Value = Math.Round((4.5 + 0.035 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
            }
            else
            {
                //gdy nie istnieje
            }
             




            //dgv_shell_ss.DefaultCellStyle.WrapMode = DataGridViewTriState.True;



        }
    }
}
