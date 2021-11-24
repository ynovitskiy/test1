using System;
using static System.String;

namespace Company.Api.Helpers
{
    public static class CacheHelper
    {
        public static string GetKey(string @from, string to)
        {
            return Compare(@from, to, StringComparison.InvariantCulture) == -1 ? $"{from}_{to}" : $"{to}_{from}";
        }
    }
}
