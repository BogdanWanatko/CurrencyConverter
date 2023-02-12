using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount to convert:");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter source currency code (e.g. USD, EUR, GBP, PLN):");
            string sourceCurrency = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter target currency code (e.g. USD, EUR, GBP, PLN):");
            string targetCurrency = Console.ReadLine().ToUpper();

            double exchangeRate = GetExchangeRate(sourceCurrency, targetCurrency);

            double convertedAmount = amount * exchangeRate;

            Console.WriteLine("Converted amount: " + convertedAmount);

            Console.ReadKey();
        }

        static double GetExchangeRate(string sourceCurrency, string targetCurrency)
        {
            string url = $"https://api.exchangerate-api.com/v4/latest/{sourceCurrency}";

            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            JObject exchangeRates = JObject.Parse(response);

            return (double)exchangeRates["rates"][targetCurrency];
        }
    }
}
