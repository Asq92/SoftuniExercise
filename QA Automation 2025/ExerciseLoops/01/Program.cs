int n = int.Parse(Console.ReadLine());
int p = int.Parse(Console.ReadLine());

int result = 1;
for ( int count = 1; count <= p; count++)
{
    result = result * n;
}
Console.WriteLine(result);