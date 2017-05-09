using System.Collections.Generic;
using DMP.Falck.GDP.DataGenerator.Interfaces;
using FluentValidation.Results;

namespace DMP.Falck.GDP.DataValidationLibrary.Interfaces
{
    public interface ICustomerValidator
    {
        void Dispose();
        bool IsValidCustomer(ICustomer customer, out IList<ValidationFailure> failures);
    }
}