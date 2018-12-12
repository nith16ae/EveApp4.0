using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveOnlineApp
{
    //Author: Nicolai Thomsen
    // This static helper method helps get only the region part (the part that is issued in the URL) from the dropbox list
    // of all the regions. An example: Turns '10000002 The Forge' into '10000002'
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
