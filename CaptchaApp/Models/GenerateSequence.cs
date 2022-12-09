using System;
using System.ComponentModel;
namespace CaptchaApp.Models;

public sealed class GenerateSequence: ICaptchaContract<string>
{
    private readonly int _minInputValues;
    private readonly int _maxInputValues;
    private int _answer;
    private string _sequence;

    public GenerateSequence()
    {
        _minInputValues = Math.Min(Constant.Captcha.MinInputValue, Constant.Captcha.MaxInputValue);
        _maxInputValues = Math.Max(Constant.Captcha.MinInputValue, Constant.Captcha.MaxInputValue);
        Generate();
    }

    private void Generate()
    {
        int firstOperand = new Random().Next(_minInputValues, _maxInputValues);
        int secondOperand = new Random().Next(_minInputValues, _maxInputValues);
        Sign chooseOperator = new Sign().GetRandomSign();

        if (secondOperand < 0 && chooseOperator == Sign.Minus)
            _sequence = $"{firstOperand} + {Math.Abs(secondOperand)}";
        else if (secondOperand < 0 && chooseOperator == Sign.Plus)
            _sequence = $"{firstOperand} - {Math.Abs(secondOperand)}";
        else
            _sequence = $"{firstOperand} {chooseOperator.ToChar()} {secondOperand}";
        
        _answer = chooseOperator.Calc(firstOperand, secondOperand);
    }
    
    public string GetMainResult() => _sequence;

    public int GetSideResults() => _answer;
}