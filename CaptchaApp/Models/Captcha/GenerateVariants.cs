using System;
namespace CaptchaApp.Models;

public sealed class GenerateVariants: ICaptchaContract<string>
{
    private readonly int[] _variants;
    private readonly int _answerIndex;
    
    public GenerateVariants(int answer)
    {
        _variants = FillVariants(answer, ref _answerIndex);
    }

    private int[] FillVariants(Int32 answer, ref Int32 getAnswerIndex)
    {
        int[] output = new int[Constant.Captcha.AnswerAmount];
        output[0] = answer;
        
        // Заповнюємо масив з неповторними елементами
        for (int i = 1; i < output.Length; i++)
        {
            bool unique;
            int rndValue;
            
            do
            {
                rndValue = new Random().Next(Constant.Captcha.MinInputValue * 2, Constant.Captcha.MaxInputValue * 2);
                unique = true;
                for(int j = 0; j < i; j++)
                    if (output[j] == rndValue)
                        unique = false;
            } while (!unique);
            
            output[i] = rndValue;
        }

        // Перемішуємо масив випадковим чином
        int n = output.Length;
        while (n > 1)
        {
            int k = new Random().Next(n--);
            (output[k], output[n]) = (output[n], output[k]);
            if (output[n] == answer)
                getAnswerIndex = n;
        }
        
        return output;
    }
    
    public string GetMainResult() => GenerateOptions();
    
    public int GetSideResults() => _answerIndex;

    private string GenerateOptions()
    {
        string output = "";

        for (Int16 i = 0; i < _variants.Length; i++)
        {
            string separator = (i + 1 == _variants.Length >> 1) ? Constant.DataCollector.VariantsSeparator.ToString() : ""; 
            output += $"{i + 1}.   {_variants[i]}\n{separator}";
        }

        return output;
    }
}