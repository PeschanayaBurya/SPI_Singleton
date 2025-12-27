using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMonitoring
{
    public class OrderProcessor
    {
        protected readonly Logger logger;
        public Logger Logger => logger;

        public OrderProcessor()
        {
            logger = Logger.GetInstance();
        }

        // Обработка заказа
        public bool ProcessOrder(string orderId)
        {
            Logger.Log($"OrderProcessor: processing order {orderId}", "INFO");

            // Имитация логики
            if (orderId == "000")
            {
                Logger.Log($"OrderProcessor: order {orderId} rejected", "ERROR");
                return false;
            }

            return true;
        }
    }
}
