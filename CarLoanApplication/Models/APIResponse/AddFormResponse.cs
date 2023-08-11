using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models.APIResponse
{
    public class AddFormResponse
    {
        public string id { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }
}