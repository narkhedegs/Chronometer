namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Options that can be passed to the <see cref="Chronometer"/> to change its behaviour.
    /// </summary>
    public class ChronometerOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="ChronometerOptions"/>. By default the NumberOfInterations is set 
        /// to 1.
        /// </summary>
        public ChronometerOptions()
        {
            NumberOfInterations = 1;
        }

        /// <summary>
        /// Number of times the code under test should be executed. This value must be greater than zero.
        /// </summary>
        public int? NumberOfInterations { get; set; }

        /// <summary>
        /// Decides whether the code under test should be executed once before starting the performance test to 
        /// ensure that it is compiled by JIT.
        /// </summary>
        public bool Warmup { get; set; }

        /// <summary>
        /// Decides whether the elapsed time should be calculated using normalized mean. NormalizedMean gives 
        /// you the mean of the timings discarding the noise. The deviation of each timing from the actual mean 
        /// is calculated and then the values which are farer (only the slower ones) from the mean of deviation 
        /// (called absolute deviation) are discarded and finally the mean of remaining values is returned. 
        /// For example if timed values are { 1, 2, 3, 2, 100 } in milliseconds, it discards 100, and returns 
        /// the mean of { 1, 2, 3, 2 } which is 2. Or if timings are { 240, 220, 200, 220, 220, 270 }, it 
        /// discards 270, and returns the mean of { 240, 220, 200, 220, 220 } which is 220.        
        /// </summary>
        public bool UseNormalizedMean { get; set; }

        /// <summary>
        /// Mesaures elapsed time using Process.GetCurrentProcess().TotalProcessorTime instead of 
        /// <see cref="System.Diagnostics.Stopwatch"/>
        /// </summary>
        public bool MeasureUsingProcessorTime { get; set; }

        /// <summary>
        /// Decides whether to allow measurements when the current process is being debugged or is compiled under DEBUG 
        /// configuration. By default this option is set to false to avoid wrong results.
        /// </summary>
        public bool AllowMeasurementsUnderDebugMode { get; set; }
    }
}
