using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPT.classes
{
    public class Information
    {
        private string lppSave;
        private string lSave;
        private string bSave;
        private string dSave;
        private string vSave;
        private string cbSave;
        private string tballSave;
        private string tscSave;
        private string frSave;
        private string zdkSave;
        private string zfdkSave;

        public string lppData
        {
            get { return lppSave; }
            set { lppSave = value; }
        }
        public string lData
        {
            get { return lSave; }
            set { lSave = value; }
        }
        public string bData
        {
            get { return bSave; }
            set { bSave = value; }
        }
        public string dData
        {
            get { return dSave; }
            set { dSave = value; }
        }
    }
}
