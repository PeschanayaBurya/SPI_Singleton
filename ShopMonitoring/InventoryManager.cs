using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMonitoring
{
    public class InventoryManager
    {
        protected readonly Logger logger;
        public Logger Logger => logger;

        private Dictionary<string, int> stock = new Dictionary<string, int>
        {
            { "laptop", 3 },
            { "mouse", 2 },
            { "keyboard", 0 },
            { "monitor", 10 },
            { "headphones", 5 }
        };

        public InventoryManager()
        {
            logger = Logger.GetInstance();
        }

        // Проверка наличия товара на складе
        public bool CheckStock(string productId)
        {
            Logger.Log($"Inventory: checking stock for {productId}", "INFO");

            if (!stock.ContainsKey(productId))
            {
                Logger.Log($"Inventory: product {productId} not found in system", "ERROR");
                return false;
            }

            int currentStock = stock[productId];

            if (currentStock <= 0)
            {
                Logger.Log($"Inventory: {productId} is out of stock", "ERROR");
                return false;
            }

            if (currentStock < 5)
            {
                Logger.Log($"Inventory: low stock for {productId} ({currentStock} left)", "WARN");
            }
            else
            {
                Logger.Log($"Inventory: sufficient stock for {productId} ({currentStock} left)", "INFO");
            }

            return true;
        }

        // Резервирование указанного количества товара на складе
        public bool ReserveStock(string productId, int quantity)
        {
            Logger.Log($"Inventory: reserved {quantity} of {productId}", "INFO");

            // Сначала проверяем наличие через CheckStock
            if (!CheckStock(productId))
            {
                // CheckStock уже залогировал ошибку
                return false;
            }

            int currentStock = stock[productId];

            if (currentStock < quantity) // Проверка на возможность резервирования
            {
                Logger.Log($"no {productId} in stock in the amount of {Math.Abs(currentStock - quantity)} pieces", "ERROR");
            }
            else // Резервирование
            {
                stock[productId] = currentStock - quantity;
            }

            return true;
        }

    }
}