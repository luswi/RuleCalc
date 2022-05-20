using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCalc.classes
{
    class WeatherDeck
    {

        //=================
        //calculate alpha
        //=================
        public static double alphaPlate(double bInput, double aInput)
        {

            if ((1.2 - (bInput / (2.1 * aInput))) < 1)
            {
                double alphaOutput = (1.2 - (bInput / (2.1 * aInput)));
                return (double)alphaOutput;
            }
            else
            {
                double alphaOutput = 1;
               return (double)alphaOutput;
            }

        }
        //====
        //xll
        //====
        public static double xll(double Lpp, double Lll, double x_point)
        {
            if(Lpp > Lll && Lpp != 0 && Lll != 0)
            {
                double xll = x_point - (Lpp - Lll);
                return (double)Math.Round(xll, 2);
            }
            else if (Lpp != 0 && Lll != 0)
            {
                double xll = x_point + (Lll - Lpp);
                return (double)Math.Round(xll, 2);
            }
            else
            {
                double xll = 0.0;
                return (double)xll;
            }

        }



        //==============
        //calculate X'
        //==============
        public static double xPrim(double Lpp, double Lrule, double x_point)
        {
            if(Lpp != 0 && Lrule != 0 && Lpp > Lrule)
            {
                double xPrim = x_point - (Lpp - Lrule);
                return (double)Math.Round(xPrim, 2);
            }
            else if (Lpp != 0 && Lrule != 0)
            {
                double xPrim = x_point + (Lrule - Lpp);
                return (double)Math.Round(xPrim, 2);
            }
            else
            {
                double xPrim = 0.0;
                return (double)xPrim;
            }
        }

        //==============
        //calculate C
        //==============
        public static double cValue(double zdk, double zfdk)
        {
            if(zdk != 0 && zfdk != 0)
            {
                double cValue = (zdk - zfdk) / 2.3;
                return (double)Math.Round(cValue, 2);
            }
            else
            {
                double cValue = 0.0;
                return (double)cValue;
            }
        }

        //--------------
        // Calculate X
        //--------------
        public static double xValue(double zdk, double zfdk, double pdmin, double cValue)
        {
            if(zdk != 0 && zfdk != 0 && pdmin != 0)
            {
                if(zdk == zfdk)
                {
                    double xValue = 1.0;
                    return (double)Math.Round(xValue ,2);
                }
                else if (pdmin == 0)
                {
                    double xValue = 0.0;
                    return (double)Math.Round(xValue ,2);
                }
                else if (cValue >= 3)
                {
                    double xValue = 2.5/pdmin;
                    return (double)Math.Round(xValue, 2);
                }
                else if (cValue < 3)
                {
                    double xValue = Math.Pow(0.75, cValue);
                    return (double)Math.Round(xValue,2);
                }
                else
                {
                    double xValue = 0.0;
                    return (double)xValue;
                }
            }
            else
            {
                double xValue = 0.0;
                return (double)xValue;
            }
        }
        //-----------------
        // Calculate Pdmin
        //-----------------
        public static double pdmin(double Lll, double xll)
        {
            if (Lll != 0 && xll != 0)
            {
                if(xll/Lll <= 0.75)
                {

                    double pdmin = 14.9 + 0.195 * Lll;
                return (double)Math.Round(pdmin, 2);
                }
                else
                {
                    double pdmin = 12.2 + (Lll / 9) * (5 * (xll / Lll) - 2) + 3.6 * (xll / Lll);
                return (double)Math.Round(pdmin, 2);
                }

            }
            else
            {
                double pdmin = 0.0;
                return (double)pdmin;
            }
        }

        //=====
        // fyb
        //=====
        public static double fyB(double bShip, double Bx)
        {
            if(bShip != 0 && Bx != 0)
            {
                double[] fyBArray = { (2 * (bShip / 2)) / Bx, 1 };
                double fyB = fyBArray.Select(Math.Abs).Min();
                return (double)Math.Round(fyB, 2);
            }
            else
            {
                double fyB = 0.0;
                return (double)fyB;
            }
        }
        //=====
        // fyz
        //=====
        public static double fyz(double fyB)
        {
            if (fyB != 0)
            {
                double fyz = 0.5 * 1 + 2.5 * fyB + 2;
                return (double)Math.Round(fyz, 2);
            }
            else
            {
                double fyz = 0.0;
                return (double)fyz;
            }
        }
        //=====
        // fxL
        //=====
        public static double fxL(double xprim, double Lrule)
        {
            if (xprim != 0 && Lrule != 0)
            {
                double fxL = xprim / Lrule;
                return (double)Math.Round(fxL, 2);
            }
            else
            {
                double fxL = 0.0;
                return (double)fxL;
            }
        }

        //=====
        // f_3
        //=====
        public static double f_3(double CB, double Lrule, double bShip)
        {
            if(CB != 0 && Lrule != 0 && bShip != 0)
            {
                double[] f_3Array = { 0.06, 0.05 + CB, 1.1 - 0.1 * (Lrule / bShip) };
                double f_3 = f_3Array.Select(Math.Abs).Max();
                return (double)Math.Round(f_3, 2);
            }
            else
            {
                double f_3 = 0.0;
                return (double)f_3;
            }
        }

        //=====
        // f_4 
        //=====
        public static double f_4(double fxL)
        {
            if(fxL < 2)
            {
                double[] f_4Array = { 2, (-5 * fxL + 2) };
                double f_4 = f_4Array.Select(Math.Abs).Min();
                return (double)Math.Round(f_4, 2);
            }
            else if (fxL > 0.6)
            {
                double[] f_4Array = { 3, (5 * fxL - 2) };
                double f_4 = f_4Array.Select(Math.Abs).Min();
                return (double)Math.Round(f_4, 2);
            }
            else
            {
                double f_4 = 1;
                return (double)f_4;
            }

        }

        //=====
        // Cw
        //=====
        public static double Cw(double Lrule)
        {
            double Cw = 0.0856 * Lrule;
            return (double)Math.Round(Cw, 2);
        }

        //===================
        //Pwd HS[MPa]
        //===================
        public static double PwdHS(double P_envHS, double zdk, double Tsc)
        {
            double PwdHS = P_envHS - 1.1025 * 9.81 * (zdk - Tsc);
            return (double)Math.Round(PwdHS, 2);
        }

        //===================
        //Pwd BS[MPa]
        //===================
        public static double PwdBS(double P_envBS, double zdk, double Tsc)
        {
            double PwdBS = P_envBS - 1.1025 * 9.81 * (zdk - Tsc);
            return (double)Math.Round(PwdBS, 2);
        }
       
        //========================
        //P_ENV - HS [MPa]
        //========================
        public static double P_envHS(double fr, double f_4, double f_5, double CB, double Cw, double Lrule)
        {
            double P_envHS = 5 * fr * f_4 * f_5 * (1 - CB / 3) * Cw * Math.Sqrt((1.2 * Lrule - 15) / Lrule);
            return (double)Math.Round(P_envHS, 2);
        }

        //========================
        //P_ENV - BS [MPa]
        //========================
        public static double P_envBS(double fr, double f_3, double Lrule, double fyzPlate, double Cw)
        {
            double P_envBS = fr * f_3 * (2 + 55 / Lrule) * fyzPlate * Cw;
            return (double)Math.Round(P_envBS, 2);
        }

        //==============================================
        // Linear calculation for plate and stiffeners
        //==============================================

        //https://stackoverflow.com/questions/26179973/create-a-method-to-calculate-linear-interpolation-in-c-sharp

        //https://stackoverflow.com/questions/12838007/c-sharp-linear-interpolation
        
        public static double Interpolate (double x0, double y0, double x1, double y1, double target)
        {

            return y0 + ((y1 - y0) / (x1 - x0)) * (target - x0);
        }

        //=====================
        // Calculate dshr [mm]
        //=====================
        public static double dshr (object degStiff, object hStiff, object tpStiff)
        {
            if(degStiff!=DBNull.Value && hStiff!=DBNull.Value && tpStiff!=DBNull.Value)
            {
                double degStiffInput = Convert.ToDouble(degStiff);
                if(degStiffInput <= 75)
                {
                    double deg7090 = Convert.ToDouble(hStiff)+Convert.ToDouble(tpStiff);                    
                    return (double) Math.Round(deg7090*Math.Sin((Math.PI*degStiffInput/180.0)), 2);
                }
                else if(degStiffInput >= 75 && degStiffInput <= 90)
                {
                        double hStiffInput = Convert.ToDouble(hStiff);
                        double tpStiffInput = Convert.ToDouble(tpStiff);
                    
                        return (double)hStiffInput + tpStiffInput;
                }
                else
                {
                    return (double)0.0;
                }
            }
            else
            {
                return (double)0.0;
            }
        }
        //================
        // P [MPa] SEA-1
        //================
        public static double pSEA (double chi, double pdMin, double pwdHS, double pwdBS, double zLoadPoint, double zdk)
        {
            double[] pSeaArray = { chi * pdMin, pwdHS - 1.025 * 9.81 * (zLoadPoint - zdk), pwdBS - 1.025 * 9.81 * (zLoadPoint - zdk) };
            double pSeaArrayMAX = pSeaArray.Max();
            return (double)pSeaArrayMAX;
        }
        //==========================
        //t req (GROSS) [mm] plate
        //==========================
        public static double tReqGROSSplate (double alpha, double b, double pressure, double rEH, double tC)
        {
            return (double)Math.Round((0.0158 * alpha * b * Math.Sqrt(Math.Abs(pressure) / (0.95 * rEH)) + tC) * 2, 0) / 2;
        }
        //==========================
        //t req (GROSS) [mm] stiff
        //==========================
        public static double tReqGROSSstiff (double fshr, double pressure, double sStiffSpacing, double lshr, double dshr, double tEH, double tcStiff)
        {
            return (double)(Math.Round(((fshr * Math.Abs(pressure) * sStiffSpacing * lshr) / (dshr * 0.9 * tEH) + tcStiff) * 2, 0) / 2);
        }



        //dgvCalculateSP.Rows[58].Cells[i].Value = PwwlPlateArrayOutput;

        //===================
        // th status check
        //===================
        public static string thStatusCheck (double thSelected, double thReq)
        {

            if (thSelected >= thReq)
            {
                //string msg = "OK";
                return (string)"OK";
            }
            else
            {
                return (string)"NOT OK";

            }
        }

        //=====================
        // slenderness Plate
        //=====================
        public static string slendernessCheckPlate (double thSelected, double tC, double bPlate)
        {
                //plate
                if((thSelected-tC) < (bPlate / 125))
                {
                    return (string)"NOT OK";
                }
                else
                {
                    return (string)"OK";
                }
        }

        //===========
        // fu check
        //===========
        public static double fuCheck (string optionSelected)
        {
            if(optionSelected == "FB and sym. profile (T-profile)")
            {
                return (double)1.0;
            }
            else if(optionSelected == "Bulb profile")
            {
                return(double)1.03;
            }
            else
            //unsymetric profile (L-profile)
            {
                return (double)1.15;
            }
        }



        //============
        // fshr check
        //============
        public static double fshrCheck (string optionSelected)
        {
            if(optionSelected == "Upper end of vertical stiffeners")
            {
                return (double)0.4;

            }
            else if(optionSelected == "Lower end of vertical stiffeners")
            {
                return (double)0.7;
            }
            else
            {
                return (double)0.5;
            }
            
        }
    }

}
