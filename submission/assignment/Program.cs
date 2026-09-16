

using System.Globalization;

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

            int[] sessionDurations = { 180, 240, 180, 240, 180 };

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 2 — Display All Sessions");
            //Console.WriteLine("_______________________________________________");

            //DisplayAllSessions(sessionNames, sessionDates, sessionDurations);

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 3 — Search for a Session");
            //Console.WriteLine("_______________________________________________");

            //Console.WriteLine("Enter Session Name To Search For ...");
            //string? sessionName = Console.ReadLine();

            //Console.WriteLine(FindSessionByName(sessionNames, sessionDates, sessionDurations, sessionName));
            //Console.WriteLine($"Session index is {FindSessionIndex(sessionNames, sessionName)}");

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 4 — Array Methods Practice");
            //Console.WriteLine("_______________________________________________");

            //Console.WriteLine("Sorted Session Names : _________________________________");
            //foreach (var session in SortSessionNames(sessionNames))
            //{
            //    Console.WriteLine(session);
            //}

            //Console.WriteLine("\nReversed Session Names : _________________________________");
            //foreach (var session in ReverseSessionNames(sessionNames))
            //{
            //    Console.WriteLine(session);
            //}

            //Console.WriteLine("\nCheck if a Session Exists:________________________");
            //Console.Write(IsSessionExists(sessionNames, "c# basics"));

            //Console.WriteLine("\nFind Session Based On Condition:________________________");
            //Console.WriteLine(FindSessionBasedOnCondition(sessionNames, sessionName => sessionName.StartsWith('E')));

            //Console.WriteLine("\nFind Session Index Based On Condition:________________________");
            //Console.WriteLine(FindSessionIndexBasedOnCondition(sessionNames, sessionName => sessionName.StartsWith('A')));

            //var copiedArray = CopyArray(sessionNames);
            //Console.WriteLine("Original Session Array : _________________________________");
            //foreach( var session in sessionNames)
            //{
            //    Console.WriteLine(session);
            //}
            //Console.WriteLine("\nCopied Session Array : _________________________________");
            //foreach (var session in copiedArray)
            //{
            //    Console.WriteLine(session);
            //}

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 5 — Duration Analysis");
            //Console.WriteLine("_______________________________________________\n");
            //var result = AnalyseSessionDurations(sessionDurations);
            //Console.WriteLine(result.durationAnalysis);
            //foreach(var duration in result.copiedSessionDuration)
            //{
            //    Console.WriteLine(duration);
            //}

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 7 — ref, out, and Reference-Type Parameter");
            //Console.WriteLine("_______________________________________________\n");
            //int x = 5;
            //Console.WriteLine($"x Before Calling ref Method {x}");
            //ExplainRef(ref x);
            //Console.WriteLine($"x After Calling ref Method {x}");

            //ExplainOut(sessionNames, sessionDurations, "arrays", out int index, out int duration);
            //Console.WriteLine($"Out index : {index}");
            //Console.WriteLine($"Out duration : {duration}");

            //Console.WriteLine($"First Elemet Before Change Without Ref {sessionDurations[0]}");
            //Console.WriteLine($"First Elemet After Change Without Ref {ChangeFirstElementWithoutRef(sessionDurations)}");

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 8 — params Keyword");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine($"total of durations using Params Keyword : {CalculateTotalDurationUsingParams(sessionDurations)}");

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 9 — Session Date Details");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine(GetSessionDateDetails(sessionNames, "arrays", sessionDates, sessionDurations));

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 10 — Date Difference");
            //Console.WriteLine("_______________________________________________\n");

            //var interval = GetDateDifference(sessionNames, sessionDates, "c# basics", "arrays");
            //Console.WriteLine(interval.hoursInterval);
            //Console.WriteLine(interval.daysInterval);

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 11 — Past and Upcoming Sessions");
            //Console.WriteLine("_______________________________________________\n");

            //foreach(var session in DetectPastOrUpcomingSession(sessionNames, sessionDates))
            //{
            //Console.WriteLine(session);
            //}

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 12 — Find the Next Session");
            //Console.WriteLine("_______________________________________________\n");

            //GetTheNextSession(sessionNames, sessionDates);

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 13 — Date Formatting");
            //Console.WriteLine("_______________________________________________\n");

            //FormatSessionDateTime(sessionNames, "arrays", sessionDates);

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 14 — Read and Validate a Date");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine(ReadAndValidateDate());

            Console.ReadKey();
        }

        public static string[] DisplayAllSessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            for (int i = 0; i < sessionNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sessionNames[i]}\nDate: {sessionDates[i].ToString("dd MMMM yyy")}\nStart Time: {sessionDates[i].ToString("hh:mm tt")}\nDuration: {sessionDurations[i]} minutes\n");
            }
            return sessionNames;
        }

        public static string FindSessionByName(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations, string? name)
        {
            if (name is null)
            {
                return "Cann't find a Session With Empty Name.";
            }
            int index = Array.FindIndex(sessionNames, sessionName => string.Equals(sessionName, name, StringComparison.OrdinalIgnoreCase));

            if (index != -1)
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
            Array.Copy(sessionNames, reverseSessionNames, sessionNames.Length);
            Array.Reverse(reverseSessionNames);
            return reverseSessionNames;
        }

        public static int FindSessionIndex(string[] sessionNames, string? name)
        {
            if (name is null)
            {
                return -1;
            }

            int index = Array.IndexOf(sessionNames, name);

            return index;
        }

        public static string IsSessionExists(string[] sessionNames, string? name)
        {
            if (name is null || !(Array.Exists(sessionNames, sessionName => string.Equals(sessionName, name, StringComparison.OrdinalIgnoreCase))))
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
            if (predicate is null) return -1;

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

        public static (string durationAnalysis, int[] copiedSessionDuration) AnalyseSessionDurations(int[] sessionDurations)
        {
            var copiedArray = new int[sessionDurations.Length];
            Array.Copy(sessionDurations, copiedArray, sessionDurations.Length);
            Array.Sort(copiedArray);
            int sum = 0;
            int average = 0;
            int shortestDuration = copiedArray[0];
            int logestDuration = copiedArray[copiedArray.Length - 1];
            foreach (var duration in copiedArray)
            {
                sum += duration;
            }
            average = sum / copiedArray.Length;

            var analysis = $"Total Duration: {sum}\nAverage Duration : {average}\nShortest Duration : {shortestDuration}\nLongest Duration: {logestDuration}";

            return (analysis, copiedArray);
        }

        public static int ExplainRef(ref int x)
        {
            x = 6;
            return x;
        }

        public static void ExplainOut(string[] sessionNames, int[] sessionDurationArray, string name, out int sessionIndex, out int sessionDuration)
        {
            sessionIndex = Array.FindIndex(sessionNames, sessionName => sessionName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (sessionIndex == -1)
            {
                Console.WriteLine("Session Not Found");
                sessionDuration = 0;
                return;
            }

            sessionDuration = sessionDurationArray[sessionIndex];
        }

        public static int ChangeFirstElementWithoutRef(int[] sessionDuration)
        {
            sessionDuration[0] = 50;

            return sessionDuration[0];
        }

        public static int CalculateTotalDurationUsingParams(params int[] durations)
        {
            int sum = 0;

            foreach (var duration in durations)
            {
                sum += duration;
            }
            return sum;
        }

        public static string GetSessionDateDetails(string[] sessionNames, string name, DateTime[] sessionDates, int[] sessionDurations)
        {
            if (name is null)
            {
                return "Can't find a Session With Empty Name.";
            }

            int index = Array.FindIndex(sessionNames,
                sessionName => string.Equals(
                    sessionName,
                    name,
                    StringComparison.OrdinalIgnoreCase));

            if (index != -1)
            {
                return $"Date: {sessionDates[index]:dd MMMM yyyy}\n" +
                       $"Day: {sessionDates[index].DayOfWeek}\n" +
                       $"Year : {sessionDates[index].Year}\n" +
                       $"Month: {sessionDates[index].Month}\n" +
                       $"Day Number: {sessionDates[index].Day}\n" +
                       $"Start Time: {sessionDates[index].ToString("t")}\n" +
                       $"Duration: {sessionDurations[index]} minutes\n" +
                       $"End Time: {sessionDates[index].AddMinutes(sessionDurations[index]).ToString("t")}\n";
            }

            return "Session not found.";
        }

        public static (int hoursInterval, int daysInterval)
            GetDateDifference(string[] sessionNames, DateTime[] sessionDates, string sessionName1, string sessionName2)
        {
            if (sessionName1 is null || sessionName2 is null)
            {
                Console.WriteLine("Can't find a Session With Empty Name.");
                return (0, 0);
            }

            int index1 = Array.FindIndex(sessionNames,
                sessionName => string.Equals(
                    sessionName,
                    sessionName1,
                    StringComparison.OrdinalIgnoreCase));

            int index2 = Array.FindIndex(sessionNames,
                sessionName => string.Equals(
                    sessionName,
                    sessionName2,
                    StringComparison.OrdinalIgnoreCase));

            if(index1 == -1 || index2 == -1)
            {
                Console.WriteLine("At least One Session Not Found.");
                return (0,0);
            }

            var hoursInterval = (sessionDates[index2] - sessionDates[index1]).Days;
            var daysinterval = (sessionDates[index2] - sessionDates[index1]).Hours;

            return (hoursInterval, daysinterval);
        }

        public static string[] DetectPastOrUpcomingSession(string[] sessionNames, DateTime[] sessionDates)
        {
            var result = new string[sessionNames.Length];
            Array.Copy(sessionNames, result, sessionNames.Length);

            for (int i = 0;i < sessionDates.Length; i++)
            {
                if (sessionDates[i] < DateTime.Now)
                {
                    result[i] += " - past";
                }
                else
                {
                    result[i] += " - Upcoming";
                }
            }

            return result;
        }

        public static void GetTheNextSession(string[] sessionNames, DateTime[] sessionDates)
        {
            for(int i = 0; i < sessionDates.Length; i++)
            {
                if (sessionDates[i] > DateTime.Now)
                {
                    var daysInterval = (sessionDates[i] - DateTime.Now).Days;
                    var hoursInterval = (sessionDates[i] - DateTime.Now).Hours;
                    Console.WriteLine(
                        $"{sessionNames[i]}\n{sessionDates[i].ToString("dd MMMM yyyy")}\n{sessionDates[i].ToString("t")}\n" +
                        $"\nTime Remaining:\n{daysInterval} Days\n{hoursInterval} Hours"
                        );
                    break;
                }
            }
        }

        public static void FormatSessionDateTime(string[] sesssionNames, string name, DateTime[] sessionDates)
        {
            var index = CheckSessionExists(sesssionNames, name);

            if(index != -1)
            {
                Console.WriteLine(
                    $"{sessionDates[index].ToString("yyyy-MM-d")}\n" +
                    $"{sessionDates[index].ToString("d/MM/yyyy")}\n" +
                    $"{sessionDates[index].ToString("d MMMM yyyy")}\n" +
                    $"{sessionDates[index].ToString("dddd,d MMMM yyyy")}\n" +
                    $"{sessionDates[index].ToString("t")}"
                    );
            }
            else
            {
                Console.WriteLine("NO Session Found");
            }
        }

        public static string ReadAndValidateDate()
        {
            DateTime result;
            bool isSucceeded;

            do
            {
                Console.WriteLine(
                    "Please enter date in this format: yyyy-MM-dd HH:mm\n" +
                    "For example: 2026-10-15 18:30");

                var input = Console.ReadLine();

                isSucceeded = DateTime.TryParseExact(
                    input,
                    "yyyy-MM-dd HH:mm",
                    null,
                    DateTimeStyles.None,
                    out result);

                if (!isSucceeded)
                {
                    Console.WriteLine("Invalid Input. Please try again.");
                }

            } while (!isSucceeded);

            return result.ToString();
        }

        private static int CheckSessionExists(string[] sessionNames, string name)
        {
            if (name is null)
            {
                return -1;
            }

            return Array.FindIndex(sessionNames,
                sessionName => string.Equals(
                    sessionName,
                    name,
                    StringComparison.OrdinalIgnoreCase));
        }
    } 
}
