using RuleCalc.classes;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;


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

            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Information info = (Information)xs.Deserialize(read);

                //load data
                double lruleVAR = Convert.ToDouble(info.lData);
                double kNS = 1;
                double k32 = 0.72;
                double k36 = 0.66;


                //Keel - NS
                dgv_shell1.Rows[0].Cells[1].Value = Math.Round((5 + 0.05 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Keel - 32
                dgv_shell1.Rows[0].Cells[2].Value = Math.Round((5 + 0.05 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Keel - 36
                dgv_shell1.Rows[0].Cells[3].Value = Math.Round((5 + 0.05 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bottom and bilge - NS
                dgv_shell1.Rows[1].Cells[1].Value = Math.Round((4.5 + 0.035 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bottom and bilge - 32
                dgv_shell1.Rows[1].Cells[2].Value = Math.Round((4.5 + 0.035 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bottom and bilge - 36
                dgv_shell1.Rows[1].Cells[3].Value = Math.Round((4.5 + 0.035 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From upper end of bilge plating to TSC + 4.6 m - NS
                dgv_shell2.Rows[0].Cells[1].Value = Math.Round((4 + 0.035 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From upper end of bilge plating to TSC + 4.6 m - 32
                dgv_shell2.Rows[0].Cells[2].Value = Math.Round((4 + 0.035 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From upper end of bilge plating to TSC + 4.6 m - 36
                dgv_shell2.Rows[0].Cells[3].Value = Math.Round((4 + 0.035 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From TSC + 4.6 m to TSC + 6.9 m - NS
                dgv_shell2.Rows[1].Cells[1].Value = Math.Round((4 + 0.025 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From TSC + 4.6 m to TSC + 6.9 m - 32
                dgv_shell2.Rows[1].Cells[2].Value = Math.Round((4 + 0.025 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From TSC + 4.6 m to TSC + 6.9 m - 36
                dgv_shell2.Rows[1].Cells[3].Value = Math.Round((4 + 0.025 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From TSC + 6.9 m to TSC + 9.2 m - NS
                dgv_shell2.Rows[2].Cells[1].Value = Math.Round((4 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From TSC + 6.9 m to TSC + 9.2 m - 32
                dgv_shell2.Rows[2].Cells[2].Value = Math.Round((4 + 0.015 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //From TSC + 6.9 m to TSC + 9.2 m - 36
                dgv_shell2.Rows[2].Cells[3].Value = Math.Round((4 + 0.015 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Elsewhere6) - NS
                dgv_shell2.Rows[3].Cells[1].Value = Math.Round((4 + 0.01 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Elsewhere6) - 32
                dgv_shell2.Rows[3].Cells[2].Value = Math.Round((4 + 0.01 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Elsewhere6) - 36
                dgv_shell2.Rows[3].Cells[3].Value = Math.Round((4 + 0.01 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Sea chest boundaries - NS
                dgv_shell3.Rows[0].Cells[1].Value = Math.Round((4.5 + 0.05 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Sea chest boundaries - 32
                dgv_shell3.Rows[0].Cells[2].Value = Math.Round((4.5 + 0.05 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Sea chest boundaries - 36
                dgv_shell3.Rows[0].Cells[3].Value = Math.Round((4.5 + 0.05 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Weather deck1),2),3),4), strength deck2),3) and platform deck in machinery space - NS
                dgv_deck1.Rows[0].Cells[1].Value = Math.Round((4.5 + 0.02 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Weather deck1),2),3),4), strength deck2),3) and platform deck in machinery space - 32
                dgv_deck1.Rows[0].Cells[2].Value = Math.Round((4.5 + 0.02 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Weather deck1),2),3),4), strength deck2),3) and platform deck in machinery space - 36
                dgv_deck1.Rows[0].Cells[3].Value = Math.Round((4.5 + 0.02 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Boundary for cargo tanks, water ballast tanks and hold intended for cargo in bulk - NS
                dgv_deck1.Rows[1].Cells[1].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Boundary for cargo tanks, water ballast tanks and hold intended for cargo in bulk - 32
                dgv_deck1.Rows[1].Cells[2].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Boundary for cargo tanks, water ballast tanks and hold intended for cargo in bulk - 36
                dgv_deck1.Rows[1].Cells[3].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other decks3),4),5) - NS
                dgv_deck1.Rows[2].Cells[1].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other decks3),4),5) - 32
                dgv_deck1.Rows[2].Cells[2].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other decks3),4),5) - 36
                dgv_deck1.Rows[2].Cells[3].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Cargo spaces loaded through cargo hatches except container holds - NS
                dgv_innerB1.Rows[0].Cells[1].Value = Math.Round((5.5 + 0.025 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Cargo spaces loaded through cargo hatches except container holds - 32
                dgv_innerB1.Rows[0].Cells[2].Value = Math.Round((5.5 + 0.025 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Cargo spaces loaded through cargo hatches except container holds - 36
                dgv_innerB1.Rows[0].Cells[3].Value = Math.Round((5.5 + 0.025 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other spaces - NS
                dgv_innerB1.Rows[1].Cells[1].Value = Math.Round((4.5 + 0.02 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other spaces - 32
                dgv_innerB1.Rows[1].Cells[2].Value = Math.Round((4.5 + 0.02 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other spaces - 36
                dgv_innerB1.Rows[1].Cells[3].Value = Math.Round((4.5 + 0.02 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bulkheads for cargo tanks, water ballast tanks and hold intended for cargo in bulk - NS
                dgv_bulkheads1.Rows[0].Cells[1].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bulkheads for cargo tanks, water ballast tanks and hold intended for cargo in bulk - 32
                dgv_bulkheads1.Rows[0].Cells[2].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bulkheads for cargo tanks, water ballast tanks and hold intended for cargo in bulk - 36
                dgv_bulkheads1.Rows[0].Cells[3].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Peak bulkheads and machinery space end bulkheads - NS
                dgv_bulkheads1.Rows[1].Cells[1].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Peak bulkheads and machinery space end bulkheads - 32
                dgv_bulkheads1.Rows[1].Cells[2].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Peak bulkheads and machinery space end bulkheads - 36
                dgv_bulkheads1.Rows[1].Cells[3].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Watertight bulkheads and other tanks bulkheads - NS
                dgv_bulkheads1.Rows[2].Cells[1].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Watertight bulkheads and other tanks bulkheads - 32
                dgv_bulkheads1.Rows[2].Cells[2].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Watertight bulkheads and other tanks bulkheads - 36
                dgv_bulkheads1.Rows[2].Cells[3].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Non-tight bulkheads in tanks - NS
                dgv_bulkheads1.Rows[3].Cells[1].Value = Math.Round((5 + 0.005 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Non-tight bulkheads in tanks - 32
                dgv_bulkheads1.Rows[3].Cells[2].Value = Math.Round((5 + 0.005 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Non-tight bulkheads in tanks - 36
                dgv_bulkheads1.Rows[3].Cells[3].Value = Math.Round((5 + 0.005 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other non-tight bulkheads - NS
                dgv_bulkheads1.Rows[4].Cells[1].Value = Math.Round((5 + 0 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other non-tight bulkheads - 32
                dgv_bulkheads1.Rows[4].Cells[2].Value = Math.Round((5 + 0 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other non-tight bulkheads - 36
                dgv_bulkheads1.Rows[4].Cells[3].Value = Math.Round((5 + 0 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Walls in accommodation - NS
                dgv_bulkheads1.Rows[5].Cells[1].Value = Math.Round((4.5 + 0 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Walls in accommodation - 32
                dgv_bulkheads1.Rows[5].Cells[2].Value = Math.Round((4.5 + 0 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Walls in accommodation - 36
                dgv_bulkheads1.Rows[5].Cells[3].Value = Math.Round((4.5 + 0 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Tank boundary - NS
                dgv_StifAndBra1.Rows[0].Cells[1].Value = Math.Round((4.5 + 0.01 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Tank boundary - 32
                dgv_StifAndBra1.Rows[0].Cells[2].Value = Math.Round((4.5 + 0.01 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Tank boundary - 36
                dgv_StifAndBra1.Rows[0].Cells[3].Value = Math.Round((4.5 + 0.01 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Structures in deckhouse and superstructure and decks for vessels with more than 2 continuous decks above 0.7 D from baseline - NS
                dgv_StifAndBra1.Rows[1].Cells[1].Value = 4.0;
                //Structures in deckhouse and superstructure and decks for vessels with more than 2 continuous decks above 0.7 D from baseline - 32
                dgv_StifAndBra1.Rows[1].Cells[2].Value = 4.0;
                //Structures in deckhouse and superstructure and decks for vessels with more than 2 continuous decks above 0.7 D from baseline - 36
                dgv_StifAndBra1.Rows[1].Cells[3].Value = 4.0;
                //Other structure - NS
                dgv_StifAndBra1.Rows[2].Cells[1].Value = Math.Round((4.5 + 0.005 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other structure - 32
                dgv_StifAndBra1.Rows[2].Cells[2].Value = Math.Round((4.5 + 0.005 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other structure - 36
                dgv_StifAndBra1.Rows[2].Cells[3].Value = Math.Round((4.5 + 0.005 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Tripping brackets - NS
                dgv_other.Rows[0].Cells[1].Value = Math.Round((4.5 + 0.01 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Tripping brackets - 32
                dgv_other.Rows[0].Cells[2].Value = Math.Round((4.5 + 0.01 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Tripping brackets - 36
                dgv_other.Rows[0].Cells[3].Value = Math.Round((4.5 + 0.01 * lruleVAR) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bottom centerline girder and lower strake of centerline wash bulkhead - NS
                dgv_other.Rows[1].Cells[1].Value = Math.Round((5 + 0.03 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bottom centerline girder and lower strake of centerline wash bulkhead - 32
                dgv_other.Rows[1].Cells[2].Value = Math.Round((5 + 0.03 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Bottom centerline girder and lower strake of centerline wash bulkhead - 36
                dgv_other.Rows[1].Cells[3].Value = Math.Round((5 + 0.03 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other bottom girders - NS
                dgv_other.Rows[2].Cells[1].Value = Math.Round((5 + 0.017 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other bottom girders - 32
                dgv_other.Rows[2].Cells[2].Value = Math.Round((5 + 0.017 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other bottom girders - 36
                dgv_other.Rows[2].Cells[3].Value = Math.Round((5 + 0.017 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Floors - NS
                dgv_other.Rows[3].Cells[1].Value = Math.Round((5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Floors - 32
                dgv_other.Rows[3].Cells[2].Value = Math.Round((5 + 0.015 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Floors - 36
                dgv_other.Rows[3].Cells[3].Value = Math.Round((5 + 0.015 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //PSM supporting side shell, ballast tank, cargo tank and hold intended for cargo in bulk2),3) - NS
                dgv_other.Rows[4].Cells[1].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //PSM supporting side shell, ballast tank, cargo tank and hold intended for cargo in bulk2),3) - 32
                dgv_other.Rows[4].Cells[2].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //PSM supporting side shell, ballast tank, cargo tank and hold intended for cargo in bulk2),3) - 36
                dgv_other.Rows[4].Cells[3].Value = Math.Round((4.5 + 0.015 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other PSM - NS
                dgv_other.Rows[5].Cells[1].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other PSM - 32
                dgv_other.Rows[5].Cells[2].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //Other PSM - 36
                dgv_other.Rows[5].Cells[3].Value = Math.Round((4.5 + 0.01 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;
                //PSM in peak tanks - NS
                dgv_other.Rows[6].Cells[1].Value = Math.Round((5 + 0.025 * lruleVAR * Math.Sqrt(kNS)) * 2, MidpointRounding.AwayFromZero) / 2;
                //PSM in peak tanks - 32
                dgv_other.Rows[6].Cells[2].Value = Math.Round((5 + 0.025 * lruleVAR * Math.Sqrt(k32)) * 2, MidpointRounding.AwayFromZero) / 2;
                //PSM in peak tanks - 36
                dgv_other.Rows[6].Cells[3].Value = Math.Round((5 + 0.025 * lruleVAR * Math.Sqrt(k36)) * 2, MidpointRounding.AwayFromZero) / 2;

            }
            else
            {
                //gdy nie istnieje
            }





            //dgv_shell_ss.DefaultCellStyle.WrapMode = DataGridViewTriState.True;



        }
    }
}
