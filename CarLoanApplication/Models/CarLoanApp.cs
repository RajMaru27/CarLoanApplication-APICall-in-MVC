using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models
{
    public class CarLoanApp
    {
        public PersonalDetail personadetail { get; set; }
        public AddressDetail addressdetail { get; set; }
        public FinancialDetail financialdetail { get; set; }
        public VehicalDetail vehicaldetail { get; set; }
        public RequestedLoanDetail requestedloandetail { get; set; }

        public class PersonalDetail
        {
            [Required]
            public string firstName { get; set; }
            [Required]
            public string lastName { get; set; }
            [Required]
            public DateTime birthDate { get; set; }
            [Required]
            public string maritalStatus { get; set; }
            [Required]
            public string email { get; set; }
            [Required]
            public string phoneNumber { get; set; }
            [Required]
            public string emergencyContactNumber { get; set; }
            [Required]
            public string driversLicenseNumber { get; set; }
        }
        public class AddressDetail
        {
            [Required]
            public string addressLine1 { get; set; }
            [Required]
            public string addressLine2 { get; set; }
            [Required]
            public string city { get; set; }
            [Required]
            public string state { get; set; }
            [Required]
            public string postalCode { get; set; }
        }
        public class FinancialDetail
        {
            [Required]
            public string bankName { get; set; }
            [Required]
            public string branch { get; set; }
            [Required]
            public string accountType { get; set; }
            [Required]
            public string accountNumber { get; set; }
            [Required]
            public string ownOrRent { get; set; }
            [Required]
            public string currentLoan { get; set; }
            [Required]
            public string workingStatus { get; set; }
            [Required]
            public string monthlyIncome { get; set; }
        }
        public class VehicalDetail
        {
            [Required]
            public string makeAndModel { get; set; }
            [Required]
            public string variant { get; set; }
            [Required]
            public DateTime registeredDate { get; set; }
            [Required]
            public string mileage { get; set; }
            [Required]
            public string insurance { get; set; }
            [Required]
            public string registrationNumber { get; set; }
            [Required]
            public string nEWorSECONDHAND { get; set; }
            [Required]
            public string hpi { get; set; }
            [Required]
            public string fullPrice { get; set; }
        }
        public class RequestedLoanDetail
        {
            [Required]
            public string carType { get; set; }
            [Required]
            public string loanAmount { get; set; }
            [Required]
            public string terms { get; set; }
            [Required]
            public string prefferedPayment { get; set; }
            [Required]
            public string coSigner { get; set; }
            
            public string coSignerName { get; set; }
            
            public string coSignerPhoneNo { get; set; }
        }
    }
}