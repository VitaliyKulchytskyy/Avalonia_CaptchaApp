using System;
namespace CaptchaApp.Models;

public static class Constant
{
    public static class Window
    {
        public const Int32 MainWindowHeight = 600;
        public const Int32 MainWindowWidth = 390; 
    }

    public static class Captcha
    {
        public const Int16 AnswerAmount = 8;
        public const Int32 MinInputValue = -20;
        public const Int32 MaxInputValue = 50;
        public const Int32 AnswerAttempts = 2; 
    }
    
    public static class Obstacle
    {
        public const string Alphabet = "012++45--hjkl";
        public const int Columns = 8;
        public const int SubStringMaxLength = 10;
        public const int SubStringMinLength = 5;
    }
    
    // --- [Other] ---
    public static class DataCollector
    {
        public const char VariantsSeparator = '|';   
    }
}