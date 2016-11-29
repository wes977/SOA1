using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA1_C
{
    class DataMembers
    {
        private string _paraName;
        private string _paraType;
        private string _paraValue;

        public string paraName
        {
            get { return _paraName; }
            set { _paraName = value; }
        }

        public string paraType
        {
            get { return _paraType; }
            set { _paraType = value; }
        }

        public string paraValue
        {
            get { return _paraValue; }
            set { _paraValue = value; }
        }


    }
}
