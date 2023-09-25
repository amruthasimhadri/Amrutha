using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Class2
    {
        List<Class1> list = new List<Class1>()
        {
            new Class1 {id=1,name="Ammu"},
            new Class1 {id=2,name="navvu"}
        };
        public IEnumerable<Class1> GetElements()
        {
            return list;
        }
        public void getvalues(out int a,out int b)
        {
            a = 0;
            b = 1;
        }
        
        
    }
}
