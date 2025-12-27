using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMonitoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inv = new InventoryManager();
            var order = new OrderProcessor();
            var payment = new PaymentGateway();
            Console.WriteLine("=== Обработка заказа #123 ===");
            inv.CheckStock("laptop");
            inv.ReserveStock("laptop", 1);
            order.ProcessOrder("123");
            payment.ProcessPayment("123", 999.99m);

            Logger.GetInstance().SetLogLevel("WARN");
            Console.WriteLine("\n=== После SetLogLevel('WARN') ===");
            inv.CheckStock("mouse");

            Console.WriteLine($"\nВсе логгеры одинаковые: " +
                $"{ReferenceEquals(inv.Logger, order.Logger)} " +
                $"{ReferenceEquals(order.Logger, payment.Logger)}");
        }
    }
}
