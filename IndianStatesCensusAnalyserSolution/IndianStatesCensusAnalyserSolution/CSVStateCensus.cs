using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserSolution
{
    public class CSVStateCensus
    {
        public int ReadCSVStateCensusData(string filePath)
        {
            //UC-2.2
            if (!File.Exists(filePath))
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.FILE_INCORRECT, "Incorrect File Path");
            //UC-2.3
            if (!filePath.EndsWith(".csv"))
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.TYPE_INCORRECT, "File is incorecct");
            //UC-2.4
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.DELIMETER, "Forwad slash is found");
            //UC-2.1
            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<CSVStateCensusDAO>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                }
                return records.Count - 1;
            }
        }
        //UC-1.5
        public bool ReadCSVStateCensusData(string filePath, string actualHeader)
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
