using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMonitoring
{
    public class PaymentGateway
    {
        protected readonly Logger logger;
        public Logger Logger => logger;

        public PaymentGateway()
        {
            logger = Logger.GetInstance();
        }

        // Процесс оплаты
        public bool ProcessPayment(string orderId, decimal amount)
        {
            if (amount < 0)
            {
                Logger.Log($"PaymentGateway: invalid amount", "ERROR");
            }
            else
            {
                Logger.Log($"PaymentGateway: processing payment for order {orderId}, amount={amount}", "INFO");


                if (orderId == "666")
                {
                    Logger.Log($"PaymentGateway: payment for order {orderId} declined", "ERROR");
                    return false;
                }
            }

            return true;
        }
    }
}
