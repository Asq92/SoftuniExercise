// Input //
double protectNylonPrice = 1.50;
double paintPrice = 14.50;
double paintThinnerPrice = 5.00;
double bags = 0.40;

double nylon = double.Parse(Console.ReadLine());
double paint = double.Parse(Console.ReadLine());
double thinner = double.Parse(Console.ReadLine());
double hoursOfWork = double.Parse(Console.ReadLine());

nylon = nylon + 2;
paint = paint * 1.1;

// Calculations //
double nylonCost = nylon * protectNylonPrice;
double paintCost = paint * paintPrice;
double thinnerCost = thinner * paintThinnerPrice;
double totalMaterialCost = nylonCost + paintCost + thinnerCost + bags;
double workPrice = totalMaterialCost * 0.3;
double workCost = hoursOfWork * workPrice;
double totalCost = totalMaterialCost + workCost;

// Output //
Console.WriteLine(totalCost);





