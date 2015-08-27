using System.Runtime;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Creates a timeframe during which the performance of the current process is optimized by reducing the probability 
    /// that the Garbage Collector runs.
    /// </summary>
    internal class PerformanceOptimizer : IPerformanceOptimizer
    {
        /// <summary>
        /// The latency mode of the Garbage Collector before this object changes it.
        /// </summary>
        protected GCLatencyMode OldGarbageCollectorLatencyMode;

        /// <summary>
        /// Indicates whether the <see cref="PerformanceOptimizer"/> has performed optimizations for the current process 
        /// or not.
        /// </summary>
        protected bool IsOptimized;

        /// <summary>
        /// Frees resources and performs other cleanup operations before it is reclaimed by garbage collection. 
        /// </summary>
        ~PerformanceOptimizer()
        {
            // If the optimizations were never reverted back
            if (IsOptimized)
            {
                Revert();
            }
        }

        /// <summary>
        /// Creates a timeframe during during which the performance of the current process is optimized.
        /// </summary>
        /// <remarks>
        /// Why use SustainedLowLatency instead of LowLatency: http://www.infoq.com/news/2012/03/Net-403.
        /// </remarks>
        public void Optimize()
        {
            IsOptimized = true;

            OldGarbageCollectorLatencyMode = GCSettings.LatencyMode;

            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        }

        /// <summary>
        /// Reverts back all the optimizations done by <see cref="PerformanceOptimizer"/>.
        /// </summary>
        public void Revert()
        {
            IsOptimized = false;

            GCSettings.LatencyMode = OldGarbageCollectorLatencyMode;
        }
    }
}
