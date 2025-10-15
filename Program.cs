namespace Job_Application_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool MenuLoop = true;


            JobApplication jobApplication = new JobApplication();

            while (MenuLoop)
            {
                Console.WriteLine("Job Application Tracker\n");
                Console.WriteLine("1) Apply for a new job");
                Console.WriteLine("2) Show all applications");
                Console.WriteLine("3) Filter by status");
                Console.WriteLine("4) Sort by date");
                Console.WriteLine("5) Show statistics");
                Console.WriteLine("\nType 6 to quit the application");

                Console.Write("\nuser: ");
                int userinput = Convert.ToInt32(Console.ReadLine());

                switch (userinput)
                {
                    case 1:
                        Console.Clear();
                        jobApplication.Apply();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 2:
                        Console.WriteLine("All of your applications: ");
                        jobApplication.GetSummary();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Filter by status: ");
                        jobApplication.SortByStatus();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Sort by statistics");
                        jobApplication.ShowStatistics();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 5:
                        Console.WriteLine("Show statistics");
                        break;
                }

                if (userinput == 6)
                {
                    break;
                }
            }
        }
    }
}
