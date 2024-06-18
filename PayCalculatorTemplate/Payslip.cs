using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayCalculatorTemplate
{
    public class Payslip
    {
        //Get set when you make a payslip object
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? EmployeeType{ get; set; }

        public double HourlyRate { get; set; }
        public string? TaxThreshold {  get; set; }

        //Hours Entered
        public double HoursEntered { get; set; }

        //Manually set later
        public double GrossPay {  get; set; } 
        public double NetPay {  get; set; }
        public double Tax {  get; set; }
        public double Super {  get; set; }

        //Constructor here:
        //Fancy function thats only called when you make an INSTANCE of the object
        public Payslip(int id, string name, string empType, double hrlyRate, string taxThr)
        { 
            Id = id;
            FullName = name;
            EmployeeType = empType;
            HourlyRate = hrlyRate;
            TaxThreshold = taxThr;
        }


        public string Get_All_Payslip_Details()
        {
            //csv format - NOT DONE
            return $"{Id},{FullName},";
        }
    }
}
