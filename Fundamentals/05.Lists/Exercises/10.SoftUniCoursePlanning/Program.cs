class Program
{
    static void Main()
    {
        List<string> schedule = Console.ReadLine()
            .Split(", ")
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "course start")
        {
            string[] arguments = command.Split(":");

            string action = arguments[0];

            string lessonTitle;
            int index = 0;
            string exerciseTitle;
            switch (action)
            {
                case "Add":
                    lessonTitle = arguments[1];

                    if (schedule.Contains(lessonTitle))
                    {
                        continue;
                    }
                    else
                    {
                        schedule.Add(lessonTitle);
                    }
                    break;
                case "Insert":
                    lessonTitle = arguments[1];
                    index = int.Parse(arguments[2]);
                    if (schedule.Contains(lessonTitle))
                    {
                        continue;
                    }
                    else
                    {
                        schedule.Insert(index, lessonTitle);
                    }
                    break;
                case "Remove":
                    lessonTitle = arguments[1];
                    if (schedule.Contains(lessonTitle))
                    {
                        schedule.Remove(lessonTitle);
                    }

                    exerciseTitle = $"{lessonTitle}-Exercise";
                    index = schedule.FindIndex(x => x == exerciseTitle);
                    if (index >= 0)
                    {
                        schedule.Remove(exerciseTitle);
                    }

                    break;
                case "Swap":
                    lessonTitle = arguments[1];
                    string secondLesson = arguments[2];

                    if (schedule.Contains(lessonTitle) && schedule.Contains(secondLesson))
                    {
                        int firstIndex = schedule.IndexOf(lessonTitle);
                        int secondIndex = schedule.IndexOf(secondLesson);

                        string copyFirstString = schedule[firstIndex];
                        schedule[firstIndex] = schedule[secondIndex];
                        schedule[secondIndex] = copyFirstString;


                        exerciseTitle = $"{lessonTitle}-Exercise";

                        index = schedule.FindIndex(x => x == exerciseTitle);
                        
                        index = schedule.FindIndex(x => x == secondLesson);
                        string nameLesson = schedule[index];
                        

                        if (index >= 0 && nameLesson == lessonTitle)
                        {
                            schedule.RemoveAt(index);
                            schedule.Insert(index + 1, exerciseTitle);
                        }
                        if (index >= 0 && nameLesson == secondLesson)
                        {
                            schedule.RemoveAt(index);
                            schedule.Insert(index + 1, secondLesson);
                        }
                    }
                    else
                    {
                        continue;
                    }
                    break;
                case "Exercise":
                    lessonTitle = arguments[1];
                    exerciseTitle = $"{lessonTitle}-Exercise";
                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }

                    if (schedule.Contains(lessonTitle) && !schedule.Contains(exerciseTitle))
                    {
                        index = schedule.FindIndex(x => x == lessonTitle);
                        schedule.Insert(index + 1, exerciseTitle );
                    }

                    break;
                
            }
        }

        
        for (int i = 0; i < schedule.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{schedule[i]}");
        }

    }
}

