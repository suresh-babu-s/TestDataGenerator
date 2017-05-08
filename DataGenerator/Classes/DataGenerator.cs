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
        public DataGenerator()
        { }

        // Flag: Has Dispose already been called?
        bool _disposed = false;

        // Instantiate a SafeHandle instance.
        SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            _disposed = true;
        }

        public bool GenerateData()
        {
            bool isSuccess = false;

            var name = Faker.Name.FullName();  // "Alene Hayes"
            Faker.Internet.Email(name);  // "alene_hayes@hartmann.co.uk"
            Faker.Internet.UserName(name);  // "alene.hayes"

            Faker.Internet.Email();  // "morris@friesen.us"
            Faker.Internet.FreeEmail();  // "houston_purdy@yahoo.com"

            Faker.Internet.DomainName();  // "larkinhirthe.com"

            Faker.Phone.Number();  // "(033)216-0058 x0344"

            return isSuccess;
        }
    }
}
