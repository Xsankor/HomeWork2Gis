using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8
{
    public static class ArrayExtensions
    {
        public static string Print(int[] array, char cyrsor)
        {
            var result = string.Empty;
            foreach (var element in array)
            {
                result = result + element.ToString() + cyrsor;
            }
            return result;
        }
    }
}
