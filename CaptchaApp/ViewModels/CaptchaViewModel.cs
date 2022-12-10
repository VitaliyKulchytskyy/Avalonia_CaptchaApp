using System;
using CaptchaApp.Models;
using MessageBox.Avalonia.BaseWindows.Base;
using MessageBoxAvaloniaEnums = MessageBox.Avalonia.Enums;
namespace CaptchaApp.ViewModels;

public partial class CaptchaViewModel : ViewModelBase
{
    public CaptchaViewModel()
    {
        UpdateCaptcha();
    }
    
    public void UpdateCaptcha()
    {
        UpdateCaptchaData();
        UpdateCaptchaImage();
    }
    
    private void UpdateCaptchaImage()
    {
        CaptchaBackground = GetRandomValue(_sBackgroundColors);
    }
    
    private void UpdateCaptchaData()
    {
        var captcha = new Captcha();
        Sequence = captcha.GetSequence();
        PrintVariants = captcha.GetVariantsInFormatString().Split(Constant.DataCollector.VariantsSeparator);
        AnswerIndex = captcha.GetAnswerIndex();
        Answer = captcha.GetAnswer();
        CaptchaObstacle = captcha.GetObstacles();
        AttemptsAmountCounter = 0;
    }

    public void CheckSliderInput(uint sliderValue)
    {
        IMsBoxWindow<MessageBoxAvaloniaEnums.ButtonResult>? outputCaptchaMessage;
        
        if (sliderValue == 0)
        {
            outputCaptchaMessage = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow($"Info", "Choose a non-zero answer.", 
                    MessageBoxAvaloniaEnums.ButtonEnum.Ok, 
                    MessageBoxAvaloniaEnums.Icon.Info);
        } 
        else if (sliderValue == AnswerIndex)
        {
            outputCaptchaMessage = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Correct", $"You choose a right answer\nfor the captcha.\n\nReport:\n{Sequence} = {Answer} (answ: {AnswerIndex})",
                    MessageBoxAvaloniaEnums.ButtonEnum.Ok, 
                    MessageBoxAvaloniaEnums.Icon.Success);
            UpdateCaptcha();
        } 
        else
        {
            AttemptsAmountCounter++;
            outputCaptchaMessage = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow($"Error! Attempts [{AttemptsAmountCounter}/{Constant.Captcha.AnswerAttempts}]", "The input value is not a correct\nanswer for this sequence!", 
                    MessageBoxAvaloniaEnums.ButtonEnum.Ok, 
                    MessageBoxAvaloniaEnums.Icon.Error);
        }
        
        if (AttemptsAmountCounter == Constant.Captcha.AnswerAttempts)
            UpdateCaptcha();

        outputCaptchaMessage.Show();
    }

    private string GetRandomValue(string[] array)
        => array[new Random().Next(0, array.Length)];
}
