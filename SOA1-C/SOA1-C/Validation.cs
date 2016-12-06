////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	validation.cs
//
// summary:	Implements the validation class
// 
// TEAM :  Wes ,Niels ,Jen , Alex 
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA1_C
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A validation. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Validation
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Double validation. </summary>
        ///
        ///  
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool doubleValidation(string input)
        {
            double temp;
            return Double.TryParse(input,out temp); 
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   String validation. </summary>
        ///
        ///  
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool stringValidation(string input)
        {
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Int validation. </summary>
        ///
        ///  
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool intValidation(string input)
        {
            int temp;
            return int.TryParse(input, out temp);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   String not empty. </summary>
        ///
        ///  
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
