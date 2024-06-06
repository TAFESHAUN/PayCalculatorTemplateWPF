using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace PayCalculatorTemplate
{
    public class PayCalculator
    {
        //METHODS for CLACUATION
        //TAX
        //GROSS
        //SUPER

        public double CalculateGrossPay(double hrsWorked, double hrlyRate)
        {
            double grossPay = hrsWorked * hrlyRate;
            return grossPay;
        }
        
        //METHOD FOR calculating tax
    }
}
