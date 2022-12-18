using IndianStatesCensusAnalyserSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserSolutionTestCase
{
    internal class CSVStateCensusTestCase
    {
        public string stateCodeFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\StateCode.csv";
        public string wrongFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\DemoTextFile.csv";
        public string textFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\DemoTextFile.txt";
        public string stateCodeDelimeterFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\StateCodeDelimeter.csv";

        [Test] //UC-2.1
        public void GivenStateCodeData_WhenAnalysed_ShouldReturnNumberOfRecordsMatches()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            Assert.AreEqual(stateCensusAnalyser.ReadStateCencusAnalyserData(stateCodeFilePath), cSVStateCensus.ReadCSVStateCensusData(stateCodeFilePath));
        }

        [Test] //UC-2.2
        public void GivenStateCodeDataFileLocationIncorrect_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            try
            {
                int records = cSVStateCensus.ReadCSVStateCensusData(wrongFilePath);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Path");
            }
        }

        [Test] //UC-2.3
        public void GivenStateCodeFileTypeIncorrectFormat_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            try
            {
                int records = cSVStateCensus.ReadCSVStateCensusData(textFilePath);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File is incorecct");
            }
        }
        [Test] //UC-2.4
        public void GivenStateCodeDelimeterFileTypeIncorrectFormat_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            try
            {
                int records = cSVStateCensus.ReadCSVStateCensusData(stateCodeDelimeterFilePath);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Forwad slash is found");
            }
        }
        [Test] //UC-2.5
        public void GivenStateCodeDelimeterFileHeaderIncorrectFormat_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            try
            {
                bool records = cSVStateCensus.ReadCSVStateCensusData(stateCodeDelimeterFilePath, "SrNo,StateName,TIN,StateCode");
                Assert.IsTrue(records);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }
    }
}
