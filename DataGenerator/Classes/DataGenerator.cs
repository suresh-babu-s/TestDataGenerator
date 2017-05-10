using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DMP.Falck.GDP.DataGenerator.Interfaces;
using DMP.Falck.GDP.DataValidationLibrary.Classes;
using DMP.Falck.GDP.DataValidationLibrary.Interfaces;
using DMP.Falck.GDP.DTO.Classes;
using DMP.Falck.GDP.DTO.Interfaces;
using FluentValidation.Results;

namespace DMP.Falck.GDP.DataGenerator.Classes
{
    /// <summary>
    /// This class is used for generating dummy test data of customers.
    /// It uses Faker.dll
    /// </summary>
    public class DataGenerator : IDisposable, IDataGenerator
    {

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public DataGenerator()
        { }

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
        /// Generate test data using Faker.dll.
        /// TO DO - Inject log object
        /// </summary>
        /// <param name="noOfCustomersToBeGenerated">No of customers to be generated</param>
        /// <returns>List of customers that has been generated successfully.</returns>
        public List<ICustomer> GenerateData(int noOfCustomersToBeGenerated)
        {
            List<ICustomer> customerList = new List<ICustomer>();

            try
            {
                using (ICustomerValidator customerValidator = new CustomerValidator())
                {
                    for (int count = 0; count < noOfCustomersToBeGenerated; count++)
                    {
                        Customer customer = new Customer
                        {
                            FirstName = Faker.Name.First(),
                            LastName = Faker.Name.Last(),
                            MiddleName=Faker.Name.Middle(),
                            CompanyName = Faker.Company.Name(),
                            RoadName = Faker.Address.StreetName(),
                            City = Faker.Address.City(),
                            PostCode = Faker.Address.ZipCode(),
                            District = Faker.Address.UsState(),
                            MobileNumber = Faker.Phone.Number(),
                            Email = Faker.Internet.Email()
                        };

                        customerList.Add(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                //log exception - TO DO
            }

            return customerList;
        }

        /// <summary>
        /// Check whether customer data is valid or not.
        /// </summary>
        /// <param name="customerValidator">The customer validator object using which customer object is validated.</param>
        /// <param name="customer">The customer object to be validated.</param>
        /// <param name="failure">The list of ValidationFailure objects returned by the fluent library.</param>
        /// <returns>True if customer object contains valid data else false.</returns>
        public bool IsValidCustomer(ICustomerValidator customerValidator,
            ICustomer customer, out IList<ValidationFailure> failure)
        {
            bool isValid = false;

            failure = null;

            isValid = customerValidator.IsValidCustomer(customer, out failure);

            return isValid;
        }
    }
}
