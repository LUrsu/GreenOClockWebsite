using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace GreenOClock.Services
{
    public class ValidateException : Exception
    {
        public ValidateException(IEnumerable<DbEntityValidationResult> validatationErrors)
        {
            ValidationErrors = validatationErrors;
        }

        public IEnumerable<DbEntityValidationResult> ValidationErrors { get; private set; }
    }
}
