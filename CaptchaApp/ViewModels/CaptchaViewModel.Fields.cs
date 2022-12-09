using CaptchaApp.Models;
using ReactiveUI;
namespace CaptchaApp.ViewModels;

public partial class CaptchaViewModel
{
    public int MaxVariants
    {
        get => Constant.Captcha.AnswerAmount;
    }

    private string _captchaObstacle;
    public string CaptchaObstacle
    {
        get => _captchaObstacle;
        set => this.RaiseAndSetIfChanged(ref _captchaObstacle, value);
    }

    private string _sequence;
    public string Sequence
    {
        get => _sequence;
        set => this.RaiseAndSetIfChanged(ref _sequence, value);
    }

    private int _answerIndex;
    public int AnswerIndex
    {
        get => _answerIndex + 1;
        set => this.RaiseAndSetIfChanged(ref _answerIndex, value);
    }

    private int _answer;
    public int Answer
    {
        get => _answer;
        set => this.RaiseAndSetIfChanged(ref _answer, value);
    }

    public int MainWindowHeight
    {
        get => Constant.Window.MainWindowHeight;
    }
    
    public int MainWindowWidth
    {
        get => Constant.Window.MainWindowWidth;
    }

    private string[] _printVariants;
    public string[] PrintVariants
    {
        get => _printVariants;
        set => this.RaiseAndSetIfChanged(ref _printVariants, value);   
    }

    private int _attemptsAmountCounter;
    public int AttemptsAmountCounter
    {
        get => _attemptsAmountCounter;
        set => this.RaiseAndSetIfChanged(ref _attemptsAmountCounter, value);
    }

    private string _captchaBackground;
    public string CaptchaBackground
    {
        get => _captchaBackground;
        set => this.RaiseAndSetIfChanged(ref _captchaBackground, value);   
    }

    private static readonly string[] _sBackgroundColors =
    {
        "DarkSlateGray",
        "DeepPink",
        "CornflowerBlue",
        "Cyan"
    };
}