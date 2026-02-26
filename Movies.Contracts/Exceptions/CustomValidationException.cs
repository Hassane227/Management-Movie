using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Contracts.Errors;

namespace Movies.Contracts.Exceptions
{
    public class CustomValidationException: Exception
    {
        public CustomValidationException(List<ValidationError> validationErrors) { 

            ValidationErrors = validationErrors;
        
        }

        public List<ValidationError> ValidationErrors { get; set; }
    }
}
