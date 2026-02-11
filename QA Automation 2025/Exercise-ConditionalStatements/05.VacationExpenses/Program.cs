// Input //
string season = Console.ReadLine();
string accomodationType = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

// Calculations //
double price = 0;
double discount = 0;
if (season == "Spring") // 20 discount
{
    discount = 0.2;
    if (accomodationType == "Hotel")
    {
        price = 30;
    }
    else // Camping
    {
        price = 10;
    }
}
else if (season == "Summer") // 0% disount
{
    if (accomodationType == "Hotel")
    {
        price = 50;
    }
    else //Camping
    {
        price = 30;
    }
}
else if (season == "Autumn") // 30% disount
{
    discount = 0.3;
    if (accomodationType == "Hotel")
    {
        price = 20;
    }
    else //Camping
    {
        price = 15;
    }
}
else // Winter // 10% disount
{
    discount = 0.1;
    if (accomodationType == "Hotel")
    {
        price = 40;
    }
    else //Camping
    {
        price = 10;
    }
}

// Output //
double priceForAllDays = days * price;
double finalDiscount = priceForAllDays * discount;
double finalPrice = priceForAllDays - finalDiscount;

  Console.WriteLine($"{finalPrice:F2}");


     
