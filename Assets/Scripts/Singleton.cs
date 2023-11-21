using System;

public class Singleton<T> where T : class, new()
{
    private static readonly Lazy<T> _instanse = new Lazy<T>(() => new T());
    public static T Instance => _instanse.Value;
    public bool HasInstanse => Instance != null;
}

public class BackgroundDataManager : Singleton<BackgroundDataManager>
{

}