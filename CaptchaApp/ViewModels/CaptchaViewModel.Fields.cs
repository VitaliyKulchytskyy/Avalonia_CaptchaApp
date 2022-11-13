using CaptchaApp.Models;
using ReactiveUI;
namespace CaptchaApp.ViewModels;

public partial class CaptchaViewModel
{
    public int MaxVariants
    {
        get => Constant.AnswerAmount;
    }
    
    private string _captchaReport;
    public string CaptchaReport
    {
        get => _captchaReport;
        set => this.RaiseAndSetIfChanged(ref _captchaReport, value);
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

    private string[] _answerVariants;
    public string[] AnswerVariants
    {
        get => AnswerVariants;
        set => this.RaiseAndSetIfChanged(ref _answerVariants, value);
    }

    private string _variants;
    public string Variants
    {
        get => _variants;
        set => this.RaiseAndSetIfChanged(ref _variants, value);
    }

    public int MainWindowHeight
    {
        get => Constant.MainWindowHeight;
    }
    
    public int MainWindowWidth
    {
        get => Constant.MainWindowWidth;
    }

    private string[] _printVariants;
    public string[] PrintVariants
    {
        get => _printVariants;
        set => this.RaiseAndSetIfChanged(ref _printVariants, value);   
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