using System.Reflection.Metadata.Ecma335;

namespace _02.Articles
{
    internal class Program
    {
        static void Main()
        {
            int countOfCommands = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = command[0];
                string content = command[1];
                string author = command[2];

                Article article = new Article(title, content, author);
                articles.Add(article);

            }

            Console.WriteLine(string.Join("\n", articles));
        }

        class Article
        {
            private string Title { get; set; }
            private string Content { get; set; }
            private string Author { get; set; }
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
