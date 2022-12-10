using System;
using System.Collections.Generic;
using System.Linq;

namespace CaptchaApp.Models;

public sealed class GenerateVariants: ICaptchaContract<string>
{
    private readonly int[] _variants;
    private int _answerIndex;
    
    public GenerateVariants(int answer)
    {
        _variants = FillVariants(answer);
    }
    
    public string GetMainResult() => GenerateOptions();
    
    public int GetSideResults() => _answerIndex;

    private string GenerateOptions()
    {
        string output = "";
        int halfOfLength = _variants.Length >> 1;
        
        for (int i = 0; i < _variants.Length; i++)
        {
            string separator = (i + 1 == halfOfLength) ? Constant.DataCollector.VariantsSeparator.ToString() : ""; 
            output += $"{i + 1}.   {_variants[i]}\n{separator}";
        }

        return output;
    }
    
    private int[] FillVariants(int answer)
    {
        var output = new HashSet<int>(Constant.Captcha.AnswerAmount) {answer};

        for (int i = 0; i < Constant.Captcha.AnswerAmount - 1; i++)
        {
            int rndValue;
            
            do
                rndValue = new Random().Next(Constant.Captcha.MinInputValue * 2, Constant.Captcha.MaxInputValue * 2);
            while (output.Contains(rndValue));

            output.Add(rndValue);
        }

        return GetShuffledSet(output, answer, ref _answerIndex);
    }

    private int[] GetShuffledSet(HashSet<int> set, int answer, ref int answerIndex)
    {
        int[] output = set.ToArray();

        for (int i = output.Length - 1; i > 0; i--)
        {
            int j = new Random().Next(i + 1);
            (output[i], output[j]) = (output[j], output[i]);
            if (output[i] == answer)
                answerIndex = i;
        }

        return output;
    }
}