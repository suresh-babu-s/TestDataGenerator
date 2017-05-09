using System.Collections.Generic;
using DMP.Falck.GDP.DTO.Interfaces;
using FluentValidation.Results;
using System;

namespace DMP.Falck.GDP.DataValidationLibrary.Interfaces
{
    public interface ICustomerValidator: IDisposable
    {
        //void Dispose();
        bool IsValidCustomer(ICustomer customer, out IList<ValidationFailure> failures);
    }
}