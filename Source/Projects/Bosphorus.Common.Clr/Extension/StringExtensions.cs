using System;
using System.Collections.Generic;

namespace Bosphorus.Common.Clr.Extension
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string str, int maxLength)
        {
            for (int index = 0; index < str.Length; index += maxLength)
            {
                yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
            }
        }
    }
}
