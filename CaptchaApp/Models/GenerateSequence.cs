using System;
using System.ComponentModel;
namespace CaptchaApp.Models;

public sealed class GenerateSequence
{
    private readonly Int32 _minInputValues;
    private readonly Int32 _maxInputValues;
    public Int32 Answer { get; private set; } = 0;
    private string _sequence { get; set; } = "0 + 0";
    public string Sequence
    {
        get => _sequence;
    }
    
    public GenerateSequence()
    {
        _minInputValues = Math.Min(Constant.MinInputValue, Constant.MaxInputValue);
        _maxInputValues = Math.Max(Constant.MinInputValue, Constant.MaxInputValue);
        Generate();
    }

    private void Generate()
    {
        Int32 firstOperand = new Random().Next(_minInputValues, _maxInputValues);
        Int32 secondOperand = new Random().Next(_minInputValues, _maxInputValues);
        Sign chooseOperator = new Sign().GetRandomSign();

        if (secondOperand < 0 && chooseOperator == Sign.Minus)
            _sequence = $"{firstOperand} + {Math.Abs(secondOperand)}";
        else if (secondOperand < 0 && chooseOperator == Sign.Plus)
            _sequence = $"{firstOperand} - {Math.Abs(secondOperand)}";
        else
            _sequence = $"{firstOperand} {chooseOperator.ToChar()} {secondOperand}";
        
        Answer = chooseOperator.Calc(firstOperand, secondOperand);
    }

    public override string ToString()
        => _sequence;
}