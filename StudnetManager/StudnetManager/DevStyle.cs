using System;
using System.Collections.Generic;

namespace DevStyle
{
    public static class List
    {
        public static List<T> Empty<T>(T typeDescriptor)
        {
            return new List<T>();
        }
    }
}