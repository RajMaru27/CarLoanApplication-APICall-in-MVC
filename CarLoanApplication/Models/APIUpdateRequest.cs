using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models
{
    public class APIUpdateRequest
    {
        public UpdatePersonalDetail updatePersonadetail { get; set; }
        public UpdateAddressDetail updateAddressdetail { get; set; }
        public UpdateFinancialDetail updateFinancialdetail { get; set; }
        public UpdateVehicalDetail updateVehicaldetail { get; set; }
        public UpdateRequestedLoanDetail updateRequestedloandetail { get; set; }

        public class UpdatePersonalDetail
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
        }
        public class UpdateAddressDetail
        {
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postalCode { get; set; }
        }
        public class UpdateFinancialDetail
        {
            public string bankName { get; set; }
            public string branch { get; set; }
            public string accountType { get; set; }
            public string accountNumber { get; set; }
            public string ownOrRent { get; set; }
            public string currentLoan { get; set; }
            public string workingStatus { get; set; }
            public string monthlyIncome { get; set; }
        }
        public class UpdateVehicalDetail
        {
            public string makeAndModel { get; set; }
            public string variant { get; set; }
            public DateTime registeredDate { get; set; }
            public string mileage { get; set; }
            public string insurance { get; set; }
            public string registrationNumber { get; set; }
            public string nEWorSECONDHAND { get; set; }
            public string hpi { get; set; }
            public string fullPrice { get; set; }
        }
        public class UpdateRequestedLoanDetail
        {
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