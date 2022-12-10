using System;
namespace CaptchaApp.Models;

public enum Sign
{
    Plus = 0,
    Minus = 1
};

static class SignExtension
{
    public static int ToInt(this Sign sign)
    {
        return (int)sign;
    }

    public static Sign ToSign(this int signNum)
    {
        if (signNum >= Sign.Plus.ToInt() || signNum <= Sign.Minus.ToInt())
            return (Sign) signNum;
        return Sign.Plus;
    } 
        
    public static Sign GetRandomSign(this Sign sign)
    {
        int rndSign = new Random().Next(Sign.Plus.ToInt(), Sign.Minus.ToInt() + 1);
        return rndSign.ToSign();
    }

    public static char ToChar(this Sign sign)
    {
        return sign switch
        {
            Sign.Minus => '-',
            Sign.Plus  => '+'
        };
    }

    public static int Calc(this Sign sign, int fOpr, int sOpr)
    {
        return sign switch
        {
            Sign.Minus => fOpr - sOpr,
            Sign.Plus  => fOpr + sOpr
        };
    }
}