namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Provides functionality to detect whether the current process is in debug mode or not. 
    /// </summary>
    internal interface IDebugModeDetector
    {
        /// <summary>
        /// Detects whether the current process is in debug mode or not. 
        /// </summary>
        /// <returns>
        /// Returns true if the current process is in debug mode otherwise returns false.
        /// </returns>
        bool IsInDebugMode();
    }
}
