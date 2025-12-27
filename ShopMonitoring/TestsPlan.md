# SPI_Singleton
**Проект:** ShopMonitoring (Singleton Logger)
# Тест-кейсы для ShopMonitoring

| ID | Модуль | Название | Шаги | Ожидаемый результат |
|----|--------|----------|------|-------------------|
| 1 | Logger | Singleton создается только один раз | Запустить Program.Main | "Logger instance created" выводится 1 раз |
| 2 | Inventory | Проверка запаса laptop | inv.CheckStock("laptop") | [INFO] checking stock for laptop|
| 3 | Order | Обработка заказа 123 | order.ProcessOrder("123") | [INFO] processing order 123 |
| 4 | Payment | Обработка платежа | payment.ProcessPayment("123", -1m); | [ERROR] PaymentGateway: invalid amount |
| 5 | Inventory | Ошибка резервирования при недостатающем количестве товара | inv.ReserveStock("laptop", 10); | [ERROR] no laptop in stock in the amount of 8 pieces |