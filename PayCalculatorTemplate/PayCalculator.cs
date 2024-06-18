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

        //Payslip PayslipToGenerate {  get; set; }

        //public PayCalculator(Payslip generatedPayslip) { 
        //    PayslipToGenerate = generatedPayslip;
        //}

        //METHOD FOR calculating tax
        public double Calculate_Gross_Pay(double hoursWrkd, double hrlyRate)
        {
            return hrlyRate * hoursWrkd;
        }

        public double Calculate_Super()
        {
            return 0;//NEEDS SETUP
        }
    }
}
