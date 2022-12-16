using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserSolution
{
    public class StateCensusAnalyserDAO
    {
        public string State { get; set; }
        public string Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }
        public override string ToString() => $"State:{State}; Population : {Population}; AreaInSqKm : {AreaInSqKm}; DensityPerSqKm : {DensityPerSqKm}";
    }
}
