using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application_Tracker
{
    public class JobManager
    {
        List<JobApplication> jobApplications = new List<JobApplication>();
        
        public void AddApplication(JobApplication application)
        {
            jobApplications.Add(application);
        }

        public void GetSummary()
        {
            Console.WriteLine("Your job Applications: ");
            foreach (JobApplication j in jobApplications)
            {
                Console.WriteLine($"\nName: {j.CompanyName}");
                Console.WriteLine($"Title: {j.PositionTitle}");
                Console.WriteLine($"Expected Salary: {j.SalaryExpectation}\n");
                Console.WriteLine($"Status: {j.ApplicationStatus}");
                Console.WriteLine($"Date: {j.ApplicationDate}\n");
                Console.WriteLine($"Responded Date: {(j.ResponseDate.HasValue ? j.ResponseDate.Value.ToString("yyyy-MM-dd HH:mm") : "No response")}");
            }
            Thread.Sleep(500);
            Console.ReadKey();
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
                int responseCount = jobApplications.Count(job => job.ResponseDate != null);
                Console.WriteLine($"Total jobs you've applied to: {jobApplications.Count}");
                Console.WriteLine($"Total responds: {responseCount}");
            }
        }
    }
}
