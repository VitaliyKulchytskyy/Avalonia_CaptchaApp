namespace CaptchaApp.Models;

public interface ICaptchaContract<out T>
{
     public T GetMainResult();
     public object? GetSideResults() => null;
}