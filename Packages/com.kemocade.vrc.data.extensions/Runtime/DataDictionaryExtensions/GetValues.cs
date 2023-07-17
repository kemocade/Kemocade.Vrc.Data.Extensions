using VRC.SDK3.Data;
using static Kemocade.Vrc.Data.Extensions.Shared;

namespace Kemocade.Vrc.Data.Extensions
{
	public static partial class DataDictionaryExtensions
	{
		public static T[] GetValues<T>
		(this DataDictionary source, string key, char split = DOT) =>
			source.TryGetValues(key, out T[] result, split) ?
			result : ForceException<T[]>();
	}
}