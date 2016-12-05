using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_pt
{

    enum eProvince
    {
        NL = 0,
        NS,
        NB,
        PE,
        QC,
        ON,
        MB,
        SK,
        AB,
        BC,
        YT,
        NT,
        NU
    }
    class service
    {
        private eProvince selectedProvince;
        private double value;


        public double getSubTotal()
        {
            Math.Round(value, 1);
            return value;
        }

        public double getPST()
        {
            double pst = 0;
            double returner = 0;
            switch (selectedProvince)
            {
                case eProvince.PE:
                    pst = 0.1;
                    returner = pst * (value + getGST());
                    break;
                case eProvince.QC:
                    pst = 0.095;
                    returner = pst * (value + getGST());
                    break;
                case eProvince.MB:
                    pst = 0.07;
                    returner = pst * value;
                    break;
                case eProvince.SK:
                    pst = 0.05;
                    returner = pst * value;
                    break;
                default:
                    pst = 0.0;
                    returner = pst * value;
                    break;
            }
            
            Math.Round(returner, 1);
            return returner;
        }

        public double getGST()
        {
            double gst = 0;
            double returner = 0;
            switch (selectedProvince)
            {
                case eProvince.PE:
                    gst = 0.05;
                    break;
                case eProvince.QC:
                    gst = 0.05;
                    break;
                case eProvince.MB:
                    gst = 0.05;
                    break;
                case eProvince.SK:
                    gst = 0.05;
                    break;
                case eProvince.AB:
                    gst = 0.05;
                    break;
                case eProvince.YT:
                    gst = 0.05;
                    break;
                case eProvince.NT:
                    gst = 0.05;
                    break;
                case eProvince.NU:
                    gst = 0.05;
                    break;
                default:
                    gst = 0.0;
                    break;
            }
            returner = gst * value;
            Math.Round(returner, 1);
            return returner;
        }

        public double getHST()
        {
            double hst = 0;
            double returner = 0;
            switch (selectedProvince)
            {
                case eProvince.NL:
                    hst = 0.13;
                    break;
                case eProvince.NS:
                    hst = 0.15;
                    break;
                case eProvince.NB:
                    hst = 0.13;
                    break;
                case eProvince.ON:
                    hst = 0.13;
                    break;
                case eProvince.BC:
                    hst = 0.12;
                    break;
                default:
                    hst = 0.0;
                    break;
            }
            returner = hst * value;
            Math.Round(returner, 1);
            return returner;
        }


        public double getTotal()
        {
            double returner = 0;

            switch (selectedProvince)
            {
                case eProvince.PE:
                    returner = (value + getGST()) + ((value + getGST()) * 0.1);
                    break;
                case eProvince.QC:
                    returner = (value + getGST()) + ((value + getGST()) * 0.095);
                    break;
                default:
                    returner = value + getGST() + getPST() + getHST();
                    break;
            }
            Math.Round(returner, 1);
            return returner;
        }

        public bool setValue(string valueString)
        {
            bool returner = false;
            try
            {
                value = Convert.ToDouble(valueString);
                returner = true;
            }
            catch (FormatException)
            {
                returner = false;
            }
            catch (OverflowException)
            {
                returner = false;
            }
            return returner;
        }

        public bool setProvince(string provinceString)
        {
            bool returner = false;
            string[] provinces =
            {
                "Newfoundland",
                "Nova Scotia",
                "New Bruunswick",
                "Prince Edward Island",
                "Quebec",
                "Ontario",
                "Manitoba",
                "Saskatchewan",
                "Alberta",
                "British Columbia",
                "Yukon Territories",
                "Northwest Territories",
                "Nunavut"
            };
            string[] provincesABV =
            {
                "NL",
                "NS",
                "NB",
                "PE",
                "QC",
                "ON",
                "MB",
                "SK",
                "AB",
                "BC",
                "YT",
                "NT",
                "NU"
            };
            int counter = 0;
            foreach (string s in provinces)
            {
                if (s == provinceString)
                {
                    selectedProvince = (eProvince)counter;
                    returner = true;
                }
                counter++;
            }
            counter = 0;
            foreach (string st in provincesABV)
            {
                if (st.ToUpper() == provinceString.ToUpper())
                {
                    selectedProvince = (eProvince)counter;
                    returner = true;
                }
                counter++;
            }

            return returner;
        }

    }
}

