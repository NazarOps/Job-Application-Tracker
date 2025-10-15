namespace Job_Application_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobApplication jobApplication = new JobApplication();

            JobApplication jobApplication = new JobApplication();

            JobManager jobManager = new JobManager();
            bool MenuLoop = true;
            
            while (MenuLoop)
            {
                Console.WriteLine("Job Application Tracker\n");
                Console.WriteLine("1) Apply for a new job");
                Console.WriteLine("2) Show all applications");
                Console.WriteLine("3) Filter by status");
                Console.WriteLine("4) Sort by date");
                Console.WriteLine("5) Show statistics");
                Console.WriteLine("6) Manage jobs");
                Console.WriteLine("\nType 6 to quit the application");

                Console.Write("\nuser: ");
                int userinput = Convert.ToInt32(Console.ReadLine());

                switch (userinput)
                {
                    case 1:
                        Console.Clear();
                        application.Apply(manager);
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("All of your applications: \n");
                        manager.GetSummary();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Filter by status: ");
                        manager.SortByStatus();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Sort by statistics");
                        manager.ShowStatistics();
                        Thread.Sleep(500);
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        jobApplication.ShowStatistics();
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
