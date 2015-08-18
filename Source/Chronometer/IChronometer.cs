using System;

namespace Chronometer
{
    /// <summary>
    /// Provides a set of methods that you can use to accurately measure the execution time for the code under test.
    /// </summary>
    public interface IChronometer
    {
        /// <summary>
        /// Options that can be passed to the <see cref="Chronometer"/> to change its behaviour.
        /// </summary>
        ChronometerOptions Options { get; }

        /// <summary>
        /// Mesaures the execution time for the code under test.
        /// </summary>
        /// <param name="action">Code under test for which you want to measure the execution time.</param>
        /// <param name="numberOfIterations">
        /// Number of times the code under test should be executed. If this value is not null then it overrides 
        /// the value provided using <see cref="ChronometerOptions"/>.
        /// </param>
        /// <returns>
        /// Returns average elapsed time in milliseconds. If UseNormalizedMean property of 
        /// <see cref="ChronometerOptions"/> is set then returns the normalized elapsed time in milliseconds.
        /// </returns>
        double Measure(Action action, int? numberOfIterations = null);
    }
}
