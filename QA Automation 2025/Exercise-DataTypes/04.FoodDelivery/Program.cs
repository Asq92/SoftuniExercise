// Input //
double chickenMenuPrice = 10.35;
double fishMenuPrice = 12.40;
double vegetarianMenuPrice = 8.15;
double deliveryPrice = 2.50;


double chickenMenuOrderQuantity = double.Parse(Console.ReadLine());
double fishMenuOrderQuantity = double.Parse(Console.ReadLine());
double vegetarianMenuOrderQuantity = double.Parse(Console.ReadLine());


// Calculations //
double chickenOrderCost = chickenMenuOrderQuantity * chickenMenuPrice;
double fishOrderCost = fishMenuOrderQuantity * fishMenuPrice;
double vegetarianOrderCost = vegetarianMenuOrderQuantity * vegetarianMenuPrice;
double totalMenuOrderCost = chickenOrderCost + fishOrderCost + vegetarianOrderCost;
double desertOrderPercentage = 0.2;
double totalDesertOrderCost = totalMenuOrderCost * desertOrderPercentage;
double totalOrderCost = totalMenuOrderCost + totalDesertOrderCost  + deliveryPrice;

// Output //
Console.WriteLine(totalOrderCost);

