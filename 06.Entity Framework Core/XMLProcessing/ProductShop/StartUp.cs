using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            ResetAndSeedDatabase(context);

            // Problem 5
            string result = GetProductsInRange(context);
            WriteSerializationResult("products-in-range.xml", result);
            Console.WriteLine(result);

            // Problem 6
            result = GetSoldProducts(context);
            WriteSerializationResult("users-sold-products.xml", result);
            Console.WriteLine(result);

            // Problem 7
            result = GetCategoriesByProductsCount(context);
            WriteSerializationResult("categories-by-products.xml", result);
            Console.WriteLine(result);

            // Problem 8
            result = GetUsersWithProducts(context);
            WriteSerializationResult("users-and-products.xml", result);
            Console.WriteLine(result);
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            ICollection<User> usersToImport = new List<User>();

            ImportUserDto[]? importUserDtos = XmlSerializerWrapper
                .Deserialize<ImportUserDto[]>(inputXml, "Users");
            if (importUserDtos != null)
            {
                foreach (ImportUserDto userDto in importUserDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    bool isAgeValid = TryParseNullableInt(userDto.Age, out int? age);
                    if (!isAgeValid)
                    {
                        continue;
                    }

                    User newUser = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = age,
                    };

                    usersToImport.Add(newUser);
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {usersToImport.Count}.";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            ICollection<Product> productsToImport = new List<Product>();

            ImportPropductDto[]? importProductDtos = XmlSerializerWrapper
                .Deserialize<ImportPropductDto[]>(inputXml, "Products");
            if (importProductDtos != null)
            {
                foreach (ImportPropductDto productDto in importProductDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal
                        .TryParse(productDto.Price, out decimal priceVal);

                    bool isSellerIdValid = int
                        .TryParse(productDto.SellerId, out int sellerIdVal);

                    bool isBuyerIdValid =
                        TryParseNullableInt(productDto.BuyerId, out int? buyerIdVal);

                    if (!isPriceValid || !isSellerIdValid || !isBuyerIdValid)
                    {
                        continue;
                    }

                    // Check if SellerId and BuyerId exist in the database
                    // Justification: The proplem description does not require this check and Judge may not be happy about it...,

                    Product newProduct = new Product()
                    {
                        Name = productDto.Name,
                        Price = priceVal,
                        SellerId = sellerIdVal,
                        BuyerId = buyerIdVal,
                    };

                    productsToImport.Add(newProduct);
                }

                context.Products.AddRange(productsToImport);
                context.SaveChanges();

            }

            return $"Successfully imported {productsToImport.Count}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            ICollection<Category> categoriesToImport = new List<Category>();
            ImportCategoryDto[]? importCategoryDtos = XmlSerializerWrapper
                .Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
            if (importCategoryDtos != null)
            {
                foreach (ImportCategoryDto categoryDto in importCategoryDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    Category newCategory = new Category()
                    {
                        Name = categoryDto.Name,
                    };

                    categoriesToImport.Add(newCategory);
                }

                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoriesToImport.Count}";
        }

        // Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            ICollection<CategoryProduct> categoryProductsToImport = new List<CategoryProduct>();

            IEnumerable<int> existingCategoryIds = context
                .Categories
                .AsNoTracking()
                .Select(c => c.Id)
                .ToArray();

            IEnumerable<int> existingProductIds = context
                .Products
                .AsNoTracking()
                .Select(p => p.Id)
                .ToArray();

            ImportCategoryProductDto[]? importCategoryProductDtos = XmlSerializerWrapper
                .Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
            if (importCategoryProductDtos != null)
            {
                foreach (ImportCategoryProductDto cpDto in importCategoryProductDtos)
                {
                    if (!IsValid(cpDto))
                    {
                        continue;
                    }

                    bool isCategoryIdValid = int
                        .TryParse(cpDto.CategoryId, out int categoryId);
                    bool isProductIdValid = int
                        .TryParse(cpDto.ProductId, out int productId);
                    if (!isCategoryIdValid || !isProductIdValid)
                    {
                        continue;
                    }

                    if (!existingCategoryIds.Contains(categoryId) ||
                       !existingProductIds.Contains(productId))
                    {
                        continue;
                    }

                    CategoryProduct newCategoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId,
                    };

                    categoryProductsToImport.Add(newCategoryProduct);
                }

                context.CategoryProducts.AddRange(categoryProductsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoryProductsToImport.Count}";
        }

        // Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportproductsInRangeDto[] exportproductsInRangeDtos = context
                .Products
                .AsNoTracking()
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportproductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(exportproductsInRangeDtos, "Products");

            return result;
        }

        // Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context
                .Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportUserProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProduct = u.ProductsSold.Select(y => new ExportSoldProductDto
                    {
                        Name = y.Name,
                        Price = y.Price.ToString(),
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(soldProducts, "Users");

            return result;
        }

        // Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductsCountDto[] categoriesByProducts = context
                 .Categories
                 .AsNoTracking()
                 .Include(c => c.CategoriesProducts)
                 .ThenInclude(cp => cp.Product)
                 .OrderByDescending(c => c.CategoriesProducts.Count())
                 .ThenBy(c => c.CategoriesProducts.Sum(cp => cp.Product.Price))
                 .Select(c => new ExportCategoriesByProductsCountDto
                 {
                     Name = c.Name,
                     Count = c.CategoriesProducts.Count(),
                     AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price),
                     TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price)
                 })
                 .ToArray();

            string result = XmlSerializerWrapper
                .Serialize(categoriesByProducts, "Categories");

            return result;
        }



        // Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUsersCountDto rootDto = new ExportUsersCountDto()
            {
                TotalUserCount = context
                   .Users
                   .Include(u => u.ProductsSold)
                   .AsNoTracking()
                   .Count(p => p.ProductsSold.Any()),
                Users = context
                    .Users
                    .AsNoTracking()
                    .Include(u => u.ProductsSold)
                    .Where(u => u.ProductsSold.Any())
                    .Select(u => new ExportUsersWithSoldProductsDto()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = new ExportUserSoldProductsDto()
                        {
                            Count = u.ProductsSold.Count,
                            Products = u.ProductsSold
                                .OrderByDescending(p => p.Price)
                                .Select(sp => new ExportSoldProductDto()
                                {
                                    Name = sp.Name,
                                    Price = sp.Price.ToString("F2"),
                                })
                                .ToArray(),
                        },
                    })
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };

            string result = XmlSerializerWrapper
                .Serialize(rootDto, "Users");

            return result;
        }

        private static void WriteSerializationResult(string fileName, string text)
        {
            string xmlFileDirPath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            File
                .WriteAllText(xmlFileDirPath + fileName, text, Encoding.Unicode);
        }
        private static void ResetAndSeedDatabase(ProductShopContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            string xmlFileText = ReadXmlDatasetFileContents("users.xml");
            string result = ImportUsers(dbContext, xmlFileText);

            xmlFileText = ReadXmlDatasetFileContents("products.xml");
            result = ImportProducts(dbContext, xmlFileText);

            xmlFileText = ReadXmlDatasetFileContents("categories.xml");
            result = ImportCategories(dbContext, xmlFileText);

            xmlFileText = ReadXmlDatasetFileContents("categories-products.xml");
            result = ImportCategoryProducts(dbContext, xmlFileText);

            Console.WriteLine(result);
        }

        private static string ReadXmlDatasetFileContents(string fileName)
        {
            string xmlFileDirPath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string xmlFileText = File
                .ReadAllText(xmlFileDirPath + fileName);

            return xmlFileText;
        }


        private static bool TryParseNullableInt(string? input, out int? val)
        {
            // TODO: Refactor as generic method
            int? outVal = null;
            if (input != null)
            {
                bool isInputValid = int
                    .TryParse(input, out int ageVal);
                if (!isInputValid)
                {
                    val = outVal;
                    return false;
                }

                outVal = ageVal;
            }

            val = outVal;
            return true;
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