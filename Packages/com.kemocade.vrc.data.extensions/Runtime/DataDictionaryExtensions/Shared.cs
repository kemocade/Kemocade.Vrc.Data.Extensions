namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        const char DOT = '.';
        private static T[] Fit<T>(T[] source, int count)
        {
            // No need to make a copy
            if (source.Length == count) { return source; }

            // Shrink the array if needed
            T[] copy = new T[count];
            System.Array.Copy(source, copy, count);
            return copy;
        }

        private static bool Contains<T>(T[] source, T target)
        {
            foreach (T t in source)
            {
                if (t.Equals(target)) { return true; }
            }
            return false;
        }

        private static bool ContainsNone<T>(T[] source, T[] targets)
        {
            foreach (T target in targets)
            {
                if (Contains(source, target)) { return false; }
            }
            return true;
        }

        private static bool ContainsAll<T>(T[] source, T[] targets)
        {
            foreach (T target in targets)
            {
                if (!Contains(source, target)) { return false; }
            }
            return true;
        }

        private static bool ContainsAny<T>(T[] source, T[] targets) =>
            !ContainsNone(source, targets);
    }
}