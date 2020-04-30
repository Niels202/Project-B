using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static string Multiply(this string source, int multiplier)
        {
        StringBuilder sb = new StringBuilder(multiplier * source.Length);
        for (int i = 0; i < multiplier; i++)
        {
            sb.Append(source);
        }

        return sb.ToString();
        }

    }
}