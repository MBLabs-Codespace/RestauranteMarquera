using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Balcao
{
    public class Program
    {
        public class Order
        {
            public string Symbol { get; set; }
            public decimal Price { get; set; }
        }
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            using (var hubConnection = new HubConnection("http://www.contoso.com/")) 
            {
                IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
                stockTickerHubProxy.On<Stock>("OrderCreated", stock =>
                    Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price));
                
                await hubConnection.Start();
            }
        }
    }
}