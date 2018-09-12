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

            //Unicode labels
            //https://en.wikipedia.org/wiki/Unicode_subscripts_and_superscripts
            //labelLpp.Text = "L" + (char)0X209A + (char)0X209A;
            
        }


        //----------------------------------------------
        // Check if number and only one "." for input.
        //----------------------------------------------
        private void ProtectText(TextBox txt, KeyPressEventArgs e)
        {
            bool IsNumber = false;
            string text = txt.Text;
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


        // Public variables for save menu
        public static string lppSave = "";
        public static string lSave = "";

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
                cCalcTB.Text = Convert.ToString(v.cCalc);

                lppSave = LppTB.Text;
                lSave = LTB.Text;
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
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                LppTB.Text = info.lppData;
                LTB.Text = info.lData;

                cCalcTB.Text = info.lppData;
            }
        }

        //--------------
        // Save to XML
        //--------------
        private void saveBT_Click(object sender, EventArgs e)
        {

                try
                {

                    Information info = new Information();
                    info.lppData = LppTB.Text;
                    // -->

                    SaveXML.SaveData(info, "data.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }
        //------------
        // Protect 
        //------------
        private void zdkTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(zdkTB, e);
        }

        private void LppTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(LppTB, e);
        }

        private void LTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(LTB, e);
        }

        private void BTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(BTB, e);
        }

        private void DTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(DTB, e);
        }

        private void VTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(VTB, e);
        }

        private void CbTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(CbTB, e);
        }

        private void TballTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(TballTB, e);
        }

        private void TscTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(TscTB, e);
        }

        private void FRTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(FRTB, e);
        }

        private void zfdkTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProtectText(zfdkTB, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lppSave = LppTB.Text;
            lSave = LTB.Text;
        }
    }
}
