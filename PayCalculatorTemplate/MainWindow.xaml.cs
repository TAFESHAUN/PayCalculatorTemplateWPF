using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayCalculatorTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*
        * Object that I will set the value to the current
        * selected employee record in my datagrid
        */
        public CsvEmployee selectedEmployee;
        
        /// <summary>
        /// XML is for pascal and up OR methods, classes, interface etc
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            var fileName = @"C:\Users\User\source\repos\PayCalculatorTemplateWPF\PayCalculatorTemplate\employee.csv";


            List<CsvEmployee> importedRecords = CsvImporter.ImportSomeRecords(fileName);

            empDataGrid.DataContext = importedRecords;

            selectedEmployee = new CsvEmployee();
            selectedEmployee.employeeID = -1;//Change to null or empty BUT -1 is good enough for now
        }



        /// <summary>
        /// Calculate 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            //This is just to show a msg if you selected an employee
            if (selectedEmployee.employeeID != -1)
            {
                MessageBox.Show($"You selected:{selectedEmployee.firstName} Tax:{selectedEmployee.taxthreshold}");
                //Pass object info over, Pass over the actual object etc
                //Payslip and Pay Calculator
            }
            else
            {
                MessageBox.Show("Please select an employee");
            }
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Save(object sender, RoutedEventArgs e)
        {

        }

        private void empDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = empDataGrid.SelectedItem as CsvEmployee; //As a record in my Grid
        }
    }
}
