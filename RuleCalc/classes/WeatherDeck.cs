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

    }

}
