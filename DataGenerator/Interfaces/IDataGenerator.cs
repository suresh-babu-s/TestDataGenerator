using System.Collections.Generic;
using DMP.Falck.GDP.DTO.Interfaces;

namespace DMP.Falck.GDP.DataGenerator.Interfaces
{
    public interface IDataGenerator
    {
        void Dispose();
        List<ICustomer> GenerateData(int noOfCustomersToBeGenerated);
    }
}