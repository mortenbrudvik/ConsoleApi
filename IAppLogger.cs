namespace console_api;

public interface IAppLogger<T>
{
    void LogWarning(string message, params object[] args);
    void LogInformation(string message, params object[] args);
    void LogError(string message, params object[] args);
    void LogError(Exception exception, string message, params object[] args);
}