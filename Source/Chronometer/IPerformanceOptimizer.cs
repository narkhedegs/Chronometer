namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Creates a timeframe during which the performance of the current process is optimized by various ways. For example 
    /// the performance of the current process is optimized by reducing the probability that the Garbage Collector runs.
    /// </summary>
    internal interface IPerformanceOptimizer
    {
        /// <summary>
        /// Creates a timeframe during during which the performance of the current process is optimized.
        /// </summary>
        void Optimize();

        /// <summary>
        /// Reverts back all the optimizations done by <see cref="IPerformanceOptimizer"/>.
        /// </summary>
        void Revert();
    }
}
