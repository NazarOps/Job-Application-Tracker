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
        public string CompanyName;
        public string PositionTitle;
        public Status Status;
        public DateTime ApplicationDate;
        public DateTime? ResponseDate;
        public int SalaryExpectation;

        public void GetDaysSinceApplied()
        {

        }

        public void GetSummary()
        {

        }
    }
}
