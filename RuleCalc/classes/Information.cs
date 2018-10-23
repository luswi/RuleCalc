﻿using System;
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
        private string tbalSave;
        private string tscSave;
        private string gmSave;
        private string krSave;
        private string saSave;
        private string frSave;
        private string bkSave;
        

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
        public string vData
        {
            get { return vSave; }
            set { vSave = value; }
        }
        public string cbData
        {
            get { return cbSave; }
            set { cbSave = value; }
        }
        public string tbalData
        {
            get { return tbalSave; }
            set { tbalSave = value; }
        }
    }
}
