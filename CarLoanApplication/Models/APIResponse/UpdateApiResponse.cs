﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarLoanApplication.Models.APIResponse
{
    public class UpdateApiResponse
    {
        public string id {  get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}