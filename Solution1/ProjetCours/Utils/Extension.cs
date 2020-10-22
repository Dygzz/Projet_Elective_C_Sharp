using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetCours.Utils
{
    public static class Extension
    {
        public static string ToJson(this Dictionary<int, int> dic)
        {
            var result = dic.Select(x => string.Format("{0}:{1}", x.Key, x.Value));
            return "{" + string.Join(",", result) + "}";
        }
    }
}
