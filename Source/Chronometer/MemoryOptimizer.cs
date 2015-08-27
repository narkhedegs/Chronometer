using System;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Provides methods to optimize memory of the current process.
    /// </summary>
    internal class MemoryOptimizer : IMemoryOptimizer
    {
        /// <summary>
        /// Optimizes the memory of the current process by forcing a garbage collection.
        /// </summary>
        public void Optimize()
        {
            //Clean garbage.
            GC.Collect();

            //Wait for the finalizer queue to empty.
            GC.WaitForPendingFinalizers();

            //Clean Garbage.
            GC.Collect();
        }
    }
}
