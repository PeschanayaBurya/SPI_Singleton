# SPI_Singleton
Реализация Singleton Logger для интернет-магазина

## Структура

<pre>
SPI_Singleton/
├── ShopMonitoring/
│   ├── Logger.cs
│   ├── InventoryManager.cs
│   ├── OrderProcessor.cs
│   ├── PaymentGateway.cs
│   ├── Program.cs
│   ├── ShopMonitoring.csproj
│   └── TestsPlan.md
├── Console.png
├── ShopMonitoring.sln
├── ЗаданиеС.docx
└── README.md
</pre>

## Запуск программы
Через Bash
1. Клонирование
```shell
git clone https://github.com/ваш-логин/SPI_Singleton.git
```
2. Переход в папку проекта
```shell
cd SPI_Singleton/ShopMonitoring
```
3. Запуск
```shell
dotnet run
```

## Ожидаемый вывод программы
<pre>
Logger instance created
=== Обработка заказа #123 ===
[INFO] Inventory: checking stock for laptop
[WARN] Inventory: low stock for laptop (3 left)
[INFO] Inventory: reserved 1 of laptop
[INFO] Inventory: checking stock for laptop
[WARN] Inventory: low stock for laptop (3 left)
[INFO] OrderProcessor: processing order 123
[INFO] PaymentGateway: processing payment for order 123, amount=999,99

=== После SetLogLevel('WARN') ===
[WARN] Inventory: low stock for mouse (2 left)
Все логгеры одинаковые: True True
</pre>