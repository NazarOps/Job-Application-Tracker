using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    internal class JobApplication
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
            try
            {
                Console.WriteLine("What's the company called?");
                Console.Write("\nUser: ");
                string NameOfCompany = Console.ReadLine();

                Console.WriteLine("What's the position title?");
                Console.Write("User: ");
                string TitleOfPosition = Console.ReadLine();

                JobApplication jobapplied = new JobApplication
                {
                    CompanyName = NameOfCompany,
                    PositionTitle = TitleOfPosition,
                    ApplicationStatus = Status.Applied,
                    ApplicationDate = DateTime.Now
                };

                jobApplications.Add(jobapplied);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while applying: {ex.Message}");
            }
        }

        public void GetSummary()
        {
            try
            {
                Console.WriteLine("Your job Applications: ");
                foreach (JobApplication j in jobApplications)
                {
                    Console.WriteLine($"\nName: {j.CompanyName}");
                    Console.WriteLine($"Title: {j.PositionTitle}");
                    Console.WriteLine($"Status: {j.ApplicationStatus}");
                    Console.WriteLine($"Date: {j.ApplicationDate}\n");
                }
                Thread.Sleep(500);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting the summary: {ex.Message}");
            }
        }

        public void SortByDate()
        {
            try
            {
                jobApplications.Sort((a, b) => a.ApplicationDate.CompareTo(b.ApplicationDate));
                foreach (var job in jobApplications)
                {
                    Console.WriteLine($"{job.CompanyName} - {job.ApplicationDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sorting by date: {ex.Message}");
            }
        }

        public void SortByStatus()
        {
            try
            {
                jobApplications.Sort((a, b) => a.ApplicationStatus.CompareTo(b.ApplicationStatus));
                foreach (var job in jobApplications)
                {
                    Console.WriteLine($"{job.CompanyName} - {job.ApplicationStatus}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sorting by status: {ex.Message}");
            }
        }

        public void ShowStatistics()
        {
            try
            {
                Console.WriteLine($"Total jobs you've applied to: {jobApplications.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while showing statistics: {ex.Message}");
            }
        }

    }
}
