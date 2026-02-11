// Input //
int firstTime = int.Parse(Console.ReadLine());
int secondTime = int.Parse(Console.ReadLine());
int thirdTime = int.Parse(Console.ReadLine());

// Output //
int totalTimeInSeconds = firstTime + secondTime + thirdTime;
int minutes = totalTimeInSeconds / 60;
int seconds = totalTimeInSeconds % 60;
Console.WriteLine($"{minutes}:{seconds:D2}");