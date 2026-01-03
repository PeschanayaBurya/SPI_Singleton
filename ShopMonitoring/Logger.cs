using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMonitoring
{
    public class Logger
    {
        private static Logger instance = null;
        private string logLevel = "INFO";
        private readonly string[] validLevels = { "INFO", "WARN", "ERROR" };
        
        private Logger() // конструктор
        {
            Console.WriteLine("Logger instance created");
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        private bool IsValidLevel(string level)
        {
            return Array.IndexOf(validLevels, level) != -1;
        }

        // Запись сообщения в лог, если его уровень соответствует текущему уровню логирования
        public void Log(string message, string level)
        {
            if (!IsValidLevel(level)) return;

            int currentLevelIndex = Array.IndexOf(validLevels, logLevel);
            int messageLevelIndex = Array.IndexOf(validLevels, level);

            if (messageLevelIndex >= currentLevelIndex)
            {
                Console.WriteLine($"[{level}] {message}");
            }
        }

        // Устанавливает текущий уровень логирования
        public void SetLogLevel(string level)
        {
            if (Array.IndexOf(validLevels, level) != -1)
            {
                logLevel = level;
            }
        }

        // Возвращает текущий уровень логирования
        public string GetLogLevel()
        {
            return logLevel;
        }
    }
}
