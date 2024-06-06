using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculatorTemplate
{
    public class Payslip
    {
        //THIS AN OBJECT that HOLDS the payslip info
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmployeeType{ get; set; }
        public string? taxThreshold {  get; set; }
        public double grossPay {  get; set; }
        public double tax {  get; set; }

        public double super {  get; set; }
    }
}
