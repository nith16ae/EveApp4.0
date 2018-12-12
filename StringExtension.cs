using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveOnlineApp
{
    //?
    //What does this do? Who wrote it?
    public static class StringExtension
    {
            public static string GetFirst(this string source, int head_length)
            {
                if (head_length >= source.Length)
                    return source;
                return source.Substring(0, head_length);
            }
    }
    
}
