// See https://aka.ms/new-console-template for more information
using ConsoleApp3;

Console.WriteLine("Hello, World!");
Class2 c2 = new Class2();
c2.GetElements();
foreach (var a in c2.GetElements())
{
    Console.WriteLine(a.id + " " + a.name);
}

c2.getvalues(out int am, out int b);
Console.WriteLine(am + " " + b);

