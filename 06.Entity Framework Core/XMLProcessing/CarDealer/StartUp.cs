using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using ProductShop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            ResetAndSeedDatabase(context);
            // Problem 14
            string result = GetCarsWithDistance(context);
            WriteSerializationResult("cars.xml", result);
            Console.WriteLine(result);

            // Problem 15
            result = GetCarsFromMakeBmw(context);
            WriteSerializationResult("bmw-cars.xml", result);
            Console.WriteLine(result);

            // Problem 16
            result = GetLocalSuppliers(context);
            WriteSerializationResult("local-suppliers.xml", result);
            Console.WriteLine(result);

            // Problem 17
            result = GetCarsWithTheirListOfParts(context);
            WriteSerializationResult("cars-and-parts.xml", result);
            Console.WriteLine(result);

            // Problem 18
            result = GetTotalSalesByCustomer(context);
            WriteSerializationResult("customers-total-sales.xml", result);
            Console.WriteLine(result);

            // Problem 19
            result = GetSalesWithAppliedDiscount(context);
            WriteSerializationResult("sales-discounts.xml", result);
            Console.WriteLine(result);



        }

        // Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ICollection<Supplier> suppliersToImport = new List<Supplier>();

            ImportSuppliersDto[]? suppliersDtos = XmlSerializerWrapper
                .Deserialize<ImportSuppliersDto[]>(inputXml, "Suppliers");
            if (suppliersDtos != null)
            {
                foreach (ImportSuppliersDto suppliersDto in suppliersDtos)
                {
                    if (!IsValid(suppliersDtos))
                    {
                        continue;
                    }

                    bool isImporterValid = bool
                        .TryParse(suppliersDto.IsImporter, out bool isImporter);
                    if (!isImporterValid)
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = suppliersDto.Name,
                        IsImporter = isImporter
                    };

                    suppliersToImport.Add(supplier);
                }

                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {suppliersToImport.Count}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ICollection<Part> partsToImport = new List<Part>();

            ImportPartsDto[]? partsDtos = XmlSerializerWrapper
                .Deserialize<ImportPartsDto[]>(inputXml, "Parts");
            if (partsDtos != null)
            {
                foreach (ImportPartsDto part in partsDtos)
                {
                    if (!IsValid(part))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal
                        .TryParse(part.Price.ToString(), out decimal price);
                    bool isQuantityValid = int
                        .TryParse(part.Quantity.ToString(), out int quantity);
                    bool isSupplierIdValid = int
                        .TryParse(part.SupplierId.ToString(), out int supplierId);
                    if (!isPriceValid || !isQuantityValid || !isSupplierIdValid)
                    {
                        continue;
                    }

                    bool doesSupplierExist = context
                        .Suppliers
                        .Any(s => s.Id == supplierId);
                    if (!doesSupplierExist)
                    {
                        continue;
                    }

                    Part partToAdd = new Part()
                    {
                        Name = part.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId
                    };

                    partsToImport.Add(partToAdd);
                }

                context.Parts.AddRange(partsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {partsToImport.Count}";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ICollection<Car> carsToImport = new List<Car>();

            ImportCarsDto[]? importCarDtos = XmlSerializerWrapper
                 .Deserialize<ImportCarsDto[]>(inputXml, "Cars");
            IEnumerable<int> partsId = context
                .Parts
                .AsNoTracking()
                .Select(p => p.Id)
                .ToArray();

            if (importCarDtos != null)
            {
                foreach (var carDto in importCarDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isTravelledDistance = long
                        .TryParse(carDto.TravelledDistance, out long traveledDistance);

                    if (!isTravelledDistance)
                    {
                        continue;
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistance
                    };

                    foreach (var idPart in carDto.PartId!
                                            .Select(pId => int.Parse(pId.Id))
                                            .Distinct()
                                            .ToArray())
                    {
                        if (!partsId.Contains(idPart))
                            continue;

                        PartCar partCar = new PartCar()
                        {
                            PartId = idPart,
                            Car = car
                        };

                        car.PartsCars.Add(partCar);
                    }

                    carsToImport.Add(car);
                }

                context.Cars.AddRange(carsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {carsToImport.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ICollection<Customer> customersToImport = new List<Customer>();

            ImportCustomersDto[]? customersDtos = XmlSerializerWrapper
                .Deserialize<ImportCustomersDto[]>(inputXml, "Customers");
            if (customersDtos != null)
            {
                foreach (ImportCustomersDto customerDto in customersDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isBirthDateValid = DateTime
                        .TryParse(customerDto.BirthDate, out DateTime birthDate);
                    bool isYoungDriverValid = bool
                        .TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);
                    if (!isBirthDateValid || !isYoungDriverValid)
                    {
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customersToImport.Add(customer);
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {customersToImport.Count}";

        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ICollection<Sale> salesToImport = new List<Sale>();

            ImportSalesDto[]? salesDtos = XmlSerializerWrapper
                .Deserialize<ImportSalesDto[]>(inputXml, "Sales");
            IEnumerable<int> carIds = context
                .Cars
                .AsNoTracking()
                .Select(c => c.Id)
                .ToArray();

            if (salesDtos != null)
            {
                foreach (ImportSalesDto saleDto in salesDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    bool isCarIdValid = int
                        .TryParse(saleDto.CarId, out int carId);
                    bool isCustomerIdValid = int
                        .TryParse(saleDto.CustomerId, out int customerId);
                    bool isDiscountValid = decimal
                        .TryParse(saleDto.Discount, out decimal discount);
                    if (!isCarIdValid || !isCustomerIdValid || !isDiscountValid)
                    {
                        continue;
                    }

                    if (!carIds.Contains(carId))
                    {
                        continue;
                    }

                    Sale sale = new Sale()
                    {
                        CarId = carId,
                        CustomerId = customerId,
                        Discount = discount
                    };

                    salesToImport.Add(sale);
                }

                context.Sales.AddRange(salesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {salesToImport.Count}";
        }

        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsDto[] carsWithDistance = context
                .Cars
                .AsNoTracking()
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();


            string result = XmlSerializerWrapper
                .Serialize(carsWithDistance, "cars");
            return result;
        }

        // Probel 15

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {

            ExportBMWCarsDto[] carsFromMakeBmw = context
                .Cars
                .AsNoTracking()
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportBMWCarsDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            string result = XmlSerializerWrapper
               .Serialize(carsFromMakeBmw, "cars");

            return result;
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .AsNoTracking()
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(localSuppliers, "suppliers");

            return result;
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarsWithListOfPartsDto[] exportCarsWithListOfParts = context
                   .Cars
                   .AsNoTracking()
                   .Select(c => new ExportCarsWithListOfPartsDto
                   {
                       Make = c.Make,
                       Model = c.Model,
                       TravelledDistance = c.TraveledDistance,
                       Parts = c.PartsCars
                           .Select(pc => new ExportPartDto
                           {
                               Name = pc.Part.Name,
                               Price = pc.Part.Price
                           })
                           .OrderByDescending(p => p.Price)
                           .ToArray()
                   })
                   .OrderByDescending(c => c.TravelledDistance)
                   .ThenBy(c => c.Model)
                   .Take(5)
                   .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(exportCarsWithListOfParts, "cars");

            return result;

        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            ExportTotalSalesCustomerDto[] exportTotalSalesCustomerDtos = context
                .Customers
                .AsNoTracking()
                .Where(c => c.Sales.Any())
                .Select(c => new ExportTotalSalesCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = (decimal)CalculateSpentMoneyOnCars(c.Sales, c.IsYoungDriver, 5)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(exportTotalSalesCustomerDtos, "customers");

            return result;
        }

        private static double CalculateSpentMoneyOnCars(IEnumerable<Sale> sales, bool isYoungDriver, decimal discount)
        {
            if (isYoungDriver)
            {
                return sales
                    .Sum(s => s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2)));
            }

            return sales
                .Sum(s => s.Car.PartsCars.Sum(pc => (double)pc.Part.Price));
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesWithDiscountDto[] salesWithAppliedDiscount = context
                .Sales
                .AsNoTracking()
                .Include(s => s.Car)
                .ThenInclude(c => c.PartsCars)
                .Include(s => s.Customer)
                .Select(s => new ExportSalesWithDiscountDto
                {
                    Car = new CarsWithDistanceAttributes
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round((double)s.Car.PartsCars
                        .Sum(pc => pc.Part.Price) * (double)(1 - (s.Discount / 100)), 4)
                })
                .Take(10)
                .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(salesWithAppliedDiscount, "sales");

            return result;
        }

        private static string ReadXmlDatasetFileContents(string fileName)
        {
            string xmlFileDirPath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string suppliersXml = File
                .ReadAllText(xmlFileDirPath + fileName);

            return suppliersXml;
        }

        private static void ResetAndSeedDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string xmlSuppliersFileName = "suppliers.xml";
            string xmlPartsFilePath = "parts.xml";
            string xmlCarsFilePath = "cars.xml";
            string xmlCustomersFilePath = "customers.xml";
            string xmlSalesFilePath = "sales.xml";

            string fileContent = ReadXmlDatasetFileContents(xmlSalesFilePath);
            string result = ImportSales(context, fileContent);
            Console.WriteLine(result);
        }

        private static void WriteSerializationResult(string fileName, string text)
        {
            string xmlFileDirPath = Path
               .Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            File
                 .WriteAllText(xmlFileDirPath + fileName, text, Encoding.Unicode);
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator
                .TryValidateObject(obj, validationContext, validationResults);
        }
    }
}