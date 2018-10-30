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
                VTB.Text = info.vData;
                CbTB.Text = info.cbData;
                TbalTB.Text = info.tbalData;
                TscTB.Text = info.tscData;
                gmTB.Text = info.gmData;
                krTB.Text = info.krData;
                saCB.Text = info.saData;
                frTB.Text = info.frData;
                bkCB.Text = info.bkData;


                //  dropmenu();
                //test
                //dgvCalculate.Rows[0].Cells[0].Value = info.lppData;

                //cCalcTB.Text = info.lppData;


            }
  
            //------------------
            // Hide scroll bar
            //------------------
            dgvCalculate.ScrollBars = ScrollBars.None;




            //works
            //for (int i = 0; i < oDg.RowCount; i++)
            //{
            //    for (int j = 0; j < oDg.ColumnCount; j++)
            //    {
            //        oDg.Rows[i].Cells[j].Value = null; //this is important.
            //        DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
            //        c.Items.Add("On");
            //        c.Items.Add("Off");
            //        oDg.Rows[i].Cells[j] = c;
            //    }
            //}




            //test area start
            //dgvCalculate.Rows[2].Cells[0].Value = "tescik";
            //dgvCalculate.Rows[2].ReadOnly = true;

            //test area end




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


            RowsColorNames();
            RowsBold();
    

        }

        //test area for combobox
        public void dropmenu()
        {
            for (int i = 0; i < dgvCalculate.ColumnCount; i++)
            {
                dgvCalculate.Rows[4].Cells[i].Value = null; //this is important.
                DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                c.Items.Add("On");
                c.Items.Add("Off");
                dgvCalculate.Rows[4].Cells[i] = c;
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
            for (int i = 0; i < dgvCalculate.Rows.Count; i++)
            {
                if (i == 0)
                {
                    dgvCalculate.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    dgvCalculate.Rows[i].ReadOnly = true;
                }
                else if (i == 15)
                {
                    dgvCalculate.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    dgvCalculate.Rows[i].ReadOnly = true;
                }
                else if (i <= 4)
                {
                    dgvCalculate.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                }
                else if (i > 4 & i < 7)
                {
                    dgvCalculate.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                }
                else
                    dgvCalculate.Rows[i].DefaultCellStyle.BackColor = Color.Coral;

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
        // update textboxes for save
        //---------------------------
        private void updateForSave(object sender, EventArgs e)
        {
            lppSave = LppTB.Text;
            lSave = LTB.Text;
            bSave = BTB.Text;
            dSave = DTB.Text;
            vSave = VTB.Text;
            cbSave = CbTB.Text;
            tbalSave = TbalTB.Text;
            tscSave = TscTB.Text;
            gmSave = gmTB.Text;
            krSave = krTB.Text;
            saSave = saCB.Text;
            frSave = frTB.Text;
            bkSave = bkCB.Text;
        }

        //---------------------------------------
        // Add new column for calculating point
        //---------------------------------------
        private void newCalcPoint_Click(object sender, EventArgs e)
        {
            if (dgvCalculate.ColumnCount == 0)
            {
                dgvCalculate.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Point" });
                //RowsColorCalculate();
            }
            else
            {


                dgvCalculate.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Point" });
                //dropmenu();
                //RowsColorCalculate();
            }
            //----------------------------------
            // add rows for calculation table
            //----------------------------------
            for (int i = 0; i <= 43; i++)
            {
                i = dgvCalculate.Rows.Add();
                
            }
            dropmenu();
            RowsColorCalculate();
        }

        //---------------------
        // synchronize 2 grids
        //---------------------
        private void dgvNames_Scroll(object sender, ScrollEventArgs e)
        {
            dgvCalculate.FirstDisplayedScrollingRowIndex = dgvNames.FirstDisplayedScrollingRowIndex;
        }


        //----------------------------------------------
        // DataGridView number and only one "." check
        //----------------------------------------------
        private void dgvCalculate_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCalculate.CurrentCell.ColumnIndex == 0)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvCalculate_KeyPress);
            }
        }

        private void dgvCalculate_KeyPress(object sender, KeyPressEventArgs e)
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
        // for comments and clear!!!!!
        private void BTB_Leave(object sender, EventArgs e)
        {
            double bTB = Convert.ToDouble(BTB.Text);
            double gmCalc = bTB * 0.07;
            double krCalc = bTB * 0.39;
            gmTB.Text = gmCalc.ToString("0.00");
            krTB.Text = krCalc.ToString("0.00");
        }

        private void saCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (saCB.Text == "R0 (No reduction)")
            {
                frTB.Text = "1.0";
            }
            else if(saCB.Text == "R1 (10% reduction)")
            {
                frTB.Text = "0.9";
            }
            else if(saCB.Text == "R2 (20% reduction)")
            {
                frTB.Text = "0.8";
            }
            else if (saCB.Text == "R3 (30% reduction)")
            {
                frTB.Text = "0.7";
            }
            else if (saCB.Text == "R4 (40% reduction)")
            {
                frTB.Text = "0.6";
            }
            else if (saCB.Text == "RE (50% reduction)")
            {
                frTB.Text = "0.5";
            }



        }
        // obliczenia test
        private void button_Click(object sender, EventArgs e)
        {
            // string someString = dataGridView1[0, 2].Value.ToString();
            // dataGridView1.Rows[4].Cells[0].Value = someString;

            for (int i = 0; i < dgvCalculate.Columns.Count; i++)
            {
                string kolumna = dgvCalculate[i, 4].Value.ToString();
                dgvCalculate.Rows[6].Cells[i].Value = kolumna;
            }
        }






        private void save_test_Click(object sender, EventArgs e)
        {
            DataTable GetDataTableFromDGV(DataGridView dgv)
            {
                var dt = new DataTable();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Visible)
                    {
                        // You could potentially name the column based on the DGV column name (beware of dupes)
                        // or assign a type based on the data type of the data bound to this DGV column.
                        dt.Columns.Add();
                    }
                }

                object[] cellValues = new object[dgv.Columns.Count];
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        cellValues[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(cellValues);
                }

                return dt;
            }
            DataTable dT = GetDataTableFromDGV(dgvCalculate);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            dS.WriteXml(File.OpenWrite("calc_save.xml"));
            

        }

        private void load_test_Click(object sender, EventArgs e)
        {
            try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create("calc_save.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                dgvCalculate.DataSource = ds.Tables[0];
                xmlFile.Close();

                dgvCalculate.Rows[6].Cells[0].Value = "qwewqewqeqwe";

                for (int i = 0; i < dgvCalculate.ColumnCount; i++)
                {
                    //dgvCalculate.Rows[0].Cells[i].Value = null; //this is important.
                    DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                    c.Items.Add("On");
                    c.Items.Add("Off");
                    //dgvCalculate.Rows[5].Cells[i].Value = dgvCalculate.Rows[4].Cells[i].Value;
                    dgvCalculate.Rows[4].Cells[i].Value = ds.Tables[0].Rows[4][i].ToString();
                    dgvCalculate.Rows[4].Cells[i] = c;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        static DataSet ds_input = new DataSet();



        private void add_col_Click(object sender, EventArgs e)
        {
            try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create("calc_save.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                dgvCalculate.DataSource = ds.Tables[0];
                xmlFile.Close();

                dgvCalculate.Rows[6].Cells[0].Value = "qwewqewqeqwe";

                for (int i = 0; i < dgvCalculate.ColumnCount; i++)
                {
                    //dgvCalculate.Rows[0].Cells[i].Value = null; //this is important.
                    DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                    c.Items.Add("On");
                    c.Items.Add("Off");
                    //dgvCalculate.Rows[5].Cells[i].Value = dgvCalculate.Rows[4].Cells[i].Value;
                    dgvCalculate.Rows[4].Cells[i].Value = ds.Tables[0].Rows[4][i].ToString();
                    dgvCalculate.Rows[4].Cells[i] = c;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




            dgvCalculate.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Point" });

        }
    }
}
