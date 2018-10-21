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
            v.zdk = double.Parse(zdkTB.Text);
            v.zfdk = double.Parse(zfdkTB.Text);


            

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


                //cCalcTB.Text = info.lppData;

                
            }
            // add rows
            for (int i = 0; i<= 42; i++ )
            {
                i = dataGridView1.Rows.Add();

            }
            dataGridView1.Rows[2].Cells[0].Value = "tescik";
            dataGridView1.Rows[2].ReadOnly = true;




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
            dgvNames.Rows.Add("");
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


            RowsColor();


        }


        // color row
        public void RowsColor()
        {
            for (int i = 0; i< dgvNames.Rows.Count; i++)
            {
                if (i <= 4)
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
        // Public variables for save menu
        //--------------------------------
        public static string lppSave = "";
        public static string lSave = "";
        public static string bSave = "";
        public static string dSave = "";

        //---------------------------
        // update textboxes for save
        //---------------------------
        private void updateForSave(object sender, EventArgs e)
        {
            lppSave = LppTB.Text;
            lSave = LTB.Text;
            bSave = BTB.Text;
            dSave = DTB.Text;
        }
       



        private void button1_Click(object sender, EventArgs e)
        {
            // string someString = dataGridView1[0, 2].Value.ToString();
            // dataGridView1.Rows[4].Cells[0].Value = someString;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                string kolumna = dataGridView1[i, 1].Value.ToString();
                dataGridView1.Rows[3].Cells[i].Value = kolumna;
            }


        }

        private void newCalcPoint_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "asdasd" });
        }

        private void dgvNames_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dgvNames.FirstDisplayedScrollingRowIndex;
        }
    }
}
