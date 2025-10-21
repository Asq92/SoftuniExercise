// Input //
double basketballSneakers = 0.4;
double basketballUniform = 0.2;
double basketballBall = 1 / 4;
double basketballAccessories = 1 / 5;

double basketballTrainingFee = double.Parse(Console.ReadLine());

// Calculation //
double sneakersCost = basketballTrainingFee * 0.6;
double uniformCost = sneakersCost * 0.8;
double ballCost = uniformCost * 0.25;
double accessoriesCost = ballCost * 0.2;
double totalCost = basketballTrainingFee + sneakersCost + uniformCost + ballCost + accessoriesCost;

// Output //
Console.WriteLine(totalCost);