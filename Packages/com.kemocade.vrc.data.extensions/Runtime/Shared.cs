namespace Kemocade.Vrc.Data.Extensions
{
    public static class Shared
    {
        private static readonly int zero = 0;

        public static T ForceException<T>() => (T)(object)(1 / zero);
    }
}