using System;
namespace CaptchaApp.Models;

public sealed class GenerateVariants
{
    private readonly Int32[] _variants;
    public readonly Int32 AnswerIndex;
    
    public GenerateVariants(int answer)
    {
        _variants = FillVariants(answer, ref AnswerIndex);
    }

    public override string ToString()
    {
        string output = "";

        for (Int16 i = 0; i < _variants.Length; i++)
        {
            string separator = (i+1 == _variants.Length >> 1) ? Constant.VariantsSeparator.ToString() : ""; 
            output += $"{i + 1}.   {_variants[i]}\n{separator}";
        }

        return output;
    }

    private Int32[] FillVariants(Int32 answer, ref Int32 getAnswerIndex)
    {
        Int32[] output = new int[Constant.AnswerAmount];
        
        // Заповнюємо масив з неповторними елементами
        output[0] = answer;
        for (Int16 i = 1; i < Constant.AnswerAmount; i++)
        {
            bool unique;
            Int32 rndValue;
            do
            {
                rndValue = new Random().Next(Constant.MinInputValue * 2, Constant.MaxInputValue * 2);
                unique = true;
                for(Int16 j = 0; j < i; j++)
                    if (output[j] == rndValue)
                        unique = false;
            } while (!unique);
            output[i] = rndValue;
        }

        // Перемішуємо масив випадковим чином
        Int16 n = Constant.AnswerAmount;
        while (n > 1)
        {
            Int16 k = (Int16)new Random().Next(n--);
            (output[k], output[n]) = (output[n], output[k]);
            if (output[n] == answer)
                getAnswerIndex = n;
        }
        
        return output;
    }
}