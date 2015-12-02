using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace HostEditor.App_Start
{
    class IpValidation : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(ValidationContext validationContext)
        {
            const string regexPattern = @"^([\d]{1,3}\.){3}[\d]{1,3}$";
            var regex = new Regex(regexPattern);

             if (!regex.IsMatch(IP))
             yield return new ValidationResult("IP address format is invalid", new[] { "IP" });

            string[] values = IP.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            byte ipByteValue;

            foreach (string token in values)
             {
             if (!byte.TryParse(token, out ipByteValue))
                    yield return new ValidationResult("IP address value is incorrect", new[] { "IP" });
             }
           
           
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ValidationType = "checkcidr";
            rule.ErrorMessage = "Not a valid CIDR Subnet";
            return new List<ModelClientValidationRule> { rule };
        }
    }
}
