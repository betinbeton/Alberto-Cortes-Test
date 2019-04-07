using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Generico_Lib
{
    /// <summary>
    /// This is the price object 
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Buying prince
        /// </summary>
        public string buyPrice { get; set; }
        /// <summary>
        /// Selling Price
        /// </summary>
        public string sellPrice { get; set; }
        /// <summary>
        /// the last updated date of the price
        /// </summary>
        public string updatedDate { get; set; }
    }
}
