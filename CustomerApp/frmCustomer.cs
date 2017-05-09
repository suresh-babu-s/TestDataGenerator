using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DMP.Falck.GDP.DataGenerator.Classes;

namespace CustomerApp
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnGenerateCustomers_Click(object sender, EventArgs e)
        {
            int noOfCustomers = 0;

            if (string.IsNullOrEmpty(txtNoOfCustomers.Text.Trim()) ||
                !int.TryParse(txtNoOfCustomers.Text.Trim(), out noOfCustomers))
            {
                MessageBox.Show("Please enter valid number of customers to be generated!");
                txtNoOfCustomers.Focus();
                return;
            }

            btnGenerateCustomers.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            lstCustomers.Items.Clear();

            DMP.Falck.GDP.DataGenerator.Interfaces.IDataGenerator dataGenerator =
                new DMP.Falck.GDP.DataGenerator.Classes.DataGenerator();

            try
            {
                DateTime startTime = DateTime.Now;
                List<DMP.Falck.GDP.DataGenerator.Classes.Customer> customerList = dataGenerator.GenerateData(100000);
                foreach (Customer customer in customerList)
                {
                    lstCustomers.Items.Add(customer.FirstName + " " + customer.LastName + " " + customer.RoadName + " " + customer.HouseNumber);
                    lstCustomers.Refresh();
                }
                lblMessage.Text = "Generated and added " + customerList.Count.ToString() + " customers in " +
                    DateTime.Now.Subtract(startTime).TotalMinutes.ToString() + " minutes!";
                lblMessage.Refresh();
            }
            catch (Exception ex)
            {

            }
            btnGenerateCustomers.Enabled = true;
            Cursor.Current = Cursors.Arrow;
        }

        private void txtNoOfCustomers_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
