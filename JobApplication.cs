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



        

        public enum Status
        {
            Applied,
            Interview,
            Offer,
            Rejected
        }

        public void Apply(JobManager manager)
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

                    Console.WriteLine("Do you have a response date? (yes/no)");
                    Console.Write("User: ");
                    string hasResponse = Console.ReadLine();
                    DateTime? responseDate = null;
                    if (hasResponse?.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter the response date (yyyy-mm-dd)");
                        string responseInput = Console.ReadLine();
                        if (DateTime.TryParse(responseInput, out DateTime parsedDate))
                        {
                            responseDate = parsedDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Response date will be left empty.");
                        }
                    }

                    if (hasResponse?.ToLower() == "no")
                    {
                        responseDate = null;
                    }

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
                        ApplicationDate = DateTime.Now,
                        ResponseDate = responseDate
                    };

                    manager.AddApplication(jobapplied);
                    valid = true;
                    Console.WriteLine("Job application has been logged");
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    
                }
            }
        }

   
    }
}
