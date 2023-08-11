using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models.APIResponse
{
    public class ActiveListResponse
    {
        public string id {  get; set; }
        public string success { get; set; }
        public string message { get; set; }    
        public List<Data> data { get; set; }
        public class Data
        {
            public string loanId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime birthDate { get; set; } 
            public string maritalStatus { get; set; }
            public string email { get; set; }
            public string loanType { get; set; }
            public string loanAmount { get; set; }
            public bool activityStatus { get; set; }
        }
    }
}