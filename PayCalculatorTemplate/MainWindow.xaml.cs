using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public Payslip savedPayslip;
        
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
            //Grabs the hours as int so that we can do the math
            var hoursEntered = Convert.ToDouble(hrsWrkEntry.Text);

            //This is just to show a msg if you selected an employee
            if (selectedEmployee.employeeID != -1)
            {
                //Grab first and last name as a full name
                string fullName = $"{selectedEmployee.firstName} {selectedEmployee.lastName}";
                //Set up the payslip data we know we have
                //I.E grab the row data from the datagrid
                Payslip paySlip = new Payslip(selectedEmployee.employeeID, 
                                            fullName, selectedEmployee.typeEmployee, 
                                            selectedEmployee.hourlyRate, 
                                            selectedEmployee.taxthreshold);

                paySlip.HoursEntered = hoursEntered;

                //MANUAL INFO HERE
                PayCalculator payCalculator = new PayCalculator();

                paySlip.GrossPay = payCalculator.Calculate_Gross_Pay(paySlip.HoursEntered, paySlip.HourlyRate);
                paySlip.Super = payCalculator.Calculate_Super();

               
                //MessageBox.Show($"Payslip Gross Pay is {paySlip.GrossPay}");
                PaySummary.Text = $"Payslip information: " +
                                  $"\n Id: {paySlip.Id} " +
                                  $"\n Name: {paySlip.FullName} " +
                                  $"\n Job Title: {paySlip.EmployeeType} " +
                                  $"\n Gross Pay: {paySlip.GrossPay}" +
                                  $"\n Net Pay: {paySlip.NetPay}" +
                                  $"\n Super: {paySlip.Super}"; 

                savedPayslip = paySlip;
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
            //EXPORT CSV FUNCTION
            MessageBox.Show($"The global payslip is : {savedPayslip.Id}");
            savedPayslip.Get_All_Payslip_Details();

            MessageBox.Show($"The global payslip hours entered are: {savedPayslip.HoursEntered}");

            if (savedPayslip != null)
            {
                string filePath = @"YOUR FILE PATH";

                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecord(savedPayslip);
                    writer.WriteLine(); // Add this line to ensure the record is written.
                }

                MessageBox.Show($"Payslip saved to {filePath}");
            }
            else
            {
                MessageBox.Show("No payslip to save");
            }

        }

        private void empDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = empDataGrid.SelectedItem as CsvEmployee; //As a record in my Grid
            //MessageBox.Show($"You picked {selectedEmployee.firstName}");
        }
    }
}


//MessageBox.Show($"Payslip information: " +
//                      $"\n Id: {savedPayslip.Id} " +
//                      $"\n Name: {savedPayslip.FullName} " +
//                      $"\n Job Title: {savedPayslip.EmployeeType} " +
//                      $"\n Gross Pay: {savedPayslip.GrossPay}" +
//                      $"\n Net Pay: {savedPayslip.NetPay}" +
//                      $"\n Super: {savedPayslip.Super}");