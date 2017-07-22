using Chat.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Logic.Validation
{
    public class ExistsLoginAttribute : ValidationAttribute
    {
        /// <summary>
        /// Walidacja dla istniejacego loginu
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            var name = value as string;
            if (name == null)
                return false;
            return !ChatFactory.CreateNamesLogic().Exists(name);
        }
    }
}
