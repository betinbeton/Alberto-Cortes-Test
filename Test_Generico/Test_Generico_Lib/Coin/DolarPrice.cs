using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Generico_Lib;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;

namespace Test_Generico_Lib.Coin
{
    class DolarPrice : IPriceQuoteStrategy
    {
        /// <summary>
        /// This method get the price from the URL: https://www.bancoprovincia.com.ar/Principal/Dolar
        /// The Url can be changed in the app.config
        /// </summary>
        /// <returns>Return an object Price with the prices(sell/buy) and the last updated date of the price</returns>
        public Price GetQuote()
        {
            try
            {
                //We declare an object price to save the quote data.
                Price price = new Price();

                //We get the URl from the properties key DolarUrl
                string url = Properties.Settings.Default.DolarUrl;
                //we define the client.
                var client = new RestClient(url);
                //the type of request verb get
                var request = new RestRequest(Method.GET);
                //new object reponse
                var response = new RestResponse();
                //A task to make the async call using the package RestSharp
                Task.Run(async () =>
                {
                    response = await GetResponseContentAsync(client, request) as RestResponse;
                }).Wait();

                //We use the Newtonsoft.Json to deserialize the list of strings.
                var jsonResponse = JsonConvert.DeserializeObject<List<string>>(response.Content);

                //We assume that we have a list of 3 string in the response.
                //First we get the buy price
                price.buyPrice = jsonResponse[0];
                //Second we get the sell price
                price.sellPrice = jsonResponse[1];
                //Last we get the updated date.
                price.updatedDate = jsonResponse[2];

                //retunr the price.
                return price;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        ///  asyntonic  task to get the response
        /// </summary>
        /// <param name="client">Url </param>
        /// <param name="request">Type of the request that we need</param>
        /// <returns>Return the response</returns>
        private Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
