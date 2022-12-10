using System;
namespace CaptchaApp.Models;

public sealed class Captcha
{
    private readonly GenerateVariants _genVariants;
    private readonly GenerateSequence _genSequence;
    private readonly GenerateObstacles _genObstacles;

    public Captcha()
    {
        _genSequence = new GenerateSequence();
        _genVariants = new GenerateVariants(_genSequence.GetSideResults());
        _genObstacles = new GenerateObstacles();
    }

    public string GetSequence()
        => _genSequence.GetMainResult();
    
    public int GetAnswer()
        => _genSequence.GetSideResults();

    public string GetVariantsString()
        => _genVariants.GetMainResult();

    public int GetAnswerIndex()
        => _genVariants.GetSideResults();
    
    public string GetObstacles()
        => _genObstacles.GetMainResult();
}