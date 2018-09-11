using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPT.classes
{
    public class seaClass
    {
        //---------------------------------
        // Variables used for calculations
        //---------------------------------
        public double zdk { get; set; }
        public double zfdk { get; set; }
       
        

        public double cCalc { get; set; }

        public bool seaCalculation(seaClass v)
        {
            bool isSuccess = false;
            if (1 > 0)
            {
                isSuccess = true;
                // Here we starts calculations
                cCalc = (zdk - zfdk) / 2.3;
            }
            else
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
