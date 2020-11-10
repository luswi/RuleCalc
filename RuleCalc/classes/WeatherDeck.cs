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


    }

}
