using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models.APIResponse
{
    public class ListResponse
    {
        public string id { get; set; }
        public bool status { get; set; }
        public string message { get; set; } 
        public List<ListApirequest> loanApplicantLists { get; set; }
    }
}