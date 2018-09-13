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
                cCalcTB.Text = Convert.ToString(v.cCalc);

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


                cCalcTB.Text = info.lppData;
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
    }
}
