using System;
namespace CaptchaApp.Models;

public sealed class Captcha
{
    private GenerateVariants _genVariants;
    private GenerateSequence _genSequence;

    public Captcha()
    {
        _genSequence = new GenerateSequence();
        _genVariants = new GenerateVariants(_genSequence.Answer);
    }

    public int GetAnswer()
        => _genSequence.Answer;
    
    public string GetSequence()
        => _genSequence.ToString();
    
    public string GetVariantsString()
        => _genVariants.ToString();

    public Int32 GetAnswerIndex()
        => _genVariants.AnswerIndex;
}