using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using TrainingApplication.Core;
using System.Windows.Input;

namespace TrainingApplication.ViewModels
{
    public class EmployeesViewModel
    {
        private Employee itemSelected;

        public ObservableCollection<Employee> Employees { get; set; }

        public Employee ItemSelected
        {
            get
            {
                return itemSelected;
            }
                
            set
            {
                this.itemSelected = value;
                MessageBox.Show(string.Format("The Employee selected is {0} {1}", this.itemSelected.FirstName, this.itemSelected.LastName));
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Age { get; set; }



        public ICommand AddEmployee { get; set; }

        public EmployeesViewModel()
        {
            this.Employees = new ObservableCollection<Employee>();
            this.AddEmployee = new RelayCommand((parameter) => 
            { 
                this.Employees.Add(new Employee(this.FirstName, this.LastName, int.Parse(this.Age))); 
            });
            PopulateStaticData();
        }

        private void PopulateStaticData()
        {
            for (int index = 0; index < 1000; index++)
            {
                this.Employees.Add(new Employee("John" + index, "Doe" + index, index));
            }
        }
    }
}
