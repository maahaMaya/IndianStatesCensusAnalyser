using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserSolution
{
    public class StateCensusAnalyser
    {
        public int ReadStateCencusAnalyserData(string filePath)
        {
            //UC-1.2
            if (!File.Exists(filePath))
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            //UC-1.3
            if (!filePath.EndsWith(".csv"))
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.TYPE_INCORRECT, "File is incorecct");
            //UC-1.4
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.DELIMETER, "Forwad slash is found");
            //UC-1.1
            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<StateCensusAnalyserDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count - 1;
            }
        }
        //UC-1.5
        public bool ReadStateCencusAnalyserData(string filePath, string actualHeader)
        {
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Equals(actualHeader))
                return true;
            else
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.HEADER_INCORRECT, "Incorrect Header");
        }
    }
}
