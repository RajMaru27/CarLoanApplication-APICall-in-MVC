using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models.APIResponse
{
    public class DetailApiResponse
    {
        public string id {  get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public Result result { get; set; }
            public class Result
            {
                public string loanId { get; set; }
                public string firstName { get; set; }
                public string lastName { get; set; }
                public DateTime birthDate { get; set; }
                public string maritalStatus { get; set; }
                public string email { get; set; }
                public string phoneNumber { get; set; }
                public string emergencyContactNumber { get; set; }
                public string driversLicenseNumber { get; set; }
                public string addressLine1 { get; set; }
                public string addressLine2 { get; set; }
                public string city { get; set; }
                public string state { get; set; }
                public string postalCode { get; set; }
                public string bankName { get; set; }
                public string branch { get; set; }
                public string accountType { get; set; }
                public string accountNumber { get; set; }
                public string ownOrRent { get; set; }
                public string currentLoan { get; set; }
                public string workingStatus { get; set; }
                public string monthlyIncome { get; set; }
                public string makeAndModel { get; set; }
                public string variant { get; set; }
                public DateTime registeredDate { get; set; }
                public string mileage { get; set; }
                public string insurance { get; set; }
                public string registrationNumber { get; set; }
                public string nEWorSECONDHAND { get; set; }
                public string hpi { get; set; }
                public string fullPrice { get; set; }
                public string carType { get; set; }
                public string loanAmount { get; set; }
                public string terms { get; set; }
                public string prefferedPayment { get; set; }
                public string coSigner { get; set; }
                public string coSignerName { get; set; }
                public string coSignerPhoneNo { get; set; }
            }
        }
    }

}