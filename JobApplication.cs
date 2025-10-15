using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    public class JobApplication
    {
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int SalaryExpectation { get; set; }

        public Status ApplicationStatus { get; set; }

        public int DaysSinceApplied => (DateTime.Now - ApplicationDate).Days;



        List<JobApplication> jobApplications = new List<JobApplication>();

        public enum Status
        {
            Applied,
            Interview,
            Offer,
            Rejected
        }

        public void Apply()
        {
            bool valid = false;

            while (!valid)
            {
                try
                {
                    Console.WriteLine("What's the company called?");
                    Console.Write("\nUser: ");
                    string NameOfCompany = Console.ReadLine();

                    Console.WriteLine("What's the position title?");
                    Console.Write("User: ");
                    string TitleOfPosition = Console.ReadLine();

                    Console.WriteLine("What's the expected salary?");
                    Console.Write("User: ");
                    string ExpectedSalary = Console.ReadLine();

                    if (!Regex.IsMatch(TitleOfPosition, @"^[a-zA-Z-\s]+$"))
                    {
                        throw new ArgumentException("Position title contains invalid characters, only letters and spaces are allowed!");
                    }

                    if (!int.TryParse(ExpectedSalary, out int SalaryExpectation) || SalaryExpectation  <= 0)
                    {
                        throw new ArgumentException("Salary must contain only numbers and can no symbols");
                    }

                    int DesiredSalary = Convert.ToInt32(ExpectedSalary); // converts salary to int after checking if input is valid

                    JobApplication jobapplied = new JobApplication
                    {
                        CompanyName = NameOfCompany,
                        PositionTitle = TitleOfPosition,
                        SalaryExpectation = DesiredSalary,
                        ApplicationStatus = Status.Applied,
                        ApplicationDate = DateTime.Now
                    };

                    jobApplications.Add(jobapplied);
                    valid = true;
                    Console.WriteLine("Job application has been logged");
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    
                }
            }
        }

        public void GetSummary()
        {
            Console.WriteLine("Your job Applications: ");
            foreach (JobApplication j in jobApplications)
            {
                Console.WriteLine($"\nName: {j.CompanyName}");
                Console.WriteLine($"Title: {j.PositionTitle}");
                Console.WriteLine($"Status: {j.ApplicationStatus}");
                Console.WriteLine($"Date: {j.ApplicationDate}\n");
                Console.WriteLine($"Expected Salary: {j.SalaryExpectation}\n");
            }
            Thread.Sleep(500);
            Console.Clear();
        }

        public void SortByDate()
        {
            jobApplications.Sort((a, b) => a.ApplicationDate.CompareTo(b.ApplicationDate));
            foreach (var job in jobApplications)
            {
                Console.WriteLine($"{job.CompanyName} - {job.ApplicationDate}");
            }
        }

        public void SortByStatus()
        {
            jobApplications.Sort((a, b) => a.ApplicationStatus.CompareTo(b.ApplicationStatus));
            foreach (var job in jobApplications)
            {
                Console.WriteLine($"{job.CompanyName} - {job.ApplicationStatus}");
            }
        }

        public void ShowStatistics()
        {
            foreach (var job in jobApplications)
            {
                Console.WriteLine($"Total jobs you've applied to: {jobApplications.Count}");
                
            }
        }
    }
}
