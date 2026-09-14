

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations = {180,240,180,240,180};

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Part 2 — Display All Sessions");
            Console.WriteLine("_______________________________________________");

            DisplayAllSessions(sessionNames, sessionDates, sessionDurations);

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Part 3 — Search for a Session");
            Console.WriteLine("_______________________________________________");

            Console.WriteLine("Enter Session Name To Search For ...");
            string? sessionName = Console.ReadLine();

            Console.WriteLine(FindSessionByName(sessionNames, sessionDates, sessionDurations, sessionName));
            Console.WriteLine($"Session index is {FindSessionIndex(sessionNames, sessionName)}");

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("Part 4 — Array Methods Practice");
            Console.WriteLine("_______________________________________________");

            Console.WriteLine("Sorted Session Names : _________________________________");
            foreach (var session in SortSessionNames(sessionNames))
            {
                Console.WriteLine(session);
            }

            Console.WriteLine("\nReversed Session Names : _________________________________");
            foreach (var session in ReverseSessionNames(sessionNames))
            {
                Console.WriteLine(session);
            }

            Console.WriteLine("\nCheck if a Session Exists:________________________");
            Console.Write(IsSessionExists(sessionNames, "c# basics"));

            Console.WriteLine("\nFind Session Based On Condition:________________________");
            Console.WriteLine(FindSessionBasedOnCondition(sessionNames, sessionName => sessionName.StartsWith('E')));

            Console.WriteLine("\nFind Session Index Based On Condition:________________________");
            Console.WriteLine(FindSessionIndexBasedOnCondition(sessionNames, sessionName => sessionName.StartsWith('A')));

            var copiedArray = CopyArray(sessionNames);
            Console.WriteLine("Original Session Array : _________________________________");
            foreach( var session in sessionNames)
            {
                Console.WriteLine(session);
            }
            Console.WriteLine("\nCopied Session Array : _________________________________");
            foreach (var session in copiedArray)
            {
                Console.WriteLine(session);
            }

            Console.ReadKey();
        }

        public static string[] DisplayAllSessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            for(int i = 0; i < sessionNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sessionNames[i]}\nDate: {sessionDates[i].ToString("dd MMMM yyy")}\nStart Time: {sessionDates[i].ToString("hh:mm tt")}\nDuration: {sessionDurations[i]} minutes\n");
            }
            return sessionNames;
        }

        public static string FindSessionByName(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, string? name)
        {
            if(name is null)
            {
                return "Cann't find a Session With Empty Name.";
            }
            int index = Array.FindIndex(sessionNames, sessionName => string.Equals(sessionName, name, StringComparison.OrdinalIgnoreCase));
            
            if(index != -1)
            {
                return $"{sessionNames[index]}\nDate: {sessionDates[index].ToString("dd MMMM yyy")}\nStart Time: {sessionDates[index].ToString("hh:mm tt")}\nDuration: {sessionDurations[index]} minutes\n";
            }
            return "Session not found.";
        }

        public static string[] SortSessionNames(string[] sessionNames)
        {
            var newarray = new string[sessionNames.Length];
            Array.Copy(sessionNames, newarray, sessionNames.Length);
            Array.Sort(newarray);
            return newarray;
        }

        public static string[] ReverseSessionNames(string[] sessionNames)
        {
            var reverseSessionNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, reverseSessionNames , sessionNames.Length);
            Array.Reverse(reverseSessionNames);
            return reverseSessionNames;
        }

        public static int FindSessionIndex(string[] sessionNames , string? name)
        {
            if(name is null)
            {
                return -1;
            }

            int index = Array.IndexOf(sessionNames , name);

            return index;
        }

        public static string IsSessionExists(string[] sessionNames, string? name)
        {
            if(name is null || !(Array.Exists(sessionNames, sessionName => string.Equals(sessionName, name, StringComparison.OrdinalIgnoreCase))))
            {
                return "Session does not exist.";
            }

            return "Session exists.";
        }

        public static string? FindSessionBasedOnCondition(string[] sesisonNames, Predicate<string>? predicate = null)
        {
            if (predicate is null) return "No condition provided.";
            return
                Array.Find(sesisonNames, predicate) ?? "No session matches your condition.";
        }

        public static int FindSessionIndexBasedOnCondition(string[] sesisonNames, Predicate<string>? predicate = null)
        {
            if (predicate is null ) return -1;

            return
                Array.FindIndex(sesisonNames, predicate);
        }

        public static string[] CopyArray(string[] sessionNames)
        {
            var copiedArray = new string[sessionNames.Length];
            Array.Copy(sessionNames, copiedArray, sessionNames.Length);
            copiedArray[0] = "Asp.Net Basics";
            return copiedArray;
        }
    }
}
