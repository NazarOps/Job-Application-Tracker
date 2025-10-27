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

        public int DaysSinceApplied => (ApplicationDate - DateTime.Today).Days;

        public enum Status
        {
            Applied,
            Interview,
            Offer,
            Rejected
        }
    }
}
