using System.Reflection.Metadata.Ecma335;

namespace _02.Articles
{
    internal class Program
    {
        static void Main()
        {
            string[] articleArguments = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = articleArguments[0];
            string content = articleArguments[1];
            string author = articleArguments[2];

            Article article = new Article(title, content, author);

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;
                    case "Rename":
                        article.Rename(command[1]);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
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

            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }
        }
    }
}
