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
        public string CompanyName;
        public string PositionTitle;
        public DateTime ApplicationDate;
        public DateTime? ResponseDate;
        public int SalaryExpectation;

        public Status ApplicationStatus;

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
