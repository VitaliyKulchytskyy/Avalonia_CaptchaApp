using System;
using CaptchaApp.Models;
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

    public void CheckSliderInput(uint sliderValue)
    {
        var uncorrectCaptchaMessage = MessageBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandardWindow("Error!", "The input value is not a correct\nanswer for this sequence!", MessageBoxAvaloniaEnums.ButtonEnum.Ok, MessageBoxAvaloniaEnums.Icon.Error);
        var correctCaptchaMessage = MessageBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandardWindow("Correct", $"You choose a right answer\nfor the captcha.\n\nReport:\n{Sequence} = {Answer} (answ: {AnswerIndex})", MessageBoxAvaloniaEnums.ButtonEnum.Ok, MessageBoxAvaloniaEnums.Icon.Success);
        
        var outputCaptchaMessage = (sliderValue != 0 && sliderValue == AnswerIndex)
            ? correctCaptchaMessage
            : uncorrectCaptchaMessage;
        outputCaptchaMessage.Show();
        UpdateCaptcha();
    }
    
    private void UpdateCaptchaImage()
    {
        CaptchaBackground = GetRandoColor(_sBackgroundColors);
    }
    
    private void UpdateCaptchaData()
    {
        var captcha = new Captcha();
        Sequence = captcha.GetSequence();
        PrintVariants = captcha.GetVariantsString().Split(Constant.VariantsSeparator);
        AnswerIndex = captcha.GetAnswerIndex();
        Answer = captcha.GetAnswer();
    }

    private string GetRandoColor(string[] colors)
        => colors[new Random().Next(0, colors.Length)];
}
