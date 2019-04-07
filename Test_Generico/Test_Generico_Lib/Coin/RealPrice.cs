using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Test_Generico_Lib;

namespace Test_Generico_Lib.Coin
{
    class RealPrice : IPriceQuoteStrategy
    {
        /// <summary>
        /// Get the price
        /// </summary>
        /// <returns></returns>
        public Price GetQuote()
        {
            try
            {

                //I throw a HttpException because that was in the requirement.
                throw new  HttpException(401, "no authorized");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
