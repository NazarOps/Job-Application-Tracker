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
                
                Console.WriteLine("===============================================");
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
            int TotalOffered = jobApplications.Count(job => job.ApplicationStatus == JobApplication.Status.Offer);
            int TotalRejected = jobApplications.Count(job => job.ApplicationStatus == JobApplication.Status.Rejected);
            int TotalInterviews = jobApplications.Count(job => job.ApplicationStatus == JobApplication.Status.Interview);
            int responseCount = jobApplications.Count(job => job.ResponseDate != null);
            
            Console.WriteLine($"Total jobs you've applied to: {jobApplications.Count}");
            Console.WriteLine($"Total responds: {responseCount}");
            Console.WriteLine($"Total offers: {TotalOffered}");
            Console.WriteLine($"Total rejected: {TotalRejected}");
            Console.WriteLine($"Total interviews: {TotalInterviews}");
            
        }

        public void ManageJobs()
        {
           Console.Clear();
           Console.WriteLine("What would you like to do?");
           Console.WriteLine("1) Remove an application");
           Console.WriteLine("2) Edit status");
 
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
                    Console.WriteLine($"Date: {j.ApplicationDate}\n");
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

                    Console.Write("User: ");
                    string UserEdit = Console.ReadLine();

                    if (UserEdit == "remove")
                    {
                        jobApplications.Remove(selectedJob);
                        Console.WriteLine("Job removed from the list");
                        Thread.Sleep(500);
                        Console.Clear();
                    }
                }
                
                else
                {
                    Console.WriteLine("No application found with that company name.");
                }

                Console.WriteLine("Press any key to go back to menu");
                Console.ReadKey();
                break;
            }

           
            
           
        }
    }
}
