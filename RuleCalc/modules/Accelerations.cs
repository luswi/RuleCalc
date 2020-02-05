using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using RuleCalc.classes;

namespace RuleCalc.modules
{
    public partial class Accelerations : Form
    {
        public Accelerations()
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
        //----------------------------
        // Load information into DGV
        //----------------------------
        private void Accelerations_Load(object sender, EventArgs e)
        {
            dgvAccelerations.Rows.Add("Head Sea 1");
            dgvAccelerations.Rows.Add("Head Sea 2");
            dgvAccelerations.Rows.Add("Beam Sea 1");
            dgvAccelerations.Rows.Add("Beam Sea 2 ");
            dgvAccelerations.Rows.Add("Oblique Sea 1");
            dgvAccelerations.Rows.Add("Oblique Sea 2");

            // clear selected 1st. row
            dgvAccelerations[0, 1].Selected = true;
            dgvAccelerations.ClearSelection();
        }

        //-------------------------------
        // Acceleration calculation area
        //-------------------------------
        private void calculateBT_Click(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Information info = (Information)xs.Deserialize(read);
                //data to load...
                double lppVAR = Convert.ToDouble(info.lppData);
                double lruleVAR = Convert.ToDouble(info.lData);
                //LTB.Text = info.lData;
                double bVAR = Convert.ToDouble(info.bData);
                double dVAR = Convert.ToDouble(info.dData);
                double cbVAR = Convert.ToDouble(info.cbData);
                double tBalVAR = Convert.ToDouble(info.tbalData);
                double tScVAR = Convert.ToDouble(info.tscData);
                double gmVAR = Convert.ToDouble(info.gmData);
                double krVAR = Convert.ToDouble(info.krData);
                
                string saVAR = Convert.ToString(info.saData);
                //saCB.Text = info.saData;
                string bkVAR = Convert.ToString(info.bkData);
                //bkCB.Text = info.bkData;
                double fCW = 0;
                double frfp = 0;
                double Hs = 0;
                double V = 0; //fixed knots
                double fv = 0; //fixed
                double fL = 0;
                double a0 = 0;
                double fbkVAR = 0;
                double accHeave = 0;
                double accPitch = 0;
                double cgXtbPrim = 0;
                double accAxENV = 0;
                double accAyENV = 0;
                double accAzENV = 0;



                //double angleroll = 0;
                //double T_roll = 0;
                //double pAngle = 0;
                //double pPeriod = 0;




                dgvAccelerations.Rows[2].Cells[1].Value = 0;
                dgvAccelerations.Rows[3].Cells[1].Value = 0;
                dgvAccelerations.Rows[0].Cells[2].Value = 0;
                dgvAccelerations.Rows[1].Cells[2].Value = 0;
                dgvAccelerations.Rows[0].Cells[1].Value = cgXtb.Text;
                //dgvAccelerations.Rows[1].Cells[2].Value = cbVAR;
                dgvAccelerations.Rows[2].Cells[3].Value = lppVAR;

                //------------------------------------------------
                // f_CW - Wave coefficient acc Pt.3 Ch.4 Sec.4
                //------------------------------------------------

                if(lruleVAR < 90)
                {
                    fCW = 0.0856 * lruleVAR;
                    
                }
                else if(lruleVAR >= 90 && lruleVAR < 300)
                {
                    fCW = 10.75 - Math.Pow(((300 - lruleVAR) / 100), 1.5);
                }
                //-----------
                // fr, fp
                //-----------
                
                if(saVAR == "R0 (No reduction)")
                {
                    frfp = 1.0;
                }
                else if (saVAR == "R1 (10% reduction)")
                {
                    frfp = 0.9;
                }
                else if (saVAR == "R2 (20% reduction)")
                {
                    frfp = 0.8;
                }
                else if (saVAR == "R3 (30% reduction)")
                {
                    frfp = 0.7;
                }
                else if (saVAR == "R4 (40% reduction)")
                {
                    frfp = 0.6;
                }
                else if (saVAR == "RE (50% reduction)")
                {
                    frfp = 0.5;
                }
                //-------
                // H s
                //-------
                Hs = fCW * frfp;

                //-------
                // f L
                //-------
                if(lruleVAR < 90)
                {
                    fL = 1;
                }
                else if(lruleVAR >= 150)
                {
                    fL = 0.8;
                }
                else
                {
                    fL = 1.3 - (lruleVAR / 300);
                }

                //----------------
                // a0 --> P3C4S3
                //----------------
                a0 = (1.58 - 0.47 * cbVAR) * ((2.4 / (Math.Sqrt(lruleVAR))) + (34 / lruleVAR) - (600 / Math.Pow(lruleVAR, 2)));

                //-------
                // f BK
                //-------
                if (bkVAR == "YES")
                {
                    fbkVAR =  1.0;
                }
                else 
                {
                    fbkVAR = 1.2;
                }

                //----------------------------------------------
                // Roll angle, in deg and roll period --> 2.1.1
                //----------------------------------------------

                double T_roll = (2.3 * Math.PI * krVAR) / (Math.Sqrt(9.81 * gmVAR));
                double angleroll = (9000 * (1.4 - 0.035 * T_roll) * frfp * fbkVAR) / ((1.15 * bVAR + 55) * Math.PI);

                //--------------------
                // 2.1.2 Pitch motion
                //--------------------

                double[] pAngleArray = { 20, 920 * 1 * Math.Pow(lruleVAR, -0.84) * (1.0 + Math.Pow((2.57 / Math.Sqrt(9.81 * lruleVAR)), 1.2)) };
                double pAngleMIN = pAngleArray.Min();

                double[] fTArray = { 0.5, tBalVAR / tScVAR };
                double fTMAX = fTArray.Max();

                double fT = fTMAX;
                double alphaDeg = 0.6 * (1 + fT) * lruleVAR;
                double pPeriod = Math.Sqrt((2 * Math.PI * alphaDeg) / 9.81);

                double[] vertCORDArray = { (dVAR / 4) + (tBalVAR / 2), dVAR / 2 };
                double vertCORDMIN = vertCORDArray.Min();

                //---------------------------
                // 2.2.1 Surge acceleration
                //---------------------------

                double accSurge = 0.2 * (1.6 + (1.5 / Math.Sqrt(9.81 * lruleVAR))) * frfp * a0 * 9.81;

                //--------------------------
                // 2.2.2 Sway acceleration
                //--------------------------

                double accSway = 0.3 * (2.25 - (20 / Math.Sqrt(9.81 * lruleVAR))) * frfp * a0 * 9.81;

                //---------------------------
                // 2.2.3 Heave acceleration
                //---------------------------

                if(lruleVAR <100)
                {
                    accHeave = 0.8 * (1 + 0.03 * V) * (0.72 + (2 * lruleVAR / 700)) * (1.15 - (6.5 / Math.Sqrt(9.81 * lruleVAR))) * frfp * a0 * 9.81;
                }
                else if (lruleVAR <= 100 && lruleVAR < 150)
                {
                    accHeave = (0.4 + (lruleVAR / 250)) * (1 + 0.03 * V * (3 - (lruleVAR / 50))) * (1.15 - (6.5 / Math.Sqrt(9.81 * lruleVAR))) * frfp * a0 * 9.81;
                }
                else if(lruleVAR >= 150)
                {
                    accHeave = (1.15 - (6.5 / Math.Sqrt(9.81 * lruleVAR))) * frfp * a0 * 9.81;
                }

                //--------------------------
                // 2.2.4 Roll acceleration
                //--------------------------

                double accRoll = frfp * angleroll * (Math.PI / 180) * Math.Pow(((2 * Math.PI) / T_roll), 2);


                double accRollY = accRoll * (Convert.ToDouble(cgBLtb.Text) - vertCORDMIN); // 3.3.2
                double accRollZ = accRoll * Convert.ToDouble(cgCLtb.Text); // 3.3.3

                //---------------------------
                // 2.2.5 Pitch acceleration
                //---------------------------

                if (lruleVAR < 100)
                {
                     accPitch = 0.8 * (1 + 0.05 * V) * frfp * (0.72 + (2 * lruleVAR / 700)) * (1.75 - (22 / Math.Sqrt(9.81 * lruleVAR))) * pAngleMIN * (Math.PI / 180) * (Math.Pow((2 * Math.PI / pPeriod), 2));
                }
                else if (lruleVAR <= 100 && lruleVAR < 150)
                {
                    accPitch = (0.4 + (lruleVAR / 250)) * (1 + 0.05 * V * (3 - (lruleVAR / 50))) * frfp * (1.75 - (22 / Math.Sqrt(9.81 * lruleVAR))) * pAngleMIN * (Math.PI / 180) * (Math.Pow((2 * Math.PI / pPeriod), 2));
                }
                else if (lruleVAR >= 150)
                {
                    accPitch = frfp * (1.75 - (22 / Math.Sqrt(9.81 * lruleVAR))) * (Math.Pow((2 * Math.PI / pPeriod), 2));
                }

                double accPitchX = accPitch * (Convert.ToDouble(cgBLtb.Text) - vertCORDMIN);

                //--------------
                // CG (X') CGx
                //--------------

                if(lppVAR > lruleVAR)
                {
                    cgXtbPrim = Convert.ToDouble(cgXtb.Text) - (lppVAR - lruleVAR);
                }
                else
                {
                    cgXtbPrim = Convert.ToDouble(cgXtb.Text) + (lruleVAR - lppVAR);
                }

                double accPitchZ = accPitch * (1.08 * cgXtbPrim - (0.45 * lruleVAR));


                //---------------------------------------
                // 3.3 Envelope accelerations
                //---------------------------------------

                // 3.3.1 Longitudinal acceleration

                if(lruleVAR < 90)
                {
                    fL = 1;
                }
                else if(lruleVAR <= 90 && lruleVAR < 150)
                {
                    fL = 1.3 - (lruleVAR / 300);
                }
                else if (lruleVAR >= 150)
                {
                    fL = 0.8;
                }

                accAxENV = 0.7 * fL * (0.65 + ((2 * Convert.ToDouble(cgBLtb)) / 7 * tScVAR)); // do zrobienia



                    


            }
            else
            {
                // jak brak ship data to dac info!!!!
            }
            

            
        }






    }



}
