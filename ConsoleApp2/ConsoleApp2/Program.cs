// See https://aka.ms/new-console-template for more information
int r1 = Console.Read();
int  r2 = Console.Read();
int c = 0;
for(int i = r1; i < r2; i++)
{
    while (i != 0)
    {
        int  rem = i % 10;
        if(rem==1)
        {
            c = c + 1;
        }
        i=Math.Floor(i/10);
    }
}
Console.WriteLine(c);