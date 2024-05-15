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
        public MainWindow()
        {
            InitializeComponent();
            
            //CHANGE THIS TO YOUR FILE HELEN
            var fileName = @"C:\Users\User\Source\Repos\PayCalculatorTemplateWPF\PayCalculatorTemplate\employee.csv";


            List<CsvMap> importedRecords = CsvImporter.ImportSomeRecords(fileName);

            empDataGrid.DataContext = importedRecords;
        }

        /// <summary>
        /// Calculate 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Calculate(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Save(object sender, RoutedEventArgs e)
        {

        }
    }
}
