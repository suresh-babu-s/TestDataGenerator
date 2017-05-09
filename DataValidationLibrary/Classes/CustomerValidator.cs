using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DMP.Falck.GDP.DataGenerator.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using DMP.Falck.GDP.DataValidationLibrary.Interfaces;

namespace DMP.Falck.GDP.DataValidationLibrary.Classes
{
    /// <summary>
    /// Class for performing customer data validation.
    /// </summary>
    public class CustomerValidator : AbstractValidator<ICustomer>, ICustomerValidator, IDisposable
    {

        const int postCodeLength = 4;

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("First name can't be blank!");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Last name can't be blank!");
            //RuleFor(customer => customer.RoadName).Length(20, 250);
            RuleFor(customer => customer.RoadName).NotEmpty().WithMessage("Road name can't be blank!");
            RuleFor(customer => customer.HouseNumber).NotEmpty().WithMessage("House number can't be blank!");
            RuleFor(customer => customer.PostCode).Must(IsValidPostcode).WithMessage("Please specify a valid postcode!");
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        /// <summary>
        /// Check for valid post code.
        /// </summary>
        /// <param name="postCode">The post code to be validated.</param>
        /// <returns>True if post code is valid else false.</returns>
        public bool IsValidPostcode(string postCode)
        {
            // custom postcode validating logic 
            int postCodeConverted;
            bool isValid = false;

            if (!string.IsNullOrEmpty(postCode))
            {
                if (postCode.Length == postCodeLength)
                {
                    isValid = int.TryParse(postCode, out postCodeConverted);
                }
            }

            return isValid;
        }

        /// <summary>
        /// Validate customer data stored in the customer class.
        /// </summary>
        /// <param name="customer">The customer object to be validated.</param>
        /// <param name="failures">List of validation failure messages.</param>
        /// <returns>True if cutomer data is valid else false.</returns>
        public bool IsValidCustomer(ICustomer customer, out IList<ValidationFailure> failures)
        {
            ValidationResult results = null;

            bool isValid = false;

            failures = null;

            try
            {
                results = this.Validate(customer);
                isValid = results.IsValid;
                failures = results.Errors;
            }
            catch (Exception ex)
            {
                //TO Do - Log exception
            }

            return isValid;
        }
    }


}
