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




    }

}
