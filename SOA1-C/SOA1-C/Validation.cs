using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA1_C
{
    class Validation
    {
        public bool doubleValidation(string input)
        {
            double temp;
            return Double.TryParse(input,out temp); 
        }

        public bool stringValidation(string input)
        {
            return true;
        }
        public bool intValidation(string input)
        {
            int temp;
            return int.TryParse(input, out temp);
        }

        public bool stringNotEmpty (string input)

        {
            bool returner = false;
            if (!String.IsNullOrEmpty(input))
            {
                returner = true;
            }
            return returner;

        }


    }
}
