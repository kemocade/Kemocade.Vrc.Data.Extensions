using VRC.SDK3.Data;
using static VRC.SDK3.Data.JsonExportType;

namespace Kemocade.Vrc.Data.Extensions
{
    public static partial class DataDictionaryExtensions
    {
        public static bool TrySerializeToJson(this DataDictionary[] dicts, out string result)
        {
            DataList dictsList = new DataList();
            foreach (DataDictionary dict in dicts) { dictsList.Add(dict); }

            if (!VRCJson.TrySerializeToJson(dictsList, Beautify, out DataToken resultToken))
            {
                result = null;
                return false;
            }

            result = resultToken.String;
            return true;
        }
    }
}