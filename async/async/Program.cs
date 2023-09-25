async Task<int> longprocess()
{
    Console.WriteLine("L start");
    await Task.Delay(1000);
    Console.WriteLine("L end");
    return 10;
}
void shortprocess()
{
    Console.WriteLine("S start");
    Console.WriteLine("S end");
}
Task<int> result=longprocess();
shortprocess();
var val=await result;
Console.WriteLine(val);