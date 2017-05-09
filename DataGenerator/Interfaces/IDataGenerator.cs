using System.Collections.Generic;
using DMP.Falck.GDP.DataGenerator.Classes;

namespace DMP.Falck.GDP.DataGenerator.Interfaces
{
    public interface IDataGenerator
    {
        void Dispose();
        List<Customer> GenerateData(int noOfCustomersToBeGenerated);
    }
}