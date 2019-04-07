using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Generico_Lib;

namespace Test_Generico_TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 to Test Dolar Price");
            Console.WriteLine("2 to Test Pesos Price");
            Console.WriteLine("3 to Test Real Price");
           string option = Console.ReadLine();


            while ( true)
           {

                if (option == "1")
                {
                    try
                    {
                        //*****Test the request for dolar Price.
                        var coin = "Dolar";
                        var priceQuote = new PriceQuoteService(coin);
                        var coinPrice = priceQuote.GetPriceQoute();

                        Console.WriteLine("Price Buy: " + coinPrice.buyPrice + " Price Sell: " + coinPrice.sellPrice + " Last Update: " + coinPrice.updatedDate);
                        youRock();
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                

                }
                else if (option == "2")
                {
                    try
                    {
                        //*****Test the request for Pesos Price.
                        var coin = "Pesos";
                        var priceQuote = new PriceQuoteService(coin);
                        var coinPrice = priceQuote.GetPriceQoute();

                        Console.WriteLine("Price Buy: " + coinPrice.buyPrice + " Price Sell: " + coinPrice.sellPrice + " Last Update: " + coinPrice.updatedDate);
                        youRock();

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
                else if (option == "3")
                {
                    try
                    {
                        //*****Test the request for Real Price.
                        var coin = "Real";
                        var priceQuote = new PriceQuoteService(coin);
                        var coinPrice = priceQuote.GetPriceQoute();

                        Console.WriteLine("Price Buy: " + coinPrice.buyPrice + " Price Sell: " + coinPrice.sellPrice + " Last Update: " + coinPrice.updatedDate);
                        youRock();

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }



                Console.WriteLine("Continue with another test, press test number, if not press n ");
                 option = Console.ReadLine();

                if (option == "n")
                    break;
            }

        }


        static void youRock()
        {

            Console.WriteLine("You Rock you are super informed ;)");
        }
    }
}
