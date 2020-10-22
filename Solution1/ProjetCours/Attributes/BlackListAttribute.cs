using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjetCours.Attributes
{
    public class BlackListAttribute : ValidationAttribute
    {
        private object[] _listWord;
        public BlackListAttribute(params object[] wordBanned)
        {
            _listWord = wordBanned;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            foreach(string element in _listWord)
            {
                if (value is IComparable && !(value is string))
                {
                    var result = ((IComparable)value).CompareTo(element);
                    if (result == 0)
                        return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName, value.ToString()));
                }
                if (element.ToString().ToLower() == value?.ToString().ToLower())
                {
                    return new ValidationResult(this.FormatErrorMessage(value.ToString()));
                }
            }
            return ValidationResult.Success;
        }

        private string FormatErrorMessage(string displayName, string name)
        {
            return string.Format(this.ErrorMessage, displayName, name);
        }
    }
}
