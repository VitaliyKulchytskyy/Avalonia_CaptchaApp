using System;
namespace CaptchaApp.Models;

public static class Constant
{
    // --- [Main window settings] ---
    public const Int32 MainWindowHeight = 600;
    public const Int32 MainWindowWidth = 390;
    
    // --- [Captcha variants settings] ---
    public const Int16 AnswerAmount = 16;
    public const Int32 MinInputValue = -90000;
    public const Int32 MaxInputValue = 90000;

    // --- [Other] ---
    public const char VariantsSeparator = '|';
}