using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPT.classes;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace EPT.modules
{
    public partial class Pressure : Form
    {
        public Pressure()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        // Check if number and only one "." for input and protect textboxes
        //--------------------------------------------------------------------
        void verifyInput(object sender, KeyPressEventArgs e)
        {
            bool IsNumber = false;
            string text = (sender as TextBox).Text;
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                    IsNumber = true;
                }
                if (!IsNumber)
                {
                    if (e.KeyChar.ToString() == ".")
                    {
                        if (text.IndexOf(".") == -1)
                        {
                            e.Handled = false;
                        }
                    }
                }
            }
        }
        //-------------------
        // Main APP section
        //-------------------
        pressureClass v = new pressureClass();

        public void calculateBT_Click(object sender, EventArgs e)
        {
            // Pick up values from textboxes
            v.zdk = double.Parse(krTB.Text);
            

            // Results
            bool success = v.seaCalculation(v);
            if (success == true)
            {
                //cCalcTB.Text = Convert.ToString(v.cCalc);

            }
            else
            {
                MessageBox.Show("Something goes wrong!");
            }
        }
        //--------------------
        // Load data at start
        //--------------------
        private void Pressure_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Information info = (Information)xs.Deserialize(read);
                //data to load...
                LppTB.Text = info.lppData;
                LTB.Text = info.lData;
                BTB.Text = info.bData;
                DTB.Text = info.dData;
                CbTB.Text = info.cbData;
                TbalTB.Text = info.tbalData;
                TscTB.Text = info.tscData;
                gmTB.Text = info.gmData;
                krTB.Text = info.krData;
                saCB.Text = info.saData;
                bkCB.Text = info.bkData;
            }
            //remove scrollbar from dgvCalculateSP table
            dgvCalculateSP.ScrollBars = ScrollBars.None;
            //load data into dgvNames
            // Plate informations
            dgvNames.Rows.Add("Plate");
            dgvNames.Rows.Add("x [m] load point");
            dgvNames.Rows.Add("y [m] load point");
            dgvNames.Rows.Add("z [m] load point");
            dgvNames.Rows.Add("Bx [m]");
            dgvNames.Rows.Add("R_eH [MPa]");
            dgvNames.Rows.Add("b [mm]");
            dgvNames.Rows.Add("a [mm] (EPP Length]");
            dgvNames.Rows.Add("Alpha (aspect ratio)");
            dgvNames.Rows.Add("tc plate [mm]");
            dgvNames.Rows.Add("P [MPa]");
            dgvNames.Rows.Add("t req (GROSS) [mm]");
            dgvNames.Rows.Add("Plate thickness (GROSS) [mm]");
            dgvNames.Rows.Add("th. status");
            dgvNames.Rows.Add("Slenderness status");
            // Stiffeners informations
            dgvNames.Rows.Add("Stiffener");
            dgvNames.Rows.Add("x [m] load point");
            dgvNames.Rows.Add("y [m] load point");
            dgvNames.Rows.Add("z [m] load point");
            dgvNames.Rows.Add("Bx");
            dgvNames.Rows.Add("lbdg [m] (Stiffener bending span)");
            dgvNames.Rows.Add("s [mm] (stiffener spacing)");
            dgvNames.Rows.Add("f_u");
            dgvNames.Rows.Add("f_bdg");
            dgvNames.Rows.Add("R_eH [MPa]");
            dgvNames.Rows.Add("dshr [mm]");
            dgvNames.Rows.Add("hstif (GROSS) [mm]");
            dgvNames.Rows.Add("tp [mm]");
            dgvNames.Rows.Add("ϕw [deg]");
            dgvNames.Rows.Add("lshr [m]");
            dgvNames.Rows.Add("fshr");
            dgvNames.Rows.Add("ΤeH [MPa]");
            dgvNames.Rows.Add("tc stiffener (total) [mm]");
            dgvNames.Rows.Add("P [MPa]");
            dgvNames.Rows.Add("t req (GROSS) [mm]");
            dgvNames.Rows.Add("Web thickness (GROSS) [mm]");
            dgvNames.Rows.Add("th. status");
            dgvNames.Rows.Add("Slenderness status");
            dgvNames.Rows.Add("zreq NET");
            dgvNames.Rows.Add("Flange width (GROSS) [mm]");
            dgvNames.Rows.Add("Flange thickness (GROSS) [mm]");
            dgvNames.Rows.Add("Z [cm^3] (NET)");
            dgvNames.Rows.Add("Z status");
            //Intermediate informations
            dgvNames.Rows.Add("Intermediate values");
            dgvNames.Rows.Add("X’ (plate) [m]");
            dgvNames.Rows.Add("X’ (stiff) [m]");
            dgvNames.Rows.Add("fyB (plate)");
            dgvNames.Rows.Add("fyB(stiffener)");
            dgvNames.Rows.Add("fyz (plate)");
            dgvNames.Rows.Add("fyz (stiffener)");
            dgvNames.Rows.Add("fxL (plate)");
            dgvNames.Rows.Add("fxL (stiffeners)");
            dgvNames.Rows.Add("f_3");
            dgvNames.Rows.Add("f_4 (based on f_xl, plate)");
            dgvNames.Rows.Add("f_4 (stiffners on f_xl, stiffeners)");
            dgvNames.Rows.Add("f_5 (plate)");
            dgvNames.Rows.Add("f_5 (stiffners)");
            dgvNames.Rows.Add("Cw");
            dgvNames.Rows.Add("Pw,wl (plate) [MPa]");
            dgvNames.Rows.Add("Pw,wl (stiffners) [MPa]");
            dgvNames.Rows.Add("P_ENV (plate) [MPa]");
            dgvNames.Rows.Add("P_ENV (stiffener) [MPa]");
            dgvNames.Rows.Add("P (SEA-1) [MPa] plate");
            dgvNames.Rows.Add("P (SEA-2) [MPa] plate");
            dgvNames.Rows.Add("t req gross (SEA-1 AC-II) [mm] plate");
            dgvNames.Rows.Add("t req gross (SEA-2 AC-I) [mm] plate");
            dgvNames.Rows.Add("P (SEA-1) [MPa] stiff");
            dgvNames.Rows.Add("P (SEA-2) [MPa] stiff");
            dgvNames.Rows.Add("t req gross (SEA-1 AC-II) [mm] stiff");
            dgvNames.Rows.Add("t req gross (SEA-2 AC-I) [mm] stiff");
            dgvNames.Rows.Add("for 75° <= ϕw <= 90°");
            dgvNames.Rows.Add("for ϕw <= 75°");

            //clear selected 1st row
            dgvNames[0, 1].Selected = true;
            dgvNames.ClearSelection();
            //color and bold fonts/ceels
            RowsColorNames();
            RowsBold();
        }
        //------------
        // combobox
        //------------
        public void dropmenu()
        {
            for (int i = 0; i < dgvCalculateSP.ColumnCount; i++)
            {
                // f_u
                DataGridViewComboBoxCell f_u = new DataGridViewComboBoxCell();

                if ((string)dgvCalculateSP.Rows[22].Cells[i].Value == null)
                {
                    f_u.Items.Add("1");
                    f_u.Items.Add("1.03");
                    f_u.Items.Add("1.15");
                    dgvCalculateSP.Rows[22].Cells[i] = f_u;
                }
                // f_bdg
                DataGridViewComboBoxCell f_bdg = new DataGridViewComboBoxCell();

                if ((string)dgvCalculateSP.Rows[23].Cells[i].Value == null)
                {
                    f_bdg.Items.Add("8");
                    f_bdg.Items.Add("10");
                    f_bdg.Items.Add("12");
                    dgvCalculateSP.Rows[23].Cells[i] = f_bdg;

                }
                // fshr
                DataGridViewComboBoxCell fshr = new DataGridViewComboBoxCell();

                if ((string)dgvCalculateSP.Rows[30].Cells[i].Value == null)
                {
                    fshr.Items.Add("Upper end of vertical stiffeners");
                    fshr.Items.Add("Lower end of vertical stiffeners");
                    fshr.Items.Add("General");
                    dgvCalculateSP.Rows[30].Cells[i] = fshr;

                }
            }
        }
        //--------------------------------
        // color rows depends from group
        //--------------------------------
        public void RowsColorNames()
        {
            for (int i = 0; i< dgvNames.Rows.Count; i++)
            {
                if (i == 0)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
                else if (i == 15)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
                else if (i == 43)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                }

                else if (i > 9 & i < 12)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i > 32 & i < 35)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i == 38)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i == 41)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
            }
        }
        //--------------------------------
        // color rows depends from group
        //--------------------------------
        public void RowsColorCalculate()
        {
            for (int i = 0; i < dgvCalculateSP.Rows.Count; i++)
            {
                if (i == 0)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i == 8)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i == 15)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i == 43)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i > 9 & i < 12)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i > 32 & i < 35)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i == 38)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i == 41)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (i > 43 & i < 71)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
            }
        }
        //--------------------
        // BOLD specific row
        //--------------------
        public void RowsBold()
        {
            dgvNames.Rows[0].Cells[0].Style.Font = new Font(dgvNames.Font,  FontStyle.Bold);
            dgvNames.Rows[10].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[11].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[13].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[14].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[15].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[33].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[34].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[43].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[36].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[37].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[42].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
        }
        //--------------------------------
        // Public variables for save menu
        //--------------------------------
        public static string lppSave = "";
        public static string lSave = "";
        public static string bSave = "";
        public static string dSave = "";
        public static string vSave = "";
        public static string cbSave = "";
        public static string tbalSave = "";
        public static string tscSave = "";
        public static string gmSave = "";
        public static string krSave = "";
        public static string saSave = "";
        public static string frSave = "";
        public static string bkSave = "";
        //---------------------------
        // Update textboxes for save
        //---------------------------
        private void updateForSave(object sender, EventArgs e)
        {
            lppSave = LppTB.Text;
            lSave = LTB.Text;
            bSave = BTB.Text;
            dSave = DTB.Text;
            cbSave = CbTB.Text;
            tbalSave = TbalTB.Text;
            tscSave = TscTB.Text;
            gmSave = gmTB.Text;
            krSave = krTB.Text;
            saSave = saCB.Text;
            bkSave = bkCB.Text;
        }
        //---------------------------------------
        // Add new column for calculating point
        //---------------------------------------
        private void newCalcPoint_Click(object sender, EventArgs e)
        {
            if (dgvCalculateSP.ColumnCount == 0)
            {
                //clear selected 1st row

                // clear datasource to avoid errors after data load
                this.dgvCalculateSP.DataSource = null;
                this.dgvCalculateSP.Rows.Clear();
                this.dgvDeleteSP.DataSource = null;
                this.dgvDeleteSP.Rows.Clear();

                dgvCalculateSP.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Point" });
                //----------------------------------
                // add rows for calculation table
                //----------------------------------
                    for (int i = 0; i <= 70; i++)
                    {
                        i = dgvCalculateSP.Rows.Add();
                    }
                //unselect 1st cell
                dgvCalculateSP.ClearSelection();

                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "dgvDeleteButton";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                this.dgvDeleteSP.Columns.Add(deleteButton);
                this.dgvDeleteSP.Rows.Add();

                dropmenu();
                RowsColorCalculate();
            }
            else
            {
                dgvCalculateSP.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Point" });
                dropmenu();
                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "dgvDeleteButton";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
                this.dgvDeleteSP.Columns.Add(deleteButton);
            }
        }
        //---------------------
        // synchronize 2 grids
        //---------------------
        private void dgvNames_Scroll(object sender, ScrollEventArgs e)
        {
            if (dgvCalculateSP.Columns.Count != 0)
            {
                dgvCalculateSP.FirstDisplayedScrollingRowIndex = dgvNames.FirstDisplayedScrollingRowIndex;
            }
            
        }
        //----------------------------------------------------------------
        // DataGridView number and only one "." check IMPORTANT in Events
        //----------------------------------------------------------------
        private void dgvCheck_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCalculateSP.CurrentCell.ColumnIndex == 0)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvCheck_KeyPress);
            }
        }
        //----------------------------------------------------------------------------------
        // DataGridView number and only one "." check (after check remove from Events !!!)
        //----------------------------------------------------------------------------------
        private void dgvCheck_KeyPress(object sender, KeyPressEventArgs e)
        {   
            // digits and "." only
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only one "."
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }


        }



        //-------------------------------------
        // Calculate GM and kr according to B
        //-------------------------------------
        private void BTB_Leave(object sender, EventArgs e)
        {
            double bTB = Convert.ToDouble(BTB.Text);
            double gmCalc = bTB * 0.07;
            double krCalc = bTB * 0.39;
            gmTB.Text = gmCalc.ToString("0.00");
            krTB.Text = krCalc.ToString("0.00");
        }
        //-------------------------
        // Values for Service area
        //-------------------------
        private void saCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (saCB.Text == "R0 (No reduction)")
            {
                double frTB = 1.0;
            }
            else if(saCB.Text == "R1 (10% reduction)")
            {
                double frTB = 0.9;
            }
            else if(saCB.Text == "R2 (20% reduction)")
            {
                double frTB = 0.8;
            }
            else if (saCB.Text == "R3 (30% reduction)")
            {
                double frTB = 0.7;
            }
            else if (saCB.Text == "R4 (40% reduction)")
            {
                double frTB = 0.6;
            }
            else if (saCB.Text == "RE (50% reduction)")
            {
                double frTB = 0.5;
            }
        }
        //------------------------------------------------------------
        // Save button for Calculate Table (Sea Pressure)
        //------------------------------------------------------------
        private void saveCalcSP_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("itemstable");

            for (int i = 0; i < dgvCalculateSP.ColumnCount; i++)
            {
                dt.Columns.Add(dgvCalculateSP.Columns[i].Name, typeof(System.String));
            }

            DataRow myrow;
            int icols = dgvCalculateSP.Columns.Count;
            foreach (DataGridViewRow drow in this.dgvCalculateSP.Rows)
            {
                myrow = dt.NewRow();
                for (int i = 0; i <= icols - 1; i++)
                {

                    myrow[i] = drow.Cells[i].Value;
                }
                dt.Rows.Add(myrow);
            }

            dt.WriteXml("saveCalcSP.xml");

        }
        //----------------------------------
        // Load saved data for Sea Pressure
        //----------------------------------
        private void loadDataSP_Click(object sender, EventArgs e)
        {

            //check to avoid load data when table already exist.
            if(dgvCalculateSP.ColumnCount == 0)
                { 
                try
                {

                    // load data into table
                    XmlReader xmlFile;
                    xmlFile = XmlReader.Create("saveCalcSP.xml", new XmlReaderSettings());
                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlFile);
                    dgvCalculateSP.DataSource = ds.Tables[0];
                    xmlFile.Close();
                    //unselect 1st cell
                    dgvCalculateSP.ClearSelection();
                    // load ComboBox
                    for (int i = 0; i < dgvCalculateSP.ColumnCount; i++)
                    {
                        dgvCalculateSP.Rows[0].Cells[i].Value = null; //this is important.

                        // f_u
                        DataGridViewComboBoxCell f_u = new DataGridViewComboBoxCell();
                        f_u.Items.Add("1");
                        f_u.Items.Add("1.03");
                        f_u.Items.Add("1.15");

                        dgvCalculateSP.Rows[22].Cells[i].Value = ds.Tables[0].Rows[22][i].ToString();
                        dgvCalculateSP.Rows[22].Cells[i] = f_u;

                        // f_bdg
                        DataGridViewComboBoxCell f_bdg = new DataGridViewComboBoxCell();
                        f_bdg.Items.Add("8");
                        f_bdg.Items.Add("10");
                        f_bdg.Items.Add("12");
                        dgvCalculateSP.Rows[23].Cells[i].Value = ds.Tables[0].Rows[23][i].ToString();
                        dgvCalculateSP.Rows[23].Cells[i] = f_bdg;

                        // fshr
                        DataGridViewComboBoxCell fshr = new DataGridViewComboBoxCell();
                        fshr.Items.Add("Upper end of vertical stiffeners");
                        fshr.Items.Add("Lower end of vertical stiffeners");
                        fshr.Items.Add("General");
                        dgvCalculateSP.Rows[30].Cells[i].Value = ds.Tables[0].Rows[30][i].ToString();
                        dgvCalculateSP.Rows[30].Cells[i] = fshr;
                        

                        


                        RowsColorCalculate();
                    }
                    // load Delete Buttons
                    for (int i = 0; i < dgvCalculateSP.Columns.Count; i++)
                    {
                        var deleteButtonSP = new DataGridViewButtonColumn();
                        deleteButtonSP.Name = "dgvDeleteButton";
                        deleteButtonSP.HeaderText = "Delete";
                        deleteButtonSP.Text = "Delete";
                        deleteButtonSP.UseColumnTextForButtonValue = true;
                        this.dgvDeleteSP.Columns.Add(deleteButtonSP);
                            if (dgvDeleteSP.Rows.Count == 0)
                            {
                                dgvDeleteSP.Rows.Add();
                            }
                    }
                }
                catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            else
            {
                MessageBox.Show("Data inside table already exists, Please clear table before.");
            }
        }
        static DataSet ds_input = new DataSet();
        //--------------------------------
        // Button delete for Sea Pressure
        //--------------------------------
        private void dgvDeleteSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvCalculateSP.Columns.Count; i++)
            {
                if (e.ColumnIndex == dgvDeleteSP.Columns[i].DisplayIndex)
                {
                    dgvCalculateSP.Columns.RemoveAt(e.ColumnIndex);
                    dgvDeleteSP.Columns.RemoveAt(e.ColumnIndex);
                }
            }
        }
        //-----------------------------------------------------------
        // Synchronize horizontal Scroll bar calculateSP - Delete SP
        //-----------------------------------------------------------
        private void dgvDeleteSP_Scroll(object sender, ScrollEventArgs e)
        {
            dgvCalculateSP.HorizontalScrollingOffset = dgvDeleteSP.HorizontalScrollingOffset;
        }
        //-------------------
        // Check if b < a !!
        //-------------------
        private void dgvCalculateSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // correct
            if (dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Value != null && Convert.ToDecimal(dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Value) < Convert.ToDecimal(dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Value) && dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Value != null)
            {
                dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.PaleGreen };
                dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.PaleGreen };
            }
            // waiting for value
            else if (dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Value != null && Convert.ToDecimal(dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Value) < Convert.ToDecimal(dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Value) && dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Value == null)
            {
                dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Azure };
                dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Azure };
            }
            // wrong
            else if (dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Value != null && Convert.ToDecimal(dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Value) >= Convert.ToDecimal(dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Value) && dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Value != null)
            {
                dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Red };
                dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Red };
            }
            // start
            else
            {
                dgvCalculateSP.Rows[6].Cells[e.ColumnIndex].Style.BackColor = Color.Azure;
                dgvCalculateSP.Rows[7].Cells[e.ColumnIndex].Style.BackColor = Color.Azure;
            }
        }
       //------------------------------------
       // Calculate module for DataGridView
       //------------------------------------
        private void dgvCalculateSP_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvCalculateSP.Columns.Count; i++)
            {
                //=================
                //calculate alpha
                //=================
                double bInput = Convert.ToDouble(dgvCalculateSP.Rows[6].Cells[i].Value);
                double aInput = Convert.ToDouble(dgvCalculateSP.Rows[7].Cells[i].Value);

                if (dgvCalculateSP.Rows[6].Cells[i].Value != null && dgvCalculateSP.Rows[7].Cells[i].Value != null && (1.2 - (bInput / (2.1 * aInput))) < 1)
                {
                    double alphaOutput = Math.Round((1.2 - (bInput / (2.1 * aInput))),2);
                    dgvCalculateSP.Rows[8].Cells[i].Value = alphaOutput;
                }
                else
                {
                    double alphaOutput = 1;
                    dgvCalculateSP.Rows[8].Cells[i].Value = alphaOutput;
                }
                //=====================
                //calculate X'(Plate) ====================>>>>>>>>> dodac sprawdzenie pustych pol Lpp i LTB
                //=====================
                decimal LppInput = Convert.ToDecimal(LppTB.Text);
                decimal LInput = Convert.ToDecimal(LTB.Text);

                decimal xplateLoadInput = 0;
                object xplateCheck = (sender as DataGridView).Rows[1].Cells[i].Value;
                if (xplateCheck != DBNull.Value)
                {
                    xplateLoadInput = Convert.ToDecimal(xplateCheck);

                    if (LppInput > LInput && LppInput != 0 && LInput != 0)
                    {
                        decimal xPrimPlateOutput = xplateLoadInput - (LppInput - LInput);
                        dgvCalculateSP.Rows[44].Cells[i].Value = xPrimPlateOutput;
                    }
                    else if (LppInput < LInput && LppInput != 0 && LInput != 0)
                    {
                        decimal xPrimPlateOutput = xplateLoadInput + (LInput - LppInput);
                        dgvCalculateSP.Rows[44].Cells[i].Value = xPrimPlateOutput;
                    }
                    else if (LppInput == LInput && LppInput != 0 && LInput != 0)
                    {
                        dgvCalculateSP.Rows[44].Cells[i].Value = xplateLoadInput;
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[44].Cells[i].Value = "No Value!";
                }
                //=========================
                //calculate X'(Stiffener)
                //=========================
                decimal xstiffLoadInput = 0;
                object xstiffCheck = (sender as DataGridView).Rows[16].Cells[i].Value;
                if (xstiffCheck != DBNull.Value)
                {
                    xstiffLoadInput = Convert.ToDecimal(xstiffCheck);

                    if (LppInput > LInput && LppInput != 0 && LInput != 0)
                    {
                        decimal xPrimStiffOutput = xstiffLoadInput - (LppInput - LInput);
                        dgvCalculateSP.Rows[45].Cells[i].Value = xPrimStiffOutput;
                    }
                    else if (LppInput < LInput && LppInput != 0 && LInput != 0)
                    {
                        decimal xPrimStiffOutput = xstiffLoadInput + (LInput - LppInput);
                        dgvCalculateSP.Rows[45].Cells[i].Value = xPrimStiffOutput;
                    }
                    else if (LppInput == LInput && LppInput != 0 && LInput != 0)
                    {
                        dgvCalculateSP.Rows[45].Cells[i].Value = xstiffLoadInput;
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[45].Cells[i].Value = "No Value!";
                }
                //=======================
                // calculate fyB (Plate)
                //=======================
                decimal yplateLoadInput = 0;
                decimal bXplateInput = 0;
                object yplateCheck = (sender as DataGridView).Rows[2].Cells[i].Value;
                object bXplateCheck = (sender as DataGridView).Rows[4].Cells[i].Value;
                if (yplateCheck != DBNull.Value && bXplateCheck != DBNull.Value)
                {
                    yplateLoadInput = Convert.ToDecimal(yplateCheck);
                    bXplateInput = Convert.ToDecimal(bXplateCheck);
                    decimal[] fyBplateArray = { (2*yplateLoadInput)/bXplateInput, 1 };

                    decimal fybPlateOutput = fyBplateArray.Select(Math.Abs).Min();

                    dgvCalculateSP.Rows[46].Cells[i].Value = Math.Round(fybPlateOutput,2);
                }
                else
                {
                    dgvCalculateSP.Rows[46].Cells[i].Value = "No Value!";
                }
                //===========================
                // calculate fyB (stiffener)
                //===========================
                decimal ystiffLoadInput = 0;
                decimal bXstiffInput = 0;
                object ystiffCheck = (sender as DataGridView).Rows[17].Cells[i].Value;
                object bXstiffCheck = (sender as DataGridView).Rows[19].Cells[i].Value;
                if (ystiffCheck != DBNull.Value && bXstiffCheck != DBNull.Value)
                {
                    ystiffLoadInput = Convert.ToDecimal(ystiffCheck);
                    bXstiffInput = Convert.ToDecimal(bXstiffCheck);
                    decimal[] fyBstiffArray = { (2 * ystiffLoadInput) / bXstiffInput, 1 };

                    decimal fybStiffOutput = fyBstiffArray.Select(Math.Abs).Min();

                    dgvCalculateSP.Rows[47].Cells[i].Value = Math.Round(fybStiffOutput, 2);
                }
                else
                {
                    dgvCalculateSP.Rows[47].Cells[i].Value = "No Value!";
                }
                //=============
                // fyz (plate)
                //=============
                double zplateLoadInput = 0;
                double fyBplateInput = 0;

                //check if Tsc is not empty!
                if(!string.IsNullOrEmpty(TscTB.Text))
                {
                    double tSCInput = Convert.ToDouble(TscTB.Text);
                    object zplateCheck = (sender as DataGridView).Rows[3].Cells[i].Value;
                    object fyBplateCheck = (sender as DataGridView).Rows[46].Cells[i].Value;

                    if (zplateCheck != DBNull.Value && fyBplateCheck != DBNull.Value)
                    {
                        zplateLoadInput = Convert.ToDouble(zplateCheck);
                        fyBplateInput = Convert.ToDouble(fyBplateCheck);
                        double fyzPlateOutput = 0.5 * (zplateLoadInput / tSCInput) + 2.5 * fyBplateInput + 2;
                        dgvCalculateSP.Rows[48].Cells[i].Value = Math.Round(fyzPlateOutput, 2);
                    }
                    else
                    {
                        dgvCalculateSP.Rows[48].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[48].Cells[i].Value = "Tsc is empty!";
                }
                //=================
                // fyz (stiffener)
                //=================
                double zstiffLoadInput = 0;
                double fyBstiffInput = 0;

                //check if Tsc is not empty!
                if(!string.IsNullOrEmpty(TscTB.Text))
                {
                    double tSCInput = Convert.ToDouble(TscTB.Text);
                    object zstiffCheck = (sender as DataGridView).Rows[18].Cells[i].Value;
                    object fyBstiffCheck = (sender as DataGridView).Rows[47].Cells[i].Value;

                    if(zstiffCheck != DBNull.Value && fyBstiffCheck != DBNull.Value)
                    {
                        zstiffLoadInput = Convert.ToDouble(zstiffCheck);
                        fyBstiffInput = Convert.ToDouble(fyBstiffCheck);
                        double fyzStiffOutput = 0.5 * (zstiffLoadInput / tSCInput) + 2.5 * fyBstiffInput + 2;
                        dgvCalculateSP.Rows[49].Cells[i].Value = Math.Round(fyzStiffOutput, 2);
                    }
                    else
                    {
                        dgvCalculateSP.Rows[49].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[49].Cells[i].Value = "Tsc is empty!";
                }
                //=============
                // fxL (plate)
                //=============
                double xPrimPlateInput = 0;

                //check if L "rule" is not empty
                if(!string.IsNullOrEmpty(LTB.Text))
                {
                    double LruleInput = Convert.ToDouble(LTB.Text);
                    object xPrimplateCheck = (sender as DataGridView).Rows[44].Cells[i].Value;

                    if(xPrimplateCheck !=DBNull.Value)
                    {
                        xPrimPlateInput = Convert.ToDouble(xPrimplateCheck);
                        double fxLplateOutput = xPrimPlateInput / LruleInput;
                        dgvCalculateSP.Rows[50].Cells[i].Value = Math.Round(fxLplateOutput, 2);
                    }
                    else
                    {
                        dgvCalculateSP.Rows[50].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[50].Cells[i].Value = "L Rule is empty!";
                }
                //=================
                // fxL (stiffener)
                //=================
            }
        }

        //----------------------------------------
        // TEST AREA FOR REMOVE == START ==
        //----------------------------------------
        private void buttonTest_Click(object sender, EventArgs e)
        {
            // string someString = dataGridView1[0, 2].Value.ToString();
            // dataGridView1.Rows[4].Cells[0].Value = someString;
            //dgvCalculate.Rows[5].Cells[i].Value = dgvCalculate.Rows[4].Cells[i].Value;
            for (int i = 0; i < dgvCalculateSP.Columns.Count; i++)
            {
                string kolumna = dgvCalculateSP[i, 4].Value.ToString();
                dgvCalculateSP.Rows[6].Cells[i].Value = kolumna;


            }
        }

        //----------------------------------------
        // TEST AREA FOR REMOVE == END ==
        //----------------------------------------

    }

}