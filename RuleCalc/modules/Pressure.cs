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
        //------------------
        // Hide scroll bar
        //------------------
        //remove scrollbar from dgvCalculateSP table
        dgvCalculateSP.ScrollBars = ScrollBars.None;
        //load data into dgvNames
        dgvNames.Rows.Add("Plate");
        dgvNames.Rows.Add("x [m] load point");
        dgvNames.Rows.Add("y [m] load point");
        dgvNames.Rows.Add("z [m] load point");
        dgvNames.Rows.Add("Bx [m]");
        dgvNames.Rows.Add("R_eH [MPa]");
        dgvNames.Rows.Add("b [mm]");
        dgvNames.Rows.Add("a [mm] (EPP Length]");
        dgvNames.Rows.Add("Alpha (aspect ratio)");
        dgvNames.Rows.Add("P [MPa]");
        dgvNames.Rows.Add("t req gross [mm]");
        dgvNames.Rows.Add("tc plate [mm]");
        dgvNames.Rows.Add("th act. [mm]");
        dgvNames.Rows.Add("th. status");
        dgvNames.Rows.Add("plate slenderness status");
        dgvNames.Rows.Add("Stiffener");
        dgvNames.Rows.Add("x [m] load point");
        dgvNames.Rows.Add("y [m] load point");
        dgvNames.Rows.Add("z [m] load point");
        dgvNames.Rows.Add("Bx");
        dgvNames.Rows.Add("lbdg [m] (Stiffener bending span)");
        dgvNames.Rows.Add("s [mm] (stiffener spacing)");
        dgvNames.Rows.Add("f_u (HP-profile)");
        dgvNames.Rows.Add("f_bdg (10 for trv. Stiff?)");
        dgvNames.Rows.Add("R_eH [MPa]");
        dgvNames.Rows.Add("dshr [mm]");
        dgvNames.Rows.Add("hstif [mm]");
        dgvNames.Rows.Add("tp [mm]");
        dgvNames.Rows.Add("ϕw [deg]");
        dgvNames.Rows.Add("lshr [m]");
        dgvNames.Rows.Add("fshr");
        dgvNames.Rows.Add("ΤeH [MPa]");
        dgvNames.Rows.Add("P [MPa]");
        dgvNames.Rows.Add("tc stiffener [mm]");
        dgvNames.Rows.Add("t req gross [mm]");
        dgvNames.Rows.Add("th act. [mm]");
        dgvNames.Rows.Add("th. status");
        dgvNames.Rows.Add("tw slenderness");
        dgvNames.Rows.Add("zreq ");
        dgvNames.Rows.Add("b web [mm]");
        dgvNames.Rows.Add("b flange [mm]");
        dgvNames.Rows.Add("t flange [mm]");
        dgvNames.Rows.Add("Z [cm^3]");
        dgvNames.Rows.Add("Z status");
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
                DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();

                if ((string)dgvCalculateSP.Rows[4].Cells[i].Value == null)
                {
                    c.Items.Add("On");
                    c.Items.Add("Off");
                    dgvCalculateSP.Rows[4].Cells[i] = c;

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
                else if (i <= 4)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
                else if (i > 4 & i < 7)
                {
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                }
                else
                    dgvNames.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
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
                else if (i == 15)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    dgvCalculateSP.Rows[i].ReadOnly = true;
                }
                else if (i <= 4)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
                else if (i > 4 & i < 7)
                {
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                }
                else
                    dgvCalculateSP.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
            }
        }
        //--------------------
        // BOLD specific row
        //--------------------
        public void RowsBold()
        {
            dgvNames.Rows[0].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
            dgvNames.Rows[15].Cells[0].Style.Font = new Font(dgvNames.Font, FontStyle.Bold);
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
                // clear datasource to avoid errors after data load
                this.dgvCalculateSP.DataSource = null;
                this.dgvCalculateSP.Rows.Clear();
                this.dgvDeleteSP.DataSource = null;
                this.dgvDeleteSP.Rows.Clear();

                dgvCalculateSP.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Point" });
                //----------------------------------
                // add rows for calculation table
                //----------------------------------
                    for (int i = 0; i <= 43; i++)
                    {
                        i = dgvCalculateSP.Rows.Add();
                    }

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

                    // load ComboBox
                    for (int i = 0; i < dgvCalculateSP.ColumnCount; i++)
                    {
                        dgvCalculateSP.Rows[0].Cells[i].Value = null; //this is important.
                        DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                        c.Items.Add("On");
                        c.Items.Add("Off");
                    
                        dgvCalculateSP.Rows[4].Cells[i].Value = ds.Tables[0].Rows[4][i].ToString();
                        dgvCalculateSP.Rows[4].Cells[i] = c;
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