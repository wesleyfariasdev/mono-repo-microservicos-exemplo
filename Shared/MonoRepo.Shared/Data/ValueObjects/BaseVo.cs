namespace MonoRepo.Shared.Data.ValueObjects;

public class BaseVo<T>
    where T : BaseVo<T>, new()
{
    public static T Empty => new T();
    public static List<T> EmptyList => new List<T>();
}
