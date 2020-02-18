namespace RuleCalc.classes
{
    public class pressureClass
    {
        //---------------------------------
        // Variables used for calculations
        //---------------------------------
        public double zdk { get; set; }
        public double zfdk { get; set; }



        public double cCalc { get; set; }

        public bool seaCalculation(pressureClass v)
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
