using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string jsonFileDirPath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string usersJsonFileName = "users.json";
            string productsJsonFileName = "products.json";
            string categoriesJsonFileName = "categories.json";
            string categoryProductsJsonFileName = "categories-products.json";

            string jsonFileText = File
                .ReadAllText(jsonFileDirPath + productsJsonFileName);

            // Problem 1
            string importedUseres = ImportUsers(context, jsonFileText);
            Console.WriteLine(importedUseres);

            // Problem 2
            string importedProducts = ImportProducts(context, jsonFileText);
            Console.WriteLine(importedProducts);

            // Problem 3
            string importedCategories = ImportCategories(context, jsonFileText);
            Console.WriteLine(importedCategories);

            // Problem 4
            string importedCategoryProducts = ImportCategoryProducts(context, jsonFileText);
            Console.WriteLine(importedCategoryProducts);

            // Problem 5
            string productsInRangeJson = GetProductsInRange(context);
            Console.WriteLine(productsInRangeJson);

            // Problem 6
            string usersWithSoldProductsJson = GetSoldProducts(context);
            Console.WriteLine(usersWithSoldProductsJson);

            // Problem 7
            string categoriesByProductsCountJson = GetCategoriesByProductsCount(context);
            Console.WriteLine(categoriesByProductsCountJson);

            // Problem 8
            string usersAndProductsJson = GetUsersWithProducts(context);
            Console.WriteLine(usersAndProductsJson);
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ICollection<User> usersToImport = new List<User>();

            IEnumerable<ImportUserDto>? usersDto = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);
            if (usersDto != null)
            {
                foreach (ImportUserDto userDto in usersDto)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    bool isAgeValid = string.IsNullOrEmpty(userDto.Age) ||
                                      int.TryParse(userDto.Age, out int validAge);
                    if (isAgeValid)
                    {
                        User user = new User()
                        {
                            FirstName = userDto.FirstName,
                            LastName = userDto.LastName,
                            Age = userDto.Age != null ? int.Parse(userDto.Age) : null
                        };

                        usersToImport.Add(user);
                    }
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {usersToImport.Count}";
        }

        // Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ICollection<Product> productsToImport = new List<Product>();

            IEnumerable<ImportProductDto>? productsDto = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);


            if (productsDto != null)
            {
                foreach (ImportProductDto productDto in productsDto)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(productDto.Price, out decimal validPrice);
                    bool isSellerIdValid = int.TryParse(productDto.SellerId, out int validSellerId);

                    if (!isPriceValid || !isSellerIdValid)
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if (!string.IsNullOrWhiteSpace(productDto.BuyerId))
                    {
                        bool isBuyerIdValid = int
                            .TryParse(productDto.BuyerId, out int validBuyerId);
                        if (!isBuyerIdValid)
                        {
                            continue;
                        }

                        buyerId = validBuyerId;
                    }


                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = validPrice,
                        SellerId = validSellerId,
                        BuyerId = productDto.BuyerId != null ? int.Parse(productDto.BuyerId) : null
                    };

                    productsToImport.Add(product);
                }

                context.Products.AddRange(productsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {productsToImport.Count}";
        }

        // Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ICollection<Category> categoriesToImport = new List<Category>();

            IEnumerable<ImportCategoryDto>? categoriesDto = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);
            if (categoriesDto != null)
            {
                foreach (ImportCategoryDto categoryDto in categoriesDto)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }

                    Category category = new Category()
                    {
                        Name = categoryDto.Name
                    };

                    categoriesToImport.Add(category);
                }

                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoriesToImport.Count}";
        }

        // Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ICollection<CategoryProduct> categoryProductsToImport = new List<CategoryProduct>();

            IEnumerable<ImportCategoryProductDto>? categoryProductsDto = JsonConvert
                .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            if (categoryProductsDto != null)
            {
                foreach (ImportCategoryProductDto categoryProductDto in categoryProductsDto)
                {
                    if (!IsValid(categoryProductDto))
                    {
                        continue;
                    }

                    bool isCategoryIdValid = int
                        .TryParse(categoryProductDto.CategoryId, out int validCategoryId);

                    bool isProductIdValid = int
                        .TryParse(categoryProductDto.ProductId, out int validProductId);

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = validCategoryId,
                        ProductId = validProductId
                    };

                    categoryProductsToImport.Add(categoryProduct);
                }

                context.CategoriesProducts.AddRange(categoryProductsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoryProductsToImport.Count}";
        }

        // Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToArray();

            string productsInRangeJson = JsonConvert
                .SerializeObject(productsInRange, Formatting.Indented);

            return productsInRangeJson;
        }

        // Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer!.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            string usersWithSoldProductsJson = JsonConvert
                .SerializeObject(usersWithSoldProducts, Formatting.Indented);

            return usersWithSoldProductsJson;
        }

        // Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts
                        .Average(cp => cp.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoriesProducts
                        .Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            string categoriesByProductsCountJson = JsonConvert
                .SerializeObject(categoriesByProductsCount, Formatting.Indented);

            return categoriesByProductsCountJson;
        }

        // Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
               .Users
               .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
               .Select(u => new
               {
                   u.FirstName,
                   u.LastName,
                   u.Age,
                   SoldProducts = new
                   {
                       Count = u.ProductsSold
                           .Count(p => p.BuyerId.HasValue),
                       Products = u.ProductsSold
                           .Where(p => p.BuyerId.HasValue)
                           .Select(p => new
                           {
                               p.Name,
                               p.Price
                           })
                           .ToArray()
                   }
               })
               .ToArray()
               .OrderByDescending(u => u.SoldProducts.Count)
               .ToArray();

            var usersDto = new
            {
                UsersCount = usersWithSoldProducts.Length,
                Users = usersWithSoldProducts
            };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            string jsonResult = JsonConvert
                .SerializeObject(usersDto, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver,
                NullValueHandling = NullValueHandling.Ignore
            });

            return jsonResult;
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