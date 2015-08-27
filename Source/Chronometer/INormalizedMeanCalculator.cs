using System;
using System.Collections.Generic;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Provides a set of methods to calculate a normalized mean for given collection of double values.
    /// </summary>
    internal interface INormalizedMeanCalculator
    {
        /// <summary>
        /// NormalizedMean gives you the mean of the values discarding the noise. The deviation of each value 
        /// from the actual mean is calculated and then the values which are farer from the mean of deviation 
        /// (called absolute deviation) are discarded and finally the mean of remaining values is returned. 
        /// For example if values are { 1, 2, 3, 2, 100 } in milliseconds, it discards 100, and returns 
        /// the mean of { 1, 2, 3, 2 } which is 2. Or if timings are { 240, 220, 200, 220, 220, 270 }, it 
        /// discards 270, and returns the mean of { 240, 220, 200, 220, 220 } which is 220. 
        /// </summary>
        /// <param name="values">Collection of double values</param>
        /// <returns>NormalizedMean for the given collection of double values</returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if values parameter is null</exception>
        double Calculate(IEnumerable<double> values);
    }
}
