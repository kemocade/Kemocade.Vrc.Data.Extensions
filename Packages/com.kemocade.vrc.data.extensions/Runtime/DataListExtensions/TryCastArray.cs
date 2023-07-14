using VRC.SDK3.Data;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataListExtensions
    {
        public static bool TryCastArray<T>(this DataList root, out T[] result)
        {
            result = default;

            T[] temp = new T[root.Count];
            for (int i = 0; i < root.Count; i++)
            {
                if (!root[i].TryCast(out T next)) { return false; }
                temp[i] = next;
            }
            result = temp;

            return true;
        }
    }
}