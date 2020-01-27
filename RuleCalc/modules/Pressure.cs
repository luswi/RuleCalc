using EPT.classes;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

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
        //---------------------
        // Convert Deg to Rad
        //---------------------
        private double DegToRad(double angle)
        {
            return Math.PI * angle / 180.0;
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
            dgvNames.Rows.Add("fshr");

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
            for (int i = 0; i < dgvNames.Rows.Count; i++)
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
                else if (i == 25)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i == 27)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i == 31)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
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
                else if (i > 43 & i < 72)
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
            dgvNames.Rows[0].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
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

            for (int i = 0; i < dgvNames.Rows.Count; i++)
            {
                if (i >= 60 && i <= 71)
                {
                    dgvNames.Rows[i].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
                }
            }

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
                for (int i = 0; i <= 72; i++)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
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
                double frValue = 1.0;
                frTB.Text = frValue.ToString("0.00");
            }
            else if (saCB.Text == "R1 (10% reduction)")
            {
                double frValue = 0.9;
                frTB.Text = frValue.ToString("0.00");
            }
            else if (saCB.Text == "R2 (20% reduction)")
            {
                double frValue = 0.8;
                frTB.Text = frValue.ToString("0.00");
            }
            else if (saCB.Text == "R3 (30% reduction)")
            {
                double frValue = 0.7;
                frTB.Text = frValue.ToString("0.00");
            }
            else if (saCB.Text == "R4 (40% reduction)")
            {
                double frValue = 0.6;
                frTB.Text = frValue.ToString("0.00");
            }
            else if (saCB.Text == "RE (50% reduction)")
            {
                double frValue = 0.5;
                frTB.Text = frValue.ToString("0.00");
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
            if (dgvCalculateSP.ColumnCount == 0)
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

            if (e.ColumnIndex == 0)
            {
                e.CellStyle.Format = "N2";
            }

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
                    double alphaOutput = (1.2 - (bInput / (2.1 * aInput)));
                    dgvCalculateSP.Rows[8].Cells[i].Value = alphaOutput;
                }
                else
                {
                    double alphaOutput = 1;
                    dgvCalculateSP.Rows[8].Cells[i].Value = alphaOutput;
                }

                //=====================
                // Calculate dshr [mm]
                //=====================

                object degStiff = (sender as DataGridView).Rows[28].Cells[i].Value;
                object deg7090 = (sender as DataGridView).Rows[70].Cells[i].Value;
                object deg75 = (sender as DataGridView).Rows[71].Cells[i].Value;

                if (degStiff != DBNull.Value && deg7090 != DBNull.Value && deg75 != DBNull.Value)
                {
                    double degStiffInput = Convert.ToDouble(degStiff);
                    double deg7090Input = Convert.ToDouble(deg7090);
                    double deg75Input = Convert.ToDouble(deg75);

                    if (degStiffInput <= 75)
                    {
                        dgvCalculateSP.Rows[25].Cells[i].Value = deg75Input;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[25].Cells[i].Value = deg7090Input;
                    }

                }
                else
                {
                    dgvCalculateSP.Rows[25].Cells[i].Value = "No Value!";
                }


                //=====================
                //calculate X'(Plate)
                //=====================

                decimal LppInput = Convert.ToDecimal(LppTB.Text);
                if (!string.IsNullOrEmpty(LppTB.Text) && !string.IsNullOrEmpty(LTB.Text) && LppInput != 0)
                {

                    decimal LInput = Convert.ToDecimal(LTB.Text);

                    decimal xplateLoadInput = 0;
                    object xplateCheck = (sender as DataGridView).Rows[1].Cells[i].Value;
                    if (xplateCheck != null)
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
                }
                else
                {
                    dgvCalculateSP.Rows[44].Cells[i].Value = "No Value!";
                }
                //=========================
                //calculate X'(Stiffener)
                //=========================
                if (!string.IsNullOrEmpty(LppTB.Text) && !string.IsNullOrEmpty(LTB.Text) && LppInput != 0)
                {


                    decimal LInput = Convert.ToDecimal(LTB.Text);
                    decimal xstiffLoadInput = 0;

                    object xstiffCheck = (sender as DataGridView).Rows[16].Cells[i].Value;
                    if (xstiffCheck != null)
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
                if (yplateCheck != null && bXplateCheck != null)
                {

                    yplateLoadInput = Convert.ToDecimal(yplateCheck);
                    bXplateInput = Convert.ToDecimal(bXplateCheck);
                    decimal[] fyBplateArray = { (2 * yplateLoadInput) / bXplateInput, 1 };

                    decimal fybPlateOutput = fyBplateArray.Select(Math.Abs).Min();

                    dgvCalculateSP.Rows[46].Cells[i].Value = fybPlateOutput;

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
                if (ystiffCheck != null && bXstiffCheck != null)
                {
                    ystiffLoadInput = Convert.ToDecimal(ystiffCheck);
                    bXstiffInput = Convert.ToDecimal(bXstiffCheck);
                    decimal[] fyBstiffArray = { (2 * ystiffLoadInput) / bXstiffInput, 1 };

                    decimal fybStiffOutput = fyBstiffArray.Select(Math.Abs).Min();

                    dgvCalculateSP.Rows[47].Cells[i].Value = fybStiffOutput;
                }
                else
                {
                    dgvCalculateSP.Rows[47].Cells[i].Value = "No Value!";
                }
                //=============
                // fyz (plate)
                //=============
                double zplateLoadInput = 0.00;
                double fyBplateInput = 0.00;

                //check if Tsc is not empty!
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double tSCInput = Convert.ToDouble(TscTB.Text);
                    object zplateCheck = (sender as DataGridView).Rows[3].Cells[i].Value;
                    object fyBplateCheck = (sender as DataGridView).Rows[46].Cells[i].Value;

                    if (zplateCheck != null && !fyBplateCheck.Equals("No Value!"))
                    {
                        zplateLoadInput = Convert.ToDouble(zplateCheck);
                        fyBplateInput = Convert.ToDouble(fyBplateCheck);
                        double fyzPlateOutput = 0.5 * (zplateLoadInput / tSCInput) + 2.5 * fyBplateInput + 2;
                        dgvCalculateSP.Rows[48].Cells[i].Value = fyzPlateOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[48].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[48].Cells[i].Value = "No Value!";
                }
                //=================
                // fyz (stiffener)
                //=================
                double zstiffLoadInput = 0;
                double fyBstiffInput = 0;

                //check if Tsc is not empty!
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double tSCInput = Convert.ToDouble(TscTB.Text);
                    object zstiffCheck = (sender as DataGridView).Rows[18].Cells[i].Value;
                    object fyBstiffCheck = (sender as DataGridView).Rows[47].Cells[i].Value;

                    if (zstiffCheck != null && !fyBstiffCheck.Equals("No Value!"))
                    {
                        zstiffLoadInput = Convert.ToDouble(zstiffCheck);
                        fyBstiffInput = Convert.ToDouble(fyBstiffCheck);
                        double fyzStiffOutput = 0.5 * (zstiffLoadInput / tSCInput) + 2.5 * fyBstiffInput + 2;
                        dgvCalculateSP.Rows[49].Cells[i].Value = fyzStiffOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[49].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[49].Cells[i].Value = "No Value!";
                }
                //=============
                // fxL (plate)
                //=============
                double xPrimPlateInput = 0;

                //check if L "rule" is not empty
                if (!string.IsNullOrEmpty(LTB.Text))
                {
                    double LruleInput = Convert.ToDouble(LTB.Text);
                    object xPrimPlateCheck = (sender as DataGridView).Rows[44].Cells[i].Value;

                    //if(!xPrimPlateCheck.Equals("No Value!"))
                    if (xPrimPlateCheck != null)
                    {
                        xPrimPlateInput = Convert.ToDouble(xPrimPlateCheck);
                        double fxLplateOutput = xPrimPlateInput / LruleInput;
                        dgvCalculateSP.Rows[50].Cells[i].Value = fxLplateOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[50].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[50].Cells[i].Value = "No Value!";
                }
                //=================
                // fxL (stiffener)
                //=================
                double xPrimStiffInput = 0;

                //check if L "rule" is not empty
                if (!string.IsNullOrEmpty(LTB.Text))
                {
                    double LruleInput = Convert.ToDouble(LTB.Text);
                    object xPrimStiffCheck = (sender as DataGridView).Rows[45].Cells[i].Value;

                    if (xPrimStiffCheck != null)
                    {
                        xPrimStiffInput = Convert.ToDouble(xPrimStiffCheck);
                        double fxLstiffOutput = xPrimStiffInput / LruleInput;
                        dgvCalculateSP.Rows[51].Cells[i].Value = fxLstiffOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[51].Cells[i].Value = "No Value!";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[51].Cells[i].Value = "No Value!";
                }
                //======
                // f_3
                //======
                if (!string.IsNullOrEmpty(LTB.Text) && !string.IsNullOrEmpty(BTB.Text) && !string.IsNullOrEmpty(CbTB.Text))
                {
                    double LruleInput = Convert.ToDouble(LTB.Text);
                    double BInput = Convert.ToDouble(BTB.Text);
                    double CbInput = Convert.ToDouble(CbTB.Text);
                    //array for max value
                    double[] f_3Array = { 0.6, 0.05 + CbInput, 1.1 - 0.1 * (LruleInput / BInput) };
                    //select max value
                    double f_3ArrayOutput = f_3Array.Max();
                    dgvCalculateSP.Rows[52].Cells[i].Value = f_3ArrayOutput;
                }
                else
                {
                    dgvCalculateSP.Rows[52].Cells[i].Value = "No Value!";
                }

                //============================
                // f_4 (based on f_xl, plate)
                //============================
                double fxLplateInput = 0;

                object fxLplateCheck = (sender as DataGridView).Rows[50].Cells[i].Value;
                if (!fxLplateCheck.Equals("No Value!"))
                {
                    fxLplateInput = Convert.ToDouble(fxLplateCheck);
                    if (fxLplateInput < 0.2)
                    {
                        double[] f_4Array = { 2, (-5 * fxLplateInput + 2) };
                        double f_4ArrayOutput = f_4Array.Min();
                        dgvCalculateSP.Rows[53].Cells[i].Value = f_4ArrayOutput;
                    }
                    else if (fxLplateInput > 0.6)
                    {
                        double[] f_4Array = { 3, fxLplateInput - 2 };
                        double f_4ArrayOutput = f_4Array.Min();
                        dgvCalculateSP.Rows[53].Cells[i].Value = f_4ArrayOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[53].Cells[i].Value = 1;
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[53].Cells[i].Value = "No Value!";
                }

                //=================================
                // f_4 (based on f_xl, stiffeners)
                //=================================
                double fxLstiffInput = 0.00;

                object fxLstiffCheck = (sender as DataGridView).Rows[51].Cells[i].Value;
                if (!fxLstiffCheck.Equals("No Value!"))
                {
                    fxLstiffInput = Convert.ToDouble(fxLstiffCheck);
                    if (fxLstiffInput < 0.2)
                    {
                        double[] f_4Array = { 2, (-5 * fxLstiffInput + 2) };
                        double f_4ArrayOutput = f_4Array.Min();
                        dgvCalculateSP.Rows[54].Cells[i].Value = f_4ArrayOutput;
                    }
                    else if (fxLplateInput > 0.6)
                    {
                        double[] f_4Array = { 3, fxLstiffInput - 2 };
                        double f_4ArrayOutput = f_4Array.Min();
                        dgvCalculateSP.Rows[54].Cells[i].Value = f_4ArrayOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[54].Cells[i].Value = 1;
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[54].Cells[i].Value = "No Value!";
                }
                //=============
                // f_5 (plate)
                //=============
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double TscInput = Convert.ToDouble(TscTB.Text);
                    object zPlateCheck = (sender as DataGridView).Rows[3].Cells[i].Value;
                    if (zPlateCheck != null)
                    {
                        double zPlateInput = 0;
                        zPlateInput = Convert.ToDouble(zPlateCheck);
                        double f_5PlateOutput = 0.2 * (4 + (zPlateInput / TscInput));
                        dgvCalculateSP.Rows[55].Cells[i].Value = f_5PlateOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[55].Cells[i].Value = "No Value!";
                    }
                }


                //===================
                // f_5 (stiffeners)
                //===================
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double TscInput = Convert.ToDouble(TscTB.Text);
                    object zStiffCheck = (sender as DataGridView).Rows[18].Cells[i].Value;
                    if (zStiffCheck != null)
                    {
                        double zStiffInput = 0;
                        zStiffInput = Convert.ToDouble(zStiffCheck);
                        double f_5StiffOutput = 0.2 * (4 + (zStiffInput / TscInput));
                        dgvCalculateSP.Rows[56].Cells[i].Value = f_5StiffOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[56].Cells[i].Value = "No Value!";
                    }
                }
                //=====
                // Cw
                //=====
                if (!string.IsNullOrEmpty(LTB.Text))
                {
                    double LTBInput = Convert.ToDouble(LTB.Text);
                    double CwOutput = 0.0856 * LTBInput;
                    dgvCalculateSP.Rows[57].Cells[i].Value = CwOutput;
                }
                else
                {
                    dgvCalculateSP.Rows[57].Cells[i].Value = "No Value!";
                }
                //=====================
                // Pw,wl (plate) [MPa]
                //=====================

                if (!string.IsNullOrEmpty(frTB.Text) && !string.IsNullOrEmpty(LTB.Text) && !string.IsNullOrEmpty(TscTB.Text) && !string.IsNullOrEmpty(CbTB.Text))
                {
                    double frTBInput = Convert.ToDouble(frTB.Text);
                    double LTBInput = Convert.ToDouble(LTB.Text);
                    double TscTBInput = Convert.ToDouble(TscTB.Text);
                    double CbTBInput = Convert.ToDouble(CbTB.Text);

                    object f_3Check = (sender as DataGridView).Rows[52].Cells[i].Value;
                    object f_4PlateCheck = (sender as DataGridView).Rows[53].Cells[i].Value;
                    object CwCheck = (sender as DataGridView).Rows[57].Cells[i].Value;
                    if (!f_3Check.Equals("No Valu!") && !f_4PlateCheck.Equals("No Value!") && !CwCheck.Equals("No Value!"))
                    {
                        double f_3Input = Convert.ToDouble(f_3Check);
                        double f_4PlateInput = Convert.ToDouble(f_4PlateCheck);
                        double CwInput = Convert.ToDouble(CwCheck);

                        double[] PwwlPlateArray = { frTBInput * (f_3Input * (2 + (55 / LTBInput)) * (0.5 * (TscTBInput / TscTBInput) + (2.5 * (1)) + 2) * CwInput), 5 * frTBInput * f_4PlateInput * 0.2 * (4 + TscTBInput / TscTBInput) * (1 - CbTBInput / 3) * CwInput * Math.Sqrt((1.2 * LTBInput - 15) / LTBInput) };
                        double PwwlPlateArrayOutput = PwwlPlateArray.Max();
                        dgvCalculateSP.Rows[58].Cells[i].Value = PwwlPlateArrayOutput;

                    }
                }
                else
                {
                    dgvCalculateSP.Rows[58].Cells[i].Value = "No Value!";
                }

                //==========================
                // Pw,wl (stiffeners) [MPa]
                //==========================
                if (!string.IsNullOrEmpty(frTB.Text) && !string.IsNullOrEmpty(LTB.Text) && !string.IsNullOrEmpty(TscTB.Text) && !string.IsNullOrEmpty(CbTB.Text))
                {
                    double frTBInput = Convert.ToDouble(frTB.Text);
                    double LTBInput = Convert.ToDouble(LTB.Text);
                    double TscTBInput = Convert.ToDouble(TscTB.Text);
                    double CbTBInput = Convert.ToDouble(CbTB.Text);

                    object f_3Check = (sender as DataGridView).Rows[52].Cells[i].Value;
                    object f_4StiffCheck = (sender as DataGridView).Rows[54].Cells[i].Value;
                    object CwCheck = (sender as DataGridView).Rows[57].Cells[i].Value;
                    if (!f_3Check.Equals("No Value!") && !f_4StiffCheck.Equals("No Value!") && !CwCheck.Equals("No Value!"))
                    {
                        double f_3Input = Convert.ToDouble(f_3Check);
                        double f_4StiffInput = Convert.ToDouble(f_4StiffCheck);
                        double CwInput = Convert.ToDouble(CwCheck);

                        double[] PwwlStiffArray = { frTBInput * (f_3Input * (2 + (55 / LTBInput)) * (0.5 * (TscTBInput / TscTBInput) + (2.5 * (1)) + 2) * CwInput), 5 * frTBInput * f_4StiffInput * 0.2 * (4 + TscTBInput / TscTBInput) * (1 - CbTBInput / 3) * CwInput * Math.Sqrt((1.2 * LTBInput - 15) / LTBInput) };
                        double PwwlStiffArrayOutput = PwwlStiffArray.Max();
                        dgvCalculateSP.Rows[59].Cells[i].Value = PwwlStiffArrayOutput;
                    }

                }
                else
                {
                    dgvCalculateSP.Rows[59].Cells[i].Value = "No Value!";
                }
                //=====================
                // P_ENV (plate) [MPa]
                //=====================
                if (!string.IsNullOrEmpty(frTB.Text) && !string.IsNullOrEmpty(LTB.Text) && !string.IsNullOrEmpty(CbTB.Text))
                {
                    double frTBInput = Convert.ToDouble(frTB.Text);
                    double LTBInput = Convert.ToDouble(LTB.Text);
                    double CbTBInput = Convert.ToDouble(CbTB.Text);

                    object fyzPlateCheck = (sender as DataGridView).Rows[48].Cells[i].Value;
                    object f_3Check = (sender as DataGridView).Rows[52].Cells[i].Value;
                    object f_4PlateCheck = (sender as DataGridView).Rows[53].Cells[i].Value;
                    object f_5PlateCheck = (sender as DataGridView).Rows[55].Cells[i].Value;
                    object CwCheck = (sender as DataGridView).Rows[57].Cells[i].Value;

                    if (!fyzPlateCheck.Equals("No Value!") && !f_3Check.Equals("No Value!") && !f_4PlateCheck.Equals("No Value!") && !f_5PlateCheck.Equals("No Value!") && !CwCheck.Equals("No Value!"))
                    {
                        double fyzPlateInput = Convert.ToDouble(fyzPlateCheck);
                        double f_3Input = Convert.ToDouble(f_3Check);
                        double f_4PlateInput = Convert.ToDouble(f_4PlateCheck);
                        double f_5PlateInput = Convert.ToDouble(f_5PlateCheck);
                        double CwInput = Convert.ToDouble(CwCheck);

                        double[] PenvPlateArray = { frTBInput * f_3Input * (2 + 55 / LTBInput) * fyzPlateInput * CwInput, 5 * frTBInput * f_4PlateInput * f_5PlateInput * (1 - CbTBInput / 3) * CwInput * Math.Sqrt((1.2 * LTBInput - 15) / LTBInput) };
                        double PenvPlateArrayOutput = PenvPlateArray.Max();
                        dgvCalculateSP.Rows[60].Cells[i].Value = PenvPlateArrayOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[60].Cells[i].Value = "No Value!";
                    }

                }

                //==========================
                // P_ENV (stiffeners) [MPa]
                //==========================
                if (!string.IsNullOrEmpty(frTB.Text) && !string.IsNullOrEmpty(LTB.Text) && !string.IsNullOrEmpty(CbTB.Text))
                {
                    double frTBInput = Convert.ToDouble(frTB.Text);
                    double LTBInput = Convert.ToDouble(LTB.Text);
                    double CbTBInput = Convert.ToDouble(CbTB.Text);

                    object fyzStiffCheck = (sender as DataGridView).Rows[49].Cells[i].Value;
                    object f_3Check = (sender as DataGridView).Rows[52].Cells[i].Value;
                    object f_4StiffCheck = (sender as DataGridView).Rows[54].Cells[i].Value;
                    object f_5StiffCheck = (sender as DataGridView).Rows[56].Cells[i].Value;
                    object CwCheck = (sender as DataGridView).Rows[57].Cells[i].Value;

                    if (!fyzStiffCheck.Equals("No Value!") && !f_3Check.Equals("No Value!") && !f_4StiffCheck.Equals("No Value!") && !f_5StiffCheck.Equals("No Value!") && !CwCheck.Equals("No Value!"))
                    {
                        double fyzStiffInput = Convert.ToDouble(fyzStiffCheck);
                        double f_3Input = Convert.ToDouble(f_3Check);
                        double f_4StiffInput = Convert.ToDouble(f_4StiffCheck);
                        double f_5StiffInput = Convert.ToDouble(f_5StiffCheck);
                        double CwInput = Convert.ToDouble(CwCheck);

                        double[] PenvStiffArray = { frTBInput * f_3Input * (2 + 55 / LTBInput) * fyzStiffInput * CwInput, 5 * frTBInput * f_4StiffInput * f_5StiffInput * (1 - CbTBInput / 3) * CwInput * Math.Sqrt((1.2 * LTBInput - 15) / LTBInput) };
                        double PenvStiffArrayOutput = PenvStiffArray.Max();
                        dgvCalculateSP.Rows[61].Cells[i].Value = PenvStiffArrayOutput;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[61].Cells[i].Value = "No Value!";
                    }
                }
                //=======================
                // P (SEA-1) [MPa] plate
                //=======================
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double TscTBInput = Convert.ToDouble(TscTB.Text);

                    object zPlateCheck = (sender as DataGridView).Rows[3].Cells[i].Value;
                    object PWwlPlateCheck = (sender as DataGridView).Rows[58].Cells[i].Value;
                    object P_EnvPlateCheck = (sender as DataGridView).Rows[60].Cells[i].Value;

                    double zPlateLoadInput = 0;

                    if (zPlateCheck != null && !P_EnvPlateCheck.Equals("No Value!"))
                    {
                        zPlateLoadInput = Convert.ToDouble(zPlateCheck);
                        double PWwlPlateInput = Convert.ToDouble(PWwlPlateCheck);
                        double P_EnvPlateInput = Convert.ToDouble(P_EnvPlateCheck);
                        if (zPlateLoadInput <= TscTBInput)
                        {
                            double Psea1PlateOutput = P_EnvPlateInput + 9.81 * 1.025 * (TscTBInput - zPlateLoadInput);
                            dgvCalculateSP.Rows[62].Cells[i].Value = Psea1PlateOutput;
                        }
                        else if (zPlateLoadInput < PWwlPlateInput / (1.025 * 9.81) + TscTBInput)
                        {
                            double Psea1PlateOutput = PWwlPlateInput - 1.025 * 9.81 * (zplateLoadInput - TscTBInput);
                            dgvCalculateSP.Rows[62].Cells[i].Value = Psea1PlateOutput;
                        }
                    }
                    else
                    {
                        double Psea1PlateOutput = 0.0;
                        dgvCalculateSP.Rows[62].Cells[i].Value = Psea1PlateOutput;
                    }
                }


                //=======================
                // P (SEA-2) [MPa] plate
                //=======================
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double TscTBInput = Convert.ToDouble(TscTB.Text);

                    object zPlateCheck = (sender as DataGridView).Rows[3].Cells[i].Value;

                    double zPlateLoadInput = 0;

                    if (zPlateCheck != null)
                    {
                        zPlateLoadInput = Convert.ToDouble(zPlateCheck);
                        if (zPlateLoadInput <= TscTBInput)
                        {
                            double Psea2PlateOutput = 9.81 * 1.025 * (TscTBInput - zPlateLoadInput);
                            dgvCalculateSP.Rows[63].Cells[i].Value = Psea2PlateOutput;
                        }
                        else
                        {
                            dgvCalculateSP.Rows[63].Cells[i].Value = 0.0;
                        }
                    }
                }

                //=======================================================
                // t req gross (SEA-1 AC-II) && (SEA-2 AC-I) [mm] plate
                //=======================================================
                object r_EhPlateCheck = (sender as DataGridView).Rows[5].Cells[i].Value;
                object bPlateCheck = (sender as DataGridView).Rows[6].Cells[i].Value;
                object alphaCheck = (sender as DataGridView).Rows[8].Cells[i].Value;
                object tcPlateCheck = (sender as DataGridView).Rows[9].Cells[i].Value;
                object pSea1PlateCheck = (sender as DataGridView).Rows[62].Cells[i].Value;

                object pSea2PlateCheck = (sender as DataGridView).Rows[63].Cells[i].Value;

                if (r_EhPlateCheck != null && bPlateCheck != null && !alphaCheck.Equals("No Value!") && tcPlateCheck != null && !pSea1PlateCheck.Equals("No Value!") && !pSea2PlateCheck.Equals("No Value!"))
                {
                    double r_EhPlateCheckInput = Convert.ToDouble(r_EhPlateCheck);
                    double bPlateCheckInput = Convert.ToDouble(bPlateCheck);
                    double alphaCheckInput = Convert.ToDouble(alphaCheck);
                    double tcPlateCheckInput = Convert.ToDouble(tcPlateCheck);
                    double pSea1PlateCheckInput = Convert.ToDouble(pSea1PlateCheck);

                    double pSea2PlateCheckInput = Convert.ToDouble(pSea2PlateCheck);

                    double treqGrossSea1 = Math.Round((0.0158 * alphaCheckInput * bPlateCheckInput * Math.Sqrt(Math.Abs(pSea1PlateCheckInput) / (0.95 * r_EhPlateCheckInput)) + tcPlateCheckInput), 1);
                    dgvCalculateSP.Rows[64].Cells[i].Value = treqGrossSea1;

                    double treqGrossSea2 = Math.Round((0.0158 * alphaCheckInput * bPlateCheckInput * Math.Sqrt(Math.Abs(pSea2PlateCheckInput) / (0.8 * r_EhPlateCheckInput)) + tcPlateCheckInput), 1);
                    dgvCalculateSP.Rows[65].Cells[i].Value = treqGrossSea2;
                }
                else
                {
                    dgvCalculateSP.Rows[64].Cells[i].Value = "No Value!";
                    dgvCalculateSP.Rows[65].Cells[i].Value = "No Value!";
                }

                //=======================
                // P (SEA-1) [MPa] stiff
                //=======================
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double TscTBInput = Convert.ToDouble(TscTB.Text);

                    object zStiffCheck = (sender as DataGridView).Rows[18].Cells[i].Value;
                    object PWwlStiffCheck = (sender as DataGridView).Rows[59].Cells[i].Value;
                    object P_EnvStiffCheck = (sender as DataGridView).Rows[61].Cells[i].Value;

                    double zStiffLoadInput = 0;

                    if (zStiffCheck != null && !P_EnvStiffCheck.Equals("No Value!"))
                    {
                        zStiffLoadInput = Convert.ToDouble(zStiffCheck);
                        double PWwlStiffInput = Convert.ToDouble(PWwlStiffCheck);
                        double P_EnvStiffInput = Convert.ToDouble(P_EnvStiffCheck);
                        if (zStiffLoadInput <= TscTBInput)
                        {
                            double Psea1StiffOutput = P_EnvStiffInput + 9.81 * 1.025 * (TscTBInput - zStiffLoadInput);
                            dgvCalculateSP.Rows[66].Cells[i].Value = Psea1StiffOutput;
                        }
                        else if (zStiffLoadInput < PWwlStiffInput / (1.025 * 9.81) + TscTBInput)
                        {
                            double Psea1StiffOutput = PWwlStiffInput - 1.025 * 9.81 * (zStiffLoadInput - TscTBInput);
                            dgvCalculateSP.Rows[66].Cells[i].Value = Psea1StiffOutput;
                        }
                    }
                    else
                    {
                        double Psea1StiffOutput = 0.0;
                        dgvCalculateSP.Rows[66].Cells[i].Value = Psea1StiffOutput;
                    }
                }

                //=======================
                // P (SEA-2) [MPa] stiff
                //=======================
                if (!string.IsNullOrEmpty(TscTB.Text))
                {
                    double TscTBInput = Convert.ToDouble(TscTB.Text);

                    object zStiffCheck = (sender as DataGridView).Rows[18].Cells[i].Value;

                    double zStiffLoadInput = 0;

                    if (zStiffCheck != null)
                    {
                        zStiffLoadInput = Convert.ToDouble(zStiffCheck);
                        if (zStiffLoadInput <= TscTBInput)
                        {
                            double Psea2StiffOutput = 9.81 * 1.025 * (TscTBInput - zStiffLoadInput);
                            dgvCalculateSP.Rows[67].Cells[i].Value = Psea2StiffOutput;
                        }
                        else
                        {
                            dgvCalculateSP.Rows[67].Cells[i].Value = 0.0;
                        }
                    }
                }

                //============
                // ΤeH [MPa]
                //============

                object r_EhStiffCheck = (sender as DataGridView).Rows[24].Cells[i].Value;

                if (r_EhStiffCheck != DBNull.Value)
                {
                    double r_EhStiffCheckInput = Convert.ToDouble(r_EhStiffCheck);
                    dgvCalculateSP.Rows[31].Cells[i].Value = r_EhStiffCheckInput / Math.Sqrt(3);
                }
                else
                {
                    dgvCalculateSP.Rows[31].Cells[i].Value = 0.0;
                }

                //=====================
                // lshr [m] copy rows
                //=====================
                object copyLshr = (sender as DataGridView).Rows[20].Cells[i].Value;

                if (copyLshr != DBNull.Value)
                {
                    double copyLshrValue = Convert.ToDouble(copyLshr);
                    dgvCalculateSP.Rows[29].Cells[i].Value = copyLshrValue;
                }
                else
                {
                    dgvCalculateSP.Rows[29].Cells[i].Value = 0.0;
                }
                //=======================
                // f_shr value selection
                //=======================

                object fShr = (sender as DataGridView).Rows[30].Cells[i].Value;
                if (fShr != null)
                {
                    string fShrInput = Convert.ToString(fShr);
                    if (fShrInput == "Upper end of vertical stiffeners")
                    {
                        dgvCalculateSP.Rows[72].Cells[i].Value = 0.4;
                    }
                    else if (fShrInput == "Lower end of vertical stiffeners")
                    {
                        dgvCalculateSP.Rows[72].Cells[i].Value = 0.7;
                    }
                    else if (fShrInput == "General")
                    {
                        dgvCalculateSP.Rows[72].Cells[i].Value = 0.5;
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[72].Cells[i].Value = "No Value!";
                }

                //=======================================================
                // t req gross (SEA-1 AC-II) && (SEA-2 AC-I) [mm] stiff
                //=======================================================
                object sStiffCheck = (sender as DataGridView).Rows[21].Cells[i].Value;
                object dShrCheck = (sender as DataGridView).Rows[25].Cells[i].Value;
                object lShrCheck = (sender as DataGridView).Rows[29].Cells[i].Value;
                object tEhStiffCheck = (sender as DataGridView).Rows[31].Cells[i].Value;
                object fShrCheck = (sender as DataGridView).Rows[72].Cells[i].Value; // tu poprawic
                object tcStiffCheck = (sender as DataGridView).Rows[32].Cells[i].Value;
                object pSea1Stiff = (sender as DataGridView).Rows[66].Cells[i].Value;
                object pSea2Stiff = (sender as DataGridView).Rows[67].Cells[i].Value;

                double tEhStiffCheckValue = Convert.ToDouble(tEhStiffCheck);

                if (sStiffCheck != DBNull.Value && !dShrCheck.Equals("No Value!") && lShrCheck != DBNull.Value && tEhStiffCheckValue > 0 && !fShrCheck.Equals("No Value!") && tcStiffCheck != DBNull.Value)
                {
                    double sStiffCheckInput = Convert.ToDouble(sStiffCheck);
                    double dShrCheckInput = Convert.ToDouble(dShrCheck);
                    double lShrCheckInput = Convert.ToDouble(lShrCheck);
                    double fShrCheckInput = Convert.ToDouble(fShrCheck);
                    double tcStiffCheckInput = Convert.ToDouble(tcStiffCheck);
                    double pSea1StiffInput = Convert.ToDouble(pSea1Stiff);
                    double pSea2StiffInput = Convert.ToDouble(pSea2Stiff);

                    dgvCalculateSP.Rows[68].Cells[i].Value = Math.Round((((fShrCheckInput * Math.Abs(pSea1StiffInput) * sStiffCheckInput * lShrCheckInput) / (dShrCheckInput * 0.9 * tEhStiffCheckValue) + tcStiffCheckInput) * 2), 0) / 2;
                    dgvCalculateSP.Rows[69].Cells[i].Value = Math.Round((((fShrCheckInput * Math.Abs(pSea2StiffInput) * sStiffCheckInput * lShrCheckInput) / (dShrCheckInput * 0.75 * tEhStiffCheckValue) + tcStiffCheckInput) * 2), 0) / 2;
                }
                else
                {
                    dgvCalculateSP.Rows[68].Cells[i].Value = "No Value!";
                    dgvCalculateSP.Rows[69].Cells[i].Value = "No Value!";
                }



                //======================
                // for 75° <= ϕw <= 90°
                //======================
                dgvCalculateSP.Rows[27].Cells[i].Value = (sender as DataGridView).Rows[12].Cells[i].Value;

                object tpStiffCheck = (sender as DataGridView).Rows[27].Cells[i].Value;
                object hStiffCheck = (sender as DataGridView).Rows[26].Cells[i].Value;

                if (tpStiffCheck != null && hStiffCheck != DBNull.Value)
                {
                    double tpStiffCheckInput = Convert.ToDouble(tpStiffCheck);
                    double hStiffCheckInput = Convert.ToDouble(hStiffCheck);
                    dgvCalculateSP.Rows[70].Cells[i].Value = tpStiffCheckInput + hStiffCheckInput;
                }
                else
                {
                    dgvCalculateSP.Rows[70].Cells[i].Value = 0.0;
                }

                //===============
                // for ϕw <= 75°
                //===============

                object degStiffCheck = (sender as DataGridView).Rows[28].Cells[i].Value;
                object deg7090Check = (sender as DataGridView).Rows[70].Cells[i].Value;



                if (deg7090Check != null && degStiffCheck != DBNull.Value)
                {

                    double degStiffCheckInput = Convert.ToDouble(degStiffCheck);
                    double deg7090CheckInput = Convert.ToDouble(deg7090Check);
                    dgvCalculateSP.Rows[71].Cells[i].Value = Math.Round(deg7090CheckInput * Math.Sin(DegToRad(degStiffCheckInput)), 2);
                }
                else
                {
                    dgvCalculateSP.Rows[71].Cells[i].Value = "No Value!";
                }

                //================
                // P [MPa] Plate ---- do zrobienia-----
                //================
                object t_req_sea1AC2 = (sender as DataGridView).Rows[64].Cells[i].Value;
                object t_req_sea2AC1 = (sender as DataGridView).Rows[65].Cells[i].Value;
                object t_req = (sender as DataGridView).Rows[11].Cells[i].Value;


                if (!t_req_sea1AC2.Equals("No Value!") && !t_req_sea1AC2.Equals("No Value!") && !t_req.Equals("No Value!"))
                {
                    double t_req_sea1AC2input = Convert.ToDouble(t_req_sea1AC2);
                    double t_req_sea2AC1input = Convert.ToDouble(t_req_sea2AC1);

                    if (t_req_sea1AC2input > t_req_sea2AC1input)
                    {
                        

                        string resluts = "SEA-1" + "cos";



                        dgvCalculateSP.Rows[10].Cells[i].Value = resluts;
                    }
                    else
                    {
                        dgvCalculateSP.Rows[10].Cells[i].Value = "SEA-2";
                    }
                }
                else
                {
                    dgvCalculateSP.Rows[10].Cells[i].Value = "No Value!";
                }

                //====================
                // t rq (GROSS) [mm] ----- do zrobienia-----------
                //====================
                if(!t_req_sea1AC2.Equals("No Value!") && !t_req_sea2AC1.Equals("No Value!"))
                {
                    dgvCalculateSP.Rows[11].Cells[i].Value = 0;
                }
                else
                {
                    dgvCalculateSP.Rows[11].Cells[i].Value = "No Value!";
                }
                 
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