namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string? command = Console.ReadLine();
            //if (command != null)
            //{
            //    string result = GetBooksByAgeRestriction(db, command);
            //    Console.WriteLine(result);
            //}

            //string goldenBooks = GetGoldenBooks(db);
            //Console.WriteLine(goldenBooks);

            //string booksByPrice = GetBooksByPrice(db);
            //Console.WriteLine(booksByPrice);

            //int year = int.Parse(Console.ReadLine()!);
            //string booksNotReleasedIn = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(booksNotReleasedIn);

            //string? input = Console.ReadLine();
            //if (input != null)
            //{
            //    string booksByCategory = GetBooksByCategory(db, input);
            //    Console.WriteLine(booksByCategory);
            //}

            //string? date = Console.ReadLine();
            //if (date != null)
            //{
            //    string booksReleasedBefore = GetBooksReleasedBefore(db, date);
            //    Console.WriteLine(booksReleasedBefore);
            //}

            //string? end = Console.ReadLine();
            //if (end != null)
            //{
            //    string authorNamesEndingIn = GetAuthorNamesEndingIn(db, end);
            //    Console.WriteLine(authorNamesEndingIn);
            //}

            //string? text = Console.ReadLine();
            //if (text != null)
            //{
            //    string bookTitlesContaining = GetBookTitlesContaining(db, text);
            //    Console.WriteLine(bookTitlesContaining);
            //}

            //string? input = Console.ReadLine();
            //if (input != null)
            //{
            //    string booksByAuthor = GetBooksByAuthor(db, input);
            //    Console.WriteLine(booksByAuthor);
            //}

            //// Problem 11
            //int lengthCheck = int.Parse(Console.ReadLine()!);
            //int booksCount = CountBooks(db, lengthCheck);
            //Console.WriteLine(booksCount);

            //// Problem 12
            //string authorsCopies = CountCopiesByAuthor(db);
            //Console.WriteLine(authorsCopies);

            //// Problem 13
            //string totalProfitByCategory = GetTotalProfitByCategory(db);
            //Console.WriteLine(totalProfitByCategory);

            // Problem 14
            //Console.WriteLine(GetMostRecentBooks(db));
            // Problem 15
            //IncreasePrices(db);

            // Problem 16
            int removedBooks = RemoveBooks(db);
            Console.WriteLine(removedBooks);
        }

        // Problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            bool isCommandValid = Enum.TryParse(command, true, out AgeRestriction ageRestriction);
            if (isCommandValid)
            {
                IEnumerable<string> bookTitles = context
                    .Books
                    .OrderBy(b => b.Title)
                    .AsNoTracking()
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(b => b.Title)
                    .ToArray();
                foreach (string title in bookTitles)
                {
                    sb.AppendLine(title);
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            int copies = 5000;
            IEnumerable<string> books = context
                .Books
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Where(b => b.Copies < copies && b.EditionType == EditionType.Gold)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByPrice = context
                .Books
                .AsNoTracking()
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Price,
                    b.Title
                })
                .Where(b => b.Price > 40)
                .ToArray();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> booksNotReleasedInYear = context
                .Books
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in booksNotReleasedInYear)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] category = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLowerInvariant())
                .ToArray();
            if (category.Any())
            {
                IEnumerable<string> bookTitlesByCatogory = context
                    .Books
                    .AsNoTracking()
                    .Where(b => b.BookCategories
                        .Select(bc => bc.Category)
                        .Any(c => category.Contains(c.Name.ToLower())))
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                foreach (var book in bookTitlesByCatogory)
                {
                    sb.AppendLine(book);
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime parcedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var booksReleasedBefore = context
                .Books
                .OrderByDescending(b => b.ReleaseDate)
                .AsNoTracking()
                .Where(b => b.ReleaseDate < parcedDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authorsNames = context
                .Authors
                .AsNoTracking()
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Where(a => a.FirstName != null &&
                            a.FirstName!.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .ToArray();

            foreach (var author in authorsNames)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context
                .Books
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .ToArray();
            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksByAuthor = context
                .Books
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToArray();

            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            var booksCount = context
                .Books
                .AsNoTracking()
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorsCopies = context
                .Authors
                .AsNoTracking()
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();

            foreach (var author in authorsCopies)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var profitByCategory = context
                .Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .AsNoTracking()
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                        .Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToArray();

            foreach (var category in profitByCategory)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    MostRecentBooks = c.CategoryBooks
                       .Select(cb => new
                       {
                           cb.Book.Title,
                           cb.Book.ReleaseDate,
                       })
                       .OrderByDescending(b => b.ReleaseDate)
                       .Take(3)
                       .ToArray()
                })
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate!.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> booksToUpdate = context
                .Books
                .Where(b => b.ReleaseDate != null &&
                            b.ReleaseDate!.Value.Year < 2010);

            foreach (Book book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200);

            int removedBooksCount = booksToRemove.Count();
            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return removedBooksCount;
        }
    }
}


