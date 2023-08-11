using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models
{
    public class ListApirequest
    {
        public string loanId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string maritalStatus { get; set; }
        public string email { get; set; }
        public string loanType { get; set; }
        public string loanAmount { get; set; }
        public bool status { get; set; } 
    }
}