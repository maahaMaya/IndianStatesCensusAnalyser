using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserSolution
{
    internal class CSVStateCensusDAO
    {
        public string SrNo { get; set; }
        public string StateName { get; set; }
        public string TIN { get; set; }
        public string StateCode { get; set; }
        public override string ToString() => $"SrNo:{SrNo}; StateName : {StateName}; TIN : {TIN}; StateCode : {StateCode}";
    }
}
