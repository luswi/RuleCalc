using RuleCalc.classes;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RuleCalc.modules
{
    public partial class ShipData : Form
    {
        public ShipData()
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

        private void ShipData_Load(object sender, EventArgs e)
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
        //----------------------------
        // Update textboxes for save
        //----------------------------
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

    }
}
