using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Generico_Lib
{
    /// <summary>
    /// Public interface to use the Strategy pattern
    /// This is the abstract implementation of the getQuote
    /// </summary>
    public interface IPriceQuoteStrategy
    {
        /// <summary>
        /// This will get the price
        /// </summary>
        /// <returns></returns>
        Price GetQuote();
    }
}
