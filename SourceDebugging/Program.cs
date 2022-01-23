using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<string>();
            var add = hashSet.Add("asdfa");
        }
    }
}
