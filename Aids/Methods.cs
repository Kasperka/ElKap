using System.Reflection;

namespace ElKap.Aids
{
    public static class Methods
    {
        public static bool HasAttribute<TAttribute>(this MethodInfo? m) where TAttribute : Attribute
            => Safe.Run(() => m?.GetCustomAttribute<TAttribute>() is not null, false);
    }
}

