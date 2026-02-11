// Input //
int oneHourOfTheDay = int.Parse(Console.ReadLine());
string dayOfTheWeek = Console.ReadLine();

// Output //
bool workingDay = dayOfTheWeek != "Sunday";
bool workingHour = oneHourOfTheDay >= 10 && oneHourOfTheDay <= 18;
if (workingDay && workingHour)
{
    Console.WriteLine( "open");
}
else
{
    Console.WriteLine("closed");
}