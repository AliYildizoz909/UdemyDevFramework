using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate<T>(IValidator validator, T entity) where T : class, new()
        {
            var result = validator.Validate(new ValidationContext<T>(entity));

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
