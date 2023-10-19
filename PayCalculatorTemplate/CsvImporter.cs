using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculatorTemplate
{
    public class CsvImporter
    {
        public static List<CsvMap> ImportSomeRecords(string fileName)
        {
            var myRecords = new List<CsvMap>();
            using (var reader = new StreamReader(fileName))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvMapMap>();


                    int employeeID;
                    string firstName;
                    string lastName;
                    string typeEmployee;
                    int hourlyRate;
                    string taxthreshold;

                    //Start Reading Csv File
                    //csv.Read();
                    //Skip Header
                    //csv.ReadHeader();

                    while (csv.Read())
                    {
                        employeeID = csv.GetField<int>(0);
                        firstName = csv.GetField<string>(1);
                        lastName = csv.GetField<string>(2);
                        typeEmployee = csv.GetField<string>(3);
                        hourlyRate = csv.GetField<int>(4);
                        taxthreshold = csv.GetField<string>(5);
                        myRecords.Add(CreateRecord(employeeID, firstName, lastName, typeEmployee, hourlyRate, taxthreshold));

                    }

                }

            }
            return myRecords;
        }

        public static CsvMap CreateRecord(int employeeID, string firstName, string lastName, string typeEmployee, int hourlyRate, string taxthreshold)
        {
            CsvMap record = new CsvMap();

            record.employeeID = employeeID;
            record.firstName = firstName;
            record.lastName = lastName;
            record.typeEmployee = typeEmployee;
            record.hourlyRate = hourlyRate;
            record.taxthreshold = taxthreshold;

            return record;
        }
    }

    public class CsvMap
    {
        public int employeeID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string typeEmployee { get; set; }
        public int hourlyRate { get; set; }
        public string taxthreshold { get; set; }
    }

    public sealed class CsvMapMap : ClassMap<CsvMap>
    {
        public CsvMapMap()
        {
            Map(m => m.employeeID).Index(0);
            Map(m => m.firstName).Index(1);
            Map(m => m.lastName).Index(2);
            Map(m => m.typeEmployee).Index(3);
            Map(m => m.hourlyRate).Index(4);
            Map(m => m.taxthreshold).Index(5);
        }
    }
}
