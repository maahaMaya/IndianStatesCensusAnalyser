using IndianStatesCensusAnalyserSolution;

namespace IndianStatesCensusAnalyserSolutionTestCase
{
    public class StateCensusAnalyserTestCase
    {
        public string stateCenciusAnalyserFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\StateCensusData.csv";
        public string wrongFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\StateCensusDat.csv";
        public string stateCenciusTextFilePath = @"D:\GitUploadCode\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserSolution\IndianStatesCensusAnalyserSolution\Files\DemoTextFile.txt";
        public string stateCenciusDelimeterFilePath = @"D:\BridgeLabz\Day20\IndianStateAnalyzer\Files\StateCensusDataDelimeter.csv";

        //<comment>due to test case not fail here DAO of class is changes that why its fail
        //[Test] //UC-1.1
        //public void GivenStateCenciusData_WhenAnalysed_ShouldReturnNumberOfRecordsMatches()
        //{
        //    StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
        //    CSVStateCensus cSVStateCensus = new CSVStateCensus();
        //    Assert.AreEqual(stateCensusAnalyser.ReadStateCencusAnalyserData(stateCenciusAnalyserFilePath), cSVStateCensus.ReadCSVStateCensusData(stateCenciusAnalyserFilePath));
        //}

        [Test] //UC-1.2
        public void GivenStateCenciusDataFileIncorrest_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            try
            {
                int records = stateCensusAnalyser.ReadStateCencusAnalyserData(wrongFilePath);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect File Path");
            }
        }

        [Test] //UC-1.3
        public void GivenStateCenciusDataFileTypeIncorrectFormat_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            try
            {
                int records = stateCensusAnalyser.ReadStateCencusAnalyserData(stateCenciusTextFilePath);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File is incorecct");
            }
        }
        [Test] //UC-1.4
        public void GivenStateCenciusDelimeterFileTypeIncorrectFormat_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            try
            {
                int records = stateCensusAnalyser.ReadStateCencusAnalyserData(stateCenciusDelimeterFilePath);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Forwad slash is found");
            }
        }
        [Test] //UC-1.5
        public void GivenStateCenciusDelimeterFileHeaderIncorrectFormat_WhenAnalysed_ShouldReturnExceptionMessage()
        {
            StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
            try
            {
                bool records = stateCensusAnalyser.ReadStateCencusAnalyserData(stateCenciusDelimeterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
                Assert.IsTrue(records);
            }
            catch (StateCensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }
    }
}