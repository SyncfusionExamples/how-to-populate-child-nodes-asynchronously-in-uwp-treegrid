using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnDemandLoading
{
    public class EmployeeInfo: INotifyPropertyChanged
    {
        int _id;
        string _firstName;
        string _lastName;
        private string _title;
        double? _salary;
        int _reportsTo;
      
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public double? Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public int ReportsTo
        {
            get { return _reportsTo; }
            set { _reportsTo = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}
