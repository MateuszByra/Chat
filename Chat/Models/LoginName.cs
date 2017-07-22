using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class LoginName
    {
        [Required(ErrorMessage ="Login jest wymagany")]
        public string Name { get; set; }
    }
}