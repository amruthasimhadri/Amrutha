using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegexample
{
    public  class Class1
    {
        public delegate string fun();
        public fun delvar { get; set; }
    }
    public class class2
    {
        public string fun1()
        {
            return "Ammu";
        }
        
    }

}
