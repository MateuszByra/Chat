using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class Exists : ValidationAttribute
    {
        public Exists()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}