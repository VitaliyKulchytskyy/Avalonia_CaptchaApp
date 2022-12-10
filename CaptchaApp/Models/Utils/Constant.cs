using System;
namespace CaptchaApp.Models;

public static class Constant
{
    public static class Window
    {
        public const Int32 MainWindowHeight = 600; // Мінімальна висота програми
        public const Int32 MainWindowWidth = 390; // Мінімальна ширина програми
    }

    public static class Captcha
    {
        public const Int16 AnswerAmount = 8; // Кількість варіантів відповідей
        public const Int32 MinInputValue = -20; // Мінімальна правильна відповідь
        public const Int32 MaxInputValue = 50; // Максимальна правильна відповідь
        public const Int32 AnswerAttempts = 2;  // Кількість спроб ввести капчу
    }
    
    public static class Obstacle
    {
        public const string Alphabet = "012++45--hjkl"; // З яких символів буде генеруватися колонки (перешкоди)
        public const int Columns = 8; // Кількість текстових колонок
        public const int SubStringMaxLength = 10; // Максимальна довжина колонки
        public const int SubStringMinLength = 5; // Мінімальна довжина колонки
    }
    
    public static class DataCollector
    {
        public const char VariantsSeparator = '|'; // Сепаратор для розділення інформації
    }
}