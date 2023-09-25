﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTA_MVC.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage = "Please Enter Your EmailId")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
    }
}