using System;
using System.ComponentModel;
namespace CaptchaApp.Models;

public sealed class GenerateSequence: ICaptchaContract<string>
{
    private readonly int _minInputValues;
    private readonly int _maxInputValues;
    private readonly int _answer;
    private readonly string _sequence;

    public GenerateSequence()
    {
        _minInputValues = Math.Min(Constant.Captcha.MinInputValue, Constant.Captcha.MaxInputValue);
        _maxInputValues = Math.Max(Constant.Captcha.MinInputValue, Constant.Captcha.MaxInputValue);
        Generate(out _sequence, out _answer);
    }

    public string GetMainResult() => _sequence;

    public int GetSideResults() => _answer;
    
    private void Generate(out string sequence, out int answerOfSequence)
    {
        int firstOperand = new Random().Next(_minInputValues, _maxInputValues);
        int secondOperand = new Random().Next(_minInputValues, _maxInputValues);
        Sign chooseOperator = new Sign().GetRandomSign();

        if (secondOperand < 0 && chooseOperator == Sign.Minus)
            sequence = $"{firstOperand} + {Math.Abs(secondOperand)}";
        else if (secondOperand < 0 && chooseOperator == Sign.Plus)
            sequence = $"{firstOperand} - {Math.Abs(secondOperand)}";
        else
            sequence = $"{firstOperand} {chooseOperator.ToChar()} {secondOperand}";
        
        answerOfSequence = chooseOperator.Calc(firstOperand, secondOperand);
    }
}