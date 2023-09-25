using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ns
{
    //class person
    //{
    //    public person()
    //    {
    //        Console.WriteLine("person");
    //    }
    //    public person(string val)
    //    {
    //        Console.WriteLine(val);
    //    }
    //}
    //class emp : person
    //{
    //    public emp():base("ammu")
    //    {
    //        Console.WriteLine("empConstructor");

    //    }


    //}
    //public interface inter
    //{
    //    public void display()
    //    {
    //        Console.WriteLine("hello");
    //    }
    //}
    //public class emp2 : inter
    //{
    //    public void display()
    //    {
    //        Console.WriteLine("hello1");
    //    }
    //}
     class c1
    {
        public void display()
        {
            Console.WriteLine("hello");
        }
    }
    class c2 : c1
    {
        public void display()
        {
            Console.WriteLine("hello2");
        }
    }
    
}