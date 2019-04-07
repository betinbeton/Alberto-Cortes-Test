using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Generico_Lib.Coin;

namespace Test_Generico_Lib
{
    public class PriceQuoteService
    {
        ///Private propiety to be use in the class
        private IPriceQuoteStrategy priceQuoteStrategy;
        //private coin in the class
        private string coin;

        /// <summary>
        /// This constructor will initialize the class with an specific coin
        /// </summary>
        /// <param name="coin">Coin to consult or play with</param>
        public PriceQuoteService(string coin)
        {
            this.coin = coin;
        }

        /// <summary>
        /// Public method to get the price of the coin
        /// </summary>
        /// <returns></returns>
        public Price GetPriceQoute()
        {
            try
            {

                Price price = new Price();

                if (coin == Properties.Settings.Default.Dolar)
                {
                    priceQuoteStrategy = new DolarPrice();

                    price = priceQuoteStrategy.GetQuote();

                }
                else if (coin == Properties.Settings.Default.Pesos)
                {
                    priceQuoteStrategy = new PesosPrice();

                    price = priceQuoteStrategy.GetQuote();
                }
                else if (coin == Properties.Settings.Default.Real)
                {
                    priceQuoteStrategy = new RealPrice();

                    price = priceQuoteStrategy.GetQuote();

                }

                return price;
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

    }
}
