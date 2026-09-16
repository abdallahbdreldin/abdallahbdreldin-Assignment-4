using System.Globalization;
using System.Text;
using BenchmarkDotNet.Running;

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

            int choice;

            do
            {
                Console.WriteLine("\n========== Session Management ==========");
                Console.WriteLine("1. Display All Sessions");
                Console.WriteLine("2. Search for a Session");
                Console.WriteLine("3. Sort Session Names");
                Console.WriteLine("4. Reverse Session Names");
                Console.WriteLine("5. Check if Session Exists");
                Console.WriteLine("6. Find Session Based on Condition");
                Console.WriteLine("7. Find Session Index Based on Condition");
                Console.WriteLine("8. Copy Session Array");
                Console.WriteLine("9. Analyse Session Durations");
                Console.WriteLine("10. Explain ref");
                Console.WriteLine("11. Explain out");
                Console.WriteLine("12. Calculate Total Duration using params");
                Console.WriteLine("13. Get Session Date Details");
                Console.WriteLine("14. Get Date Difference");
                Console.WriteLine("15. Detect Past/Upcoming Sessions");
                Console.WriteLine("16. Find Next Session");
                Console.WriteLine("17. Format Session DateTime");
                Console.WriteLine("18. Read and Validate Date");
                Console.WriteLine("19. Parse Integer");
                Console.WriteLine("20. Handle Invalid Array Index");
                Console.WriteLine("21. Validate Duration");
                Console.WriteLine("22. Build Schedule Report using String");
                Console.WriteLine("23. Build Schedule Report using StringBuilder");
                Console.WriteLine("24. Run Benchmark");
                Console.WriteLine("0. Exit");
                Console.WriteLine("========================================");

                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        DisplayAllSessions(
                            sessionNames,
                            sessionDates,
                            sessionDurations);
                        break;

                    case 2:
                        Console.Write("Enter Session Name: ");
                        string? name = Console.ReadLine();

                        Console.WriteLine(
                            FindSessionByName(
                                sessionNames,
                                sessionDates,
                                sessionDurations,
                                name));
                        break;

                    case 3:
                        foreach (var session in SortSessionNames(sessionNames))
                        {
                            Console.WriteLine(session);
                        }
                        break;

                    case 4:
                        foreach (var session in ReverseSessionNames(sessionNames))
                        {
                            Console.WriteLine(session);
                        }
                        break;

                    case 5:
                        Console.Write("Enter Session Name: ");
                        name = Console.ReadLine();

                        Console.WriteLine(
                            IsSessionExists(sessionNames, name));
                        break;

                    case 6:
                        Console.WriteLine(
                            FindSessionBasedOnCondition(
                                sessionNames,
                                sessionName => sessionName.StartsWith('E')));
                        break;

                    case 7:
                        Console.WriteLine(
                            FindSessionIndexBasedOnCondition(
                                sessionNames,
                                sessionName => sessionName.StartsWith('A')));
                        break;

                    case 8:
                        foreach (var session in CopyArray(sessionNames))
                        {
                            Console.WriteLine(session);
                        }
                        break;

                    case 9:
                        var result = AnalyseSessionDurations(sessionDurations);

                        Console.WriteLine(result.durationAnalysis);

                        foreach (var sessionDuration in result.copiedSessionDuration)
                        {
                            Console.WriteLine(sessionDuration);
                        }
                        break;

                    case 10:
                        int x = 5;

                        Console.WriteLine($"Before ref: {x}");
                        ExplainRef(ref x);
                        Console.WriteLine($"After ref: {x}");
                        break;

                    case 11:
                        Console.Write("Enter Session Name: ");
                        name = Console.ReadLine() ?? "";

                        ExplainOut(
                            sessionNames,
                            sessionDurations,
                            name,
                            out int index,
                            out int duration);

                        Console.WriteLine($"Index: {index}");
                        Console.WriteLine($"Duration: {duration}");
                        break;

                    case 12:
                        Console.WriteLine(
                            $"Total Duration: {CalculateTotalDurationUsingParams(sessionDurations)}");
                        break;

                    case 13:
                        Console.Write("Enter Session Name: ");
                        name = Console.ReadLine() ?? "";

                        Console.WriteLine(
                            GetSessionDateDetails(
                                sessionNames,
                                name,
                                sessionDates,
                                sessionDurations));
                        break;

                    case 14:
                        Console.Write("Enter First Session Name: ");
                        string name1 = Console.ReadLine() ?? "";

                        Console.Write("Enter Second Session Name: ");
                        string name2 = Console.ReadLine() ?? "";

                        var interval = GetDateDifference(
                            sessionNames,
                            sessionDates,
                            name1,
                            name2);

                        Console.WriteLine($"Days: {interval.daysInterval}");
                        Console.WriteLine($"Hours: {interval.hoursInterval}");
                        break;

                    case 15:
                        foreach (var session in
                                 DetectPastOrUpcomingSession(
                                     sessionNames,
                                     sessionDates))
                        {
                            Console.WriteLine(session);
                        }
                        break;

                    case 16:
                        GetTheNextSession(
                            sessionNames,
                            sessionDates);
                        break;

                    case 17:
                        Console.Write("Enter Session Name: ");
                        name = Console.ReadLine() ?? "";

                        FormatSessionDateTime(
                            sessionNames,
                            name,
                            sessionDates);
                        break;

                    case 18:
                        Console.WriteLine(ReadAndValidateDate());
                        break;

                    case 19:
                        Console.Write("Enter a number: ");
                        Console.WriteLine(
                            ParseInt(Console.ReadLine()));
                        break;

                    case 20:
                        Console.Write("Enter session index: ");

                        if (int.TryParse(Console.ReadLine(), out int sessionIndex))
                        {
                            Console.WriteLine(
                                HandleInvalidArrayIndex(
                                    sessionNames,
                                    sessionIndex));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }
                        break;

                    case 21:
                        Console.Write("Enter a valid duration: ");

                        if (int.TryParse(Console.ReadLine(), out int durationInput))
                        {
                            try
                            {
                                ValidateDuration(durationInput);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Input operation finished.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid duration.");
                        }
                        break;

                    case 22:
                        Console.WriteLine(
                            BuildSchudleReportUsingString(
                                sessionNames,
                                sessionDates,
                                sessionDurations));
                        break;

                    case 23:
                        Console.WriteLine(
                            BuildSchudleReportUsingStringBuilder(
                                sessionNames,
                                sessionDates,
                                sessionDurations));
                        break;

                    case 24:
                        BenchmarkRunner.Run<StringConcatenationBenchmark>();
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose from the menu.");
                        break;
                }

            } while (choice != 0);

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

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 15 — Exception Handling: Menu Input");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine("please anter a number");
            //var input = Console.ReadLine();
            //ParseInt(input);
            //Console.WriteLine(input);

            //Console.WriteLine(ReadAndValidateDate());

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 16 — Exception Handling: Invalid Array Index");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine(HandleInvalidArrayIndex(sessionNames, 8));

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 17 & 18 — Throw an Exception - finally");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine("Enter a Valid Duration :");
            //if(int.TryParse(Console.ReadLine(), out int result))
            //try
            //{
            //    ValidateDuration(result);
            //}
            //catch(ArgumentException ex)
            //{
            //        Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Input operation finished.");
            //}

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 19 — Build a Schedule Report Using string");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine(BuildSchudleReportUsingString(sessionNames, sessionDates, sessionDurations));

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 20 — Build the Same Report Using StringBuilder");
            //Console.WriteLine("_______________________________________________\n");

            //Console.WriteLine(BuildSchudleReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));

            //Console.WriteLine("_______________________________________________");
            //Console.WriteLine("Part 22 — Benchmark Different Loop Sizes");
            //Console.WriteLine("_______________________________________________\n");

            //Console.ReadKey();
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

        public static int ParseInt(string? input)
        {
            if(input is null)
            {
                return -1;
            }

            while (true)
            {
                try
                {
                    return int.Parse(input);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid number. Please enter a valid number.");
                    input = Console.ReadLine();
                    if (input is null)
                    {
                        return -1;
                    }
                }
            }
        }

        public static string HandleInvalidArrayIndex(string[] sessionNames , int index)
        {
            try
            {
                return sessionNames[index];
            }
            catch (IndexOutOfRangeException)
            {
                return "no session at this index";
            }
        }

        public static void ValidateDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }
            
            Console.WriteLine("Duration accepted.");
        }

        public static string BuildSchudleReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
        {
            string report = "";

            for(int i = 0; i < sessionNames.Length; i++)
            {
                report += $"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDuration[i]} minutes\n";
            }

            return report;
        }

        public static string BuildSchudleReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDuration)
        {
            StringBuilder report = new StringBuilder();

            for (int i = 0; i < sessionNames.Length; i++)
            {
                report.Append($"{sessionNames[i]} - {sessionDates[i].ToString("dd/MM/yyyy hh:mm tt")} - {sessionDuration[i]} minutes\n");
            }

            return report.ToString();
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
