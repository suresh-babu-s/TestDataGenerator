using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMP.Falck.GDP.DataGenerator.Interfaces;

namespace DMP.Falck.GDP.DataGenerator.Classes
{
    /// <summary>
    /// Class holding customer name, address and other details.
    /// </summary>
    public class Customer : ICustomer
    {
        public string CustomerType
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        public string RoadName
        {
            get;
            set;
        }

        public string HouseNumber
        {
            get;
            set;
        }

        public string PostCode
        {
            get;
            set;
        }

        public string District
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string MunicipalityCode
        {
            get;
            set;
        }

        public string RoadCode
        {
            get;
            set;
        }

        public string Letter
        {
            get;
            set;
        }

        public string Floor
        {
            get;
            set;
        }

        public string DoorType
        {
            get;
            set;
        }

        public string KVHX
        {
            get;
            set;
        }

        public string MobileNumber
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

    }
}
