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

        public void GetSummary()
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
            jobApplications.Sort((a,b) => a.ApplicationStatus.CompareTo(b.ApplicationStatus));
            foreach (var job in jobApplications)
            {
                Console.WriteLine($"{job.CompanyName} - {job.ApplicationStatus}");
            }
        }

        public void ShowStatistics()
        {
            foreach (var job in jobApplications)
            {
                Console.WriteLine($"Applied to jobs: {jobApplications.Count}");
            }
        }
    }
}
