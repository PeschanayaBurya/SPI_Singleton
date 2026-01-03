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

        // 1. Только проверка наличия
        public bool HasStock(string productId)
        {
            if (!stock.ContainsKey(productId))
            {
                return false;
            }
            return stock[productId] > 0;
        }

        // Только логирование статуса
        public void LogStockStatus(string productId)
        {
            Logger.Log($"Inventory: checking stock for {productId}", "INFO");

            if (!stock.ContainsKey(productId))
            {
                Logger.Log($"Inventory: product {productId} not found in system", "ERROR");
                return;
            }

            int currentStock = stock[productId];

            if (currentStock <= 0)
            {
                Logger.Log($"Inventory: {productId} is out of stock", "ERROR");
            }
            if (currentStock < 5)
            {
                Logger.Log($"Inventory: low stock for {productId} ({currentStock} left)", "WARN");
            }
            else
            {
                Logger.Log($"Inventory: sufficient stock for {productId} ({currentStock} left)", "INFO");
            }
        }

        // Проверка наличия товара на складе
        public bool CheckStock(string productId)
        {
            bool hasStock = HasStock(productId);
            LogStockStatus(productId);
            return hasStock;
        }

        // Получения количества товара
        public int GetStockQuantity(string productId)
        {
            if (stock.ContainsKey(productId))
            {
                return stock[productId];
            }
            return -1; // выбросить исключение
        }

        // Резервирование указанного количества товара на складе
        public bool ReserveStock(string productId, int quantity)
        {
            Logger.Log($"Inventory: reserve {quantity} of {productId}", "INFO");

            // Сначала проверяем наличие через HasStock
            if (!HasStock(productId))
            {
                LogStockStatus(productId); // логируем
                return false;
            }

            int currentStock = stock[productId];

            if (currentStock < quantity) // Проверка на возможность резервирования
            {
                Logger.Log($"Inventory: cannot reserve (no {productId} in stock in the amount of {Math.Abs(currentStock - quantity)} pieces)", "ERROR");
                return false;
            }
            else // Резервирование
            {
                stock[productId] = currentStock - quantity;
                LogStockStatus(productId);
            }

            return true;
        }

    }
}