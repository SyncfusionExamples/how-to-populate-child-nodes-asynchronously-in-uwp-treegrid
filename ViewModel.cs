using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnDemandLoading
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Employees = this.GetParentEmployees();
        }

        private ObservableCollection<EmployeeInfo> _employees;
        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public ObservableCollection<EmployeeInfo> GetParentEmployees()
        {
            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ferando", LastName = "Joseph", Title = "Management", Salary = 2000000, ReportsTo = -1, ID = 2 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "John", LastName = "Adams", Title = "Accounts", Salary = 2000000, ReportsTo = -1, ID = 3 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Thomas", LastName = "Jefferson", Title = "Sales", Salary = 300000, ReportsTo = -1, ID = 4 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Madison", Title = "Marketing", Salary = 4000000, ReportsTo = -1, ID = 5 });
            employeeDetails.Add(new EmployeeInfo() { FirstName = "Ulysses", LastName = "Pierce", Title = "HumanResource", Salary = 1500000, ReportsTo = -1, ID = 6 });
           
           
            return employeeDetails;
        }

        //internal void async IEnumerable GetEmployees(int iD)
        public async Task<IEnumerable<EmployeeInfo>> GetEmployees(int iD)
        {
            Debug.WriteLine("## ThreadId = " + Environment.CurrentManagedThreadId + " Begin calling viewModel.GetEmployees(emp.ID) ##");

            ObservableCollection<EmployeeInfo> employeeDetails = new ObservableCollection<EmployeeInfo>();

            Debug.WriteLine("## ThreadId = " + Environment.CurrentManagedThreadId + " Before calling await Task.Delay(1000) ##");

            // ====>>> Used to simulate a Web Service that supports the pattern asyn / await (here we just use Task.Delay() instead
            await Task.Delay(100);
           

            Debug.WriteLine("## ThreadId = " + Environment.CurrentManagedThreadId + " After calling await Task.Delay(1000) ##");

            if (iD == 2)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", ID = 9, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", ID = 10, Salary = 1000000, ReportsTo = 2, Title = "GM" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", ID = 11, Salary = 900000, ReportsTo = 2, Title = "Manager" });
            }
            else if (iD == 3)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", ID = 12, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ID = 13, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ID = 14, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", ID = 15, Salary = 650000, ReportsTo = 3, Title = "Accountant" });
            }

            else if (iD == 4)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Laura", LastName = "Callahan", ID = 16, Salary = 900000, ReportsTo = 4, Title = "Sales Manager" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", ID = 17, Salary = 800000, ReportsTo = 4, Title = "Sales Representative" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", ID = 18, Salary = 750000, ReportsTo = 4, Title = "Sales Representative" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Tim", LastName = "Smith", ID = 19, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "Brid", ID = 20, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });
            }
            else if (iD == 5)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", ID = 21, Salary = 800000, ReportsTo = 5, Title = "Receptionist" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Xavier", LastName = "Martin", ID = 22, Salary = 700000, ReportsTo = 5, Title = "Mail Clerk" });
            }
            else if (iD == 6)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Laurent", LastName = "Pereira", ID = 23, Salary = 900000, ReportsTo = 6, Title = "HR Manager" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Syed", LastName = "Abbas", ID = 24, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", ID = 25, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });
            }
            else if (iD == 9)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Fuller", LastName = "DC", ID = 19, Salary = 1200000, ReportsTo = 9, Title = "Vice President" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Buchanan", LastName = "A", ID = 20, Salary = 1000000, ReportsTo = 9, Title = "GM" });
            }
            else if (iD == 10)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Sam", LastName = "WQ", ID = 21, Salary = 900000, ReportsTo = 10, Title = "Manager" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", ID = 22, Salary = 650000, ReportsTo = 10, Title = "Accountant" });
            }
            else if (iD == 11)
            {
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", ID = 23, Salary = 700000, ReportsTo = 11, Title = "Accountant" });
                employeeDetails.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", ID = 24, Salary = 700000, ReportsTo = 11, Title = "Accountant" });
            }

            Debug.WriteLine("## ThreadId = " + Environment.CurrentManagedThreadId + " End calling viewModel.GetEmployees(emp.ID) ##");

            return employeeDetails;
        }
    }


}
