// Input //
double lenght = double.Parse(Console.ReadLine());
double widht = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());
double decorationPercetange = double.Parse(Console.ReadLine());

// Calculations //

double aquarioumVolumeInCm = lenght * widht * height;
double aquarioumVolumeInLiters = aquarioumVolumeInCm * 0.001;
double decorationPercentageVolume = aquarioumVolumeInLiters * (decorationPercetange / 100);
double waterVolume = aquarioumVolumeInLiters - decorationPercentageVolume;

// Output //
Console.WriteLine($"{waterVolume:F2}");



