////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	service.cs
//
// summary:	Implements the service class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_pt
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent provinces. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    enum eProvince
    {
        /// <summary>   An enum constant representing the Newline option. </summary>
        NL = 0,
        /// <summary>   An enum constant representing the ns option. </summary>
        NS,
        /// <summary>   An enum constant representing the nb option. </summary>
        NB,
        /// <summary>   An enum constant representing the pe option. </summary>
        PE,
        /// <summary>   An enum constant representing the qc option. </summary>
        QC,
        /// <summary>   An enum constant representing the on option. </summary>
        ON,
        /// <summary>   An enum constant representing the Megabytes option. </summary>
        MB,
        /// <summary>   An enum constant representing the sk option. </summary>
        SK,
        /// <summary>   An enum constant representing the ab option. </summary>
        AB,
        /// <summary>   An enum constant representing the bc option. </summary>
        BC,
        /// <summary>   An enum constant representing the yt option. </summary>
        YT,
        /// <summary>   An enum constant representing the NT option. </summary>
        NT,
        /// <summary>   An enum constant representing the nu option. </summary>
        NU
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A service. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class service
    {
        /// <summary>   The selected province. </summary>
        private eProvince selectedProvince;
        /// <summary>   The value. </summary>
        private double value;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets sub total. </summary>
        ///
        ///  
        ///
        /// <returns>   The sub total. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public double getSubTotal()
        {
            Math.Round(value, 1);
            return value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the pst. </summary>
        ///
        ///  
        ///
        /// <returns>   The pst. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the gst. </summary>
        ///
        ///  
        ///
        /// <returns>   The gst. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the hst. </summary>
        ///
        ///  
        ///
        /// <returns>   The hst. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the total. </summary>
        ///
        ///  
        ///
        /// <returns>   The total. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a value. </summary>
        ///
        ///  
        ///
        /// <param name="valueString">  The value string. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

            if (value < 0 )
            {
                returner = false;
            }
            return returner;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a province. </summary>
        ///
        ///  
        ///
        /// <param name="provinceString">   The province string. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

