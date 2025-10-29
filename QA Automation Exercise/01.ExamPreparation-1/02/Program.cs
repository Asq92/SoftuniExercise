int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int firstMiddleElement = numbers[numbers.Length / 2 - 1];
int secondMiddleElement = numbers[numbers.Length / 2];

double average = (firstMiddleElement + secondMiddleElement) / 2.0;

Console.WriteLine($"{average:F2}");