int countOfPeople = int.Parse(Console.ReadLine());  
double entranceTicket = double.Parse(Console.ReadLine());   
double priceOneBed = double.Parse(Console.ReadLine());  
double priceOneUmbarella = double.Parse(Console.ReadLine());

double totalPriceTicket = countOfPeople * entranceTicket;
double countOfBeds = Math.Ceiling(countOfPeople * 0.75);
double countOfUmbrellas = Math.Ceiling((double)countOfPeople / 2);
double totalPriceToPay = totalPriceTicket + (countOfBeds * priceOneBed) + (countOfUmbrellas * priceOneUmbarella);

Console.WriteLine($"{totalPriceToPay:F2} lv.");