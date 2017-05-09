using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DMP.Falck.GDP.DataGenerator.Interfaces;

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
        public List<Customer> GenerateData(int noOfCustomersToBeGenerated)
        {
            List<Customer> customerList = new List<Customer>();

            try
            {
                for (int count = 0; count < noOfCustomersToBeGenerated; count++)
                {
                    Customer customer = new Customer
                    {
                        FirstName = Faker.Name.First(),
                        LastName = Faker.Name.Last(),
                        CompanyName = Faker.Company.Name(),
                        RoadName = Faker.Address.StreetName(),
                        MobileNumber = Faker.Phone.Number(),
                        Email = Faker.Internet.Email(),
                        PostCode = Faker.Address.ZipCode(),
                        District = Faker.Address.UsState()
                    };

                    customerList.Add(customer);
                }
            }
            catch (Exception ex)
            {
                //log exception - TO DO
            }

            return customerList;
        }

        
    }
}
