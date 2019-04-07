using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Generico_Lib;

namespace Test_Generico.Controllers
{
    public class MyResftfullAppController:Controller
    {
        /// <summary>
        /// Just a friendly message to see that all is working.
        /// </summary>
        /// <returns>Is always good to see that the code is working and have a friendly Hello :)</returns>
        public string Index()
        {
            return "Hi from Mexico";
        }

        /// <summary>
        /// This method generate a Json Object fora price quote
        /// http://localhost:56036/MyResftfullApp/Cotizacion/Dolar
        /// </summary>
        /// <param name="MONEDA">Coin</param>
        /// <returns>Json Price {"buyPrice":null,"sellPrice":null,"updatedDate":null}</returns>
        [HttpGet]
        public ActionResult Cotizacion(string MONEDA)
        {
            try
            {
                //We generate a service object to get the price qoute
                var priceQuote = new PriceQuoteService(MONEDA);
                //We get the price
                var coinPrice = priceQuote.GetPriceQoute();
                //We return a json object with the price
                return Json(coinPrice, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                //In  case there is a 401 no autorized, we send back the default 401 page
                if (e.Message == "no authorized")
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                else
                    //Send a generic error page
                    return RedirectToAction("ErrorMessage", "Error");
            }
        }


     


    }
}