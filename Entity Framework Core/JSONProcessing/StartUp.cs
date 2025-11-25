using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string jsonFileDirePath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

            string jsonSuppliersFileName = "suppliers.json";
            string jsonPartsFileName = "parts.json";
            string jsonCarsFileName = "cars.json";
            string jsonCustomersFileName = "customers.json";
            string jsonSalesFileName = "sales.json";

            string jsonFileText = File
                .ReadAllText(jsonFileDirePath + jsonSalesFileName);

            // Problem 9-13 Import Methods
            string result = ImportSales(context, jsonFileText);
            Console.WriteLine(result);

            // Problem 14-19 Export Methods
            string orderedCustomers = GetOrderedCustomers(context);
            Console.WriteLine(orderedCustomers);

            string carsFromMakeToyota = GetCarsFromMakeToyota(context);
            Console.WriteLine(carsFromMakeToyota);

            string localSuppliers = GetLocalSuppliers(context);
            Console.WriteLine(localSuppliers);

            string carsWithTheirListOfParts = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(carsWithTheirListOfParts);

            string totalSalesByCustomer = GetTotalSalesByCustomer(context);
            Console.WriteLine(totalSalesByCustomer);

            string salesWithAppliedDiscount = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(salesWithAppliedDiscount);
        }

        // Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ICollection<Supplier> suppliersToImport = new List<Supplier>();

            IEnumerable<ImportSupplierDto>? supplierDtos = JsonConvert
                .DeserializeObject<ImportSupplierDto[]>(inputJson);
            if (supplierDtos != null)
            {
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    bool isImporterValidValue = bool
                        .TryParse(supplierDto.IsImporter, out bool isImporter);
                    if (!isImporterValidValue)
                    {
                        continue;
                    }

                    Supplier newSupplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporter
                    };
                    suppliersToImport.Add(newSupplier);
                }

                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {suppliersToImport.Count}.";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ICollection<Part> partsToImport = new List<Part>();

            ICollection<int> existingSupplierIds = context
                .Suppliers
                .AsNoTracking()
                .Select(s => s.Id)
                .ToArray();

            IEnumerable<ImportPartDto>? partDtos = JsonConvert
                .DeserializeObject<ImportPartDto[]>(inputJson);
            if (partDtos != null)
            {
                foreach (ImportPartDto partDto in partDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    bool isSupplierValid = int
                        .TryParse(partDto.SupplierId, out int supplierId);
                    if (!isSupplierValid ||
                        !existingSupplierIds.Contains(supplierId))
                    {
                        continue;
                    }

                    Part newPart = new Part()
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = supplierId
                    };

                    partsToImport.Add(newPart);
                }

                context.Parts.AddRange(partsToImport);
                context.SaveChanges();

            }

            return $"Successfully imported {partsToImport.Count}.";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ICollection<Car> carsToImport = new List<Car>();

            ICollection<PartCar> partsCarsToImport = new List<PartCar>();

            IEnumerable<ImportCarDto>? carDtos = JsonConvert
                .DeserializeObject<ImportCarDto[]>(inputJson);
            if (carDtos != null)
            {
                foreach (ImportCarDto carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    Car newCar = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance
                    };

                    carsToImport.Add(newCar);

                    foreach (int partId in carDto.PartsIds.Distinct())
                    {
                        if (!context.Parts.Any(p => p.Id == partId))
                        {
                            continue;
                        }

                        PartCar newPartCar = new PartCar()
                        {
                            PartId = partId,
                            Car = newCar
                        };

                        partsCarsToImport.Add(newPartCar);
                    }
                }

                //context.Cars.AddRange(carsToImport);
                context.PartsCars.AddRange(partsCarsToImport);

                context.SaveChanges();
            }

            return $"Successfully imported {carsToImport.Count}.";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ICollection<Customer> customersToImport = new List<Customer>();

            IEnumerable<ImportCustomerDto>? importCustomerDtos = JsonConvert
                .DeserializeObject<ImportCustomerDto[]>(inputJson);
            if (importCustomerDtos != null)
            {
                foreach (ImportCustomerDto customerDto in importCustomerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isBirthDateValid = DateTime
                        .TryParseExact(customerDto.BirthDate, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime birthDate);
                    bool isYoungDriverValid = bool
                        .TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);
                    if (!isBirthDateValid || !isYoungDriverValid)
                    {
                        continue;
                    }

                    Customer newCustomer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customersToImport.Add(newCustomer);
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {customersToImport.Count}.";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ICollection<Sale> salesToImport = new List<Sale>();

            IEnumerable<ImportSaleDto>? importSaleDtos = JsonConvert
                .DeserializeObject<ImportSaleDto[]>(inputJson);
            if (importSaleDtos != null)
            {
                foreach (ImportSaleDto saleDto in importSaleDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }
                    
                    bool isCarIdExisting = context
                        .Cars
                        .Any(c => c.Id == saleDto.CarId);
                    bool isCustomerIdExisting = context
                        .Customers
                        .Any(c => c.Id == saleDto.CustomerId);
                    if (!isCarIdExisting || !isCustomerIdExisting)
                    {
                        continue;
                    }

                    Sale newSale = new Sale()
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };

                    salesToImport.Add(newSale);
                }

                context.Sales.AddRange(salesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {salesToImport.Count}.";
        }

        // Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context
                .Customers
                .AsNoTracking()
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(orderedCustomers, Formatting.Indented);

            return jsonResult;
        }

        // Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context
                .Cars
                .AsNoTracking()
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(carsFromMakeToyota, Formatting.Indented);

            return jsonResult;
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .AsNoTracking()
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(localSuppliers, Formatting.Indented);

            return jsonResult;
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context
                .Cars
                .Include(c => c.PartsCars)
                .ThenInclude(pc => pc.Part)
                .AsNoTracking()
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray();

            string jsonResult = JsonConvert
                 .SerializeObject(carsWithTheirListOfParts, Formatting.Indented);

            return jsonResult;
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithSales = context
                .Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car)
                .ThenInclude(ca => ca.PartsCars)
                .ThenInclude(pc => pc.Part)
                .AsNoTracking()
                .Where(c => c.Sales.Any((s => s.Car != null)))
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(customersWithSales, Formatting.Indented);

            return jsonResult;
        }

        // Problem 19 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var top10Sales = context
                .Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .ThenInclude(c => c.PartsCars)
                .ThenInclude(pc => pc.Part)
                .AsNoTracking()
                .Select(s => new
                {
                    Car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    CustomerName = s.Customer.Name,
                    CustomerIsYoungDriver = s.Customer.IsYoungDriver,
                    Discount = s.Discount,
                    Price = s.Car.PartsCars
                        .Select(pc => pc.Part)
                        .Sum(p => p.Price),
                })
                .Take(10)
                .ToArray();

            var saleExportDto = top10Sales
                .Select(s => new
                {
                    car = s.Car,
                    customerName = s.CustomerName,
                    discount = s.Discount.ToString("F2"),
                    price = s.Price.ToString("F2"),
                    priceWithDiscount = (s.Price - (s.Price * s.Discount / 100)).ToString("F2")
                });

            string jsonResult = JsonConvert
                .SerializeObject(saleExportDto, Formatting.Indented);

            return jsonResult;
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults
                = new List<ValidationResult>();

            return Validator
                .TryValidateObject(obj, validationContext, validationResults);
        }
    }
}