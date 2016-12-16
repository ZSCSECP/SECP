using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SECP.Models
{
    public class Login
    {
        
        [DisplayName("User")]
        public string UserName { get; set; }
        [DisplayName("Pwd")]
        public string PassWord { get; set; }
    }
}