using System;
using System.Linq;
namespace CaptchaApp.Models;

public class GenerateObstacles: ICaptchaContract<string>
{
    private readonly string _obstacles;

    public GenerateObstacles()
    {
        _obstacles = GenObstacles();
    }

    public string GetMainResult()
        => _obstacles;

    private string GenObstacles()
    {
        string output = "";
        
        for (int i = 0; i < Constant.Obstacle.Columns; i++)
        {
            int rndLength = new Random().Next(Constant.Obstacle.SubStringMinLength, Constant.Obstacle.SubStringMaxLength);
            string substring = string.Concat(Enumerable.Range(0, rndLength).Select<int, string>(a => Constant.Obstacle.Alphabet.GetRandomSymbol()));
            output += substring + (i != Constant.Obstacle.Columns - 1 ? "\n" : "");
        }

        return output;
    }
}

public static class StringExtension
{
    public static string GetRandomSymbol(this string alphabet)
        => alphabet[new Random().Next(alphabet.Length)].ToString();
}