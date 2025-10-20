using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Job_Application_Tracker.JobApplication;
using Spectre.Console;

namespace Job_Application_Tracker
{
    public class JobManager
    {
        List<JobApplication> jobApplications = new List<JobApplication>();

        public void Apply()
        {
            bool valid = false;

            while (!valid)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("What's the company called?");
                    Console.Write("\nUser: ");
                    string NameOfCompany = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(NameOfCompany))
                    {
                        throw new ArgumentException("Invalid characters detected for company name, field can not be empty");
                    }

                    Console.WriteLine("What's the position title?");
                    Console.Write("User: ");
                    string TitleOfPosition = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(TitleOfPosition))
                    {
                        throw new ArgumentException("Invalid characters detected for position title, field can not be empty");
                    }

                    if (!Regex.IsMatch(TitleOfPosition, @"^[a-zA-Z-\s]+$"))
                    {
                        throw new ArgumentException("Invalid characters detected for position title, only letters and spaces are allowed!");
                    }

                    Console.WriteLine("What's the expected salary?");
                    Console.Write("User: ");
                    string ExpectedSalary = Console.ReadLine();

                    if (!int.TryParse(ExpectedSalary, out int SalaryExpectation) || SalaryExpectation <= 0)
                    {
                        throw new ArgumentException("Salary must contain only numbers and no symbols");
                    }

                    Console.WriteLine("When did you apply? (YYYY-MM-DD)");
                    Console.Write("User: ");
                    string DateOfApplication = Console.ReadLine();

                    DateTime applicationDate;
                    if (!DateTime.TryParse(DateOfApplication, out applicationDate))
                    {
                        Console.WriteLine("Invalid date format. Using today's date");
                        applicationDate = DateTime.Now;
                    }

                    Console.WriteLine("Do you have a response date? (yes/no)");
                    Console.Write("User: ");
                    string hasResponse = Console.ReadLine();

                    DateTime? responseDate = null;

                    if (hasResponse?.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter the response date (yyyy-mm-dd)");
                        Console.Write("User: ");
                        string responseInput = Console.ReadLine();
                        if (DateTime.TryParse(responseInput, out DateTime parsedDate))
                        {
                            responseDate = parsedDate + DateTime.Now.TimeOfDay;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Response date will be left empty");
                        }
                    }

                    if (hasResponse?.ToLower() == "no")
                    {
                        responseDate = null;
                    }

                    Console.WriteLine("Do you have a interview lined up? (yes/no)");
                    Console.Write("User: ");
                    string hasInterview = Console.ReadLine();

                    JobApplication.Status status = JobApplication.Status.Applied; // Declaring status default is applied

                    if (hasInterview.ToLower() == "yes")
                    {
                        status = JobApplication.Status.Interview;
                    }

                    if (hasInterview.ToLower() == "no")
                    {
                        status = JobApplication.Status.Applied;
                    }

                    int DesiredSalary = Convert.ToInt32(ExpectedSalary); // converts salary to int after checking if input is valid

                    JobApplication jobapplied = new JobApplication
                    {
                        CompanyName = NameOfCompany,
                        PositionTitle = TitleOfPosition,
                        SalaryExpectation = DesiredSalary,
                        ApplicationStatus = status,
                        ApplicationDate = applicationDate,
                        ResponseDate = responseDate
                    };

                    jobApplications.Add(jobapplied);
                    valid = true;
                    Console.WriteLine("Job application has been logged");
                }

                catch (ArgumentException ex)
                {
                    AnsiConsole.MarkupLine($"Error: [red]{ex.Message}[/]");
                    Thread.Sleep(500);
                    Console.WriteLine("Press any key to go back to menu");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }

        public void GetSummary()
        {
            Console.WriteLine("Your job Applications: ");
            foreach (JobApplication j in jobApplications)
            {
                Console.WriteLine($"\nCompany Name: {j.CompanyName}");
                Console.WriteLine($"Position Title: {j.PositionTitle}");
                Console.WriteLine($"Expected Salary: {j.SalaryExpectation}\n");
                Console.WriteLine($"Application Status: {j.ApplicationStatus.ToString()}");
                Console.WriteLine($"Application Date: {j.ApplicationDate.ToString("yyyy-MM-dd")}\n");
                Console.WriteLine($"Responded Date: {(j.ResponseDate.HasValue ? j.ResponseDate.Value.ToString("yyyy-MM-dd HH:mm") : "No response")}");
                Console.WriteLine($"Days passed since application: {(DateTime.Today - j.ApplicationDate).Days}");

                Console.WriteLine("===============================================");
            }
        }

        public void SortByDate()
        {
            jobApplications = jobApplications
                .OrderByDescending(job => job.ApplicationDate)
                .ToList();

            foreach (var job in jobApplications)
            {
                Console.WriteLine($"{job.CompanyName} - {job.ApplicationDate}");
            }
        }

        public void SortByStatus()
        {
            jobApplications = jobApplications
                .OrderBy(job => job.ApplicationStatus switch
                {
                    JobApplication.Status.Offer => 1,
                    JobApplication.Status.Interview => 2,
                    JobApplication.Status.Applied => 3,
                    JobApplication.Status.Rejected => 4,
                })
                .ThenByDescending(job => job.ApplicationDate).ToList();

            foreach (var job in jobApplications)
            {
                Console.WriteLine($"{job.CompanyName} - {job.ApplicationStatus}");
            }
        }

        public void ShowStatistics()
        {
            int TotalOffered = jobApplications.Count(job => job.ApplicationStatus == JobApplication.Status.Offer);
            int TotalRejected = jobApplications.Count(job => job.ApplicationStatus == JobApplication.Status.Rejected);
            int TotalInterviews = jobApplications.Count(job => job.ApplicationStatus == JobApplication.Status.Interview);
            int responseCount = jobApplications.Count(job => job.ResponseDate != null);
            
            Console.WriteLine($"Total jobs you've applied to: {jobApplications.Count}");
            AnsiConsole.MarkupLine($"Total responds: [blue]{responseCount}[/]");
            AnsiConsole.MarkupLine($"Total offers: [green]{TotalOffered}[/]");
            AnsiConsole.MarkupLine($"Total rejected: [red]{TotalRejected}[/]");
            AnsiConsole.MarkupLine($"Total interviews: [yellow]{TotalInterviews}[/]");

            
        }

        public void ManageJobs()
        {
           Console.Clear();
           Console.WriteLine("What would you like to do?");
           Console.WriteLine("1) Edit status");
 
           Console.Write("User: ");
            
           string UserInput = Console.ReadLine();
           
           
           while(UserInput == "1")
           {
                Console.WriteLine("Which application would you like to edit? \n");    
                foreach(JobApplication j in jobApplications)
                {
                    Console.WriteLine($"\nName: {j.CompanyName}");
                    Console.WriteLine($"Title: {j.PositionTitle}");
                    Console.WriteLine($"Expected Salary: {j.SalaryExpectation}\n");
                    Console.WriteLine($"Status: {j.ApplicationStatus}");
                    Console.WriteLine($"Date: {j.ApplicationDate.ToString()}\n");
                    Console.WriteLine($"Responded Date: {(j.ResponseDate.HasValue ? j.ResponseDate.Value.ToString("yyyy-MM-dd HH:mm") : "No response")}");

                    Console.WriteLine("===============================================");
                }

                Console.Write("User: ");
                string UserInputEdit = Console.ReadLine();

                var selectedJob = jobApplications
                    .FirstOrDefault(j => j.CompanyName.Equals(UserInputEdit, StringComparison.OrdinalIgnoreCase));

                if (selectedJob != null)
                {
                    Console.Clear();
                    Console.WriteLine("The job was found");
                    Console.WriteLine($"Selected application: {selectedJob.CompanyName} - {selectedJob.PositionTitle}");
                    
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1) Remove");
                    Console.WriteLine("2) Edit Application Status");

                    Console.Write("User: ");
                    string UserEdit = Console.ReadLine();

                    if (UserEdit == "1")
                    {
                        jobApplications.Remove(selectedJob);
                        Console.WriteLine("Job removed from the list");
                        Thread.Sleep(500);
                        Console.Clear();
                    }

                    if (UserEdit == "2")
                    {
                        Console.WriteLine("Update your status to: ");
                        AnsiConsole.MarkupLine("1.) [green]Offered[/]");
                        AnsiConsole.MarkupLine("2.) [red]Rejected[/]");
                        AnsiConsole.MarkupLine("3.) [yellow]Interview[/]");

                        Console.Write("User: ");
                        string UpdateStatus = Console.ReadLine();

                        if (UpdateStatus == "1")
                        {
                            selectedJob.ApplicationStatus = JobApplication.Status.Offer;
                            AnsiConsole.MarkupLine("Application status changed to [green]offered[/]");
                            Thread.Sleep(500);
                            Console.Clear();
                            break;
                        }

                        if (UpdateStatus == "2")
                        {
                            selectedJob.ApplicationStatus = JobApplication.Status.Rejected;
                            AnsiConsole.MarkupLine("Application status changed to [red]rejected[/]");
                            Thread.Sleep(500);
                            Console.Clear();
                            break;
                        }

                        if (UpdateStatus == "3")
                        {
                            selectedJob.ApplicationStatus = JobApplication.Status.Interview;
                            AnsiConsole.MarkupLine("Application status changed to [yellow]interview[/]");
                            Thread.Sleep(500);
                            Console.Clear();
                            break;
                        }
                    }

                    
                }
                
                else
                {
                    Console.WriteLine("No application found with that company name.");
                    Console.WriteLine("Press any key to go back to menu");
                    Console.ReadKey();
                    Thread.Sleep(500);
                    Console.Clear();
                    break;
                }
            }

           
            
           
        }
    }
}
