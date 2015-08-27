using System.Diagnostics;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Provides functionality to detect whether the current process is in debug mode or not. 
    /// </summary>
    internal class DebugModeDetector : IDebugModeDetector
    {
        /// <summary>
        /// Detects whether the current process is in debug mode or not. 
        /// </summary>
        /// <returns>
        /// Returns true if the current process is in debug mode otherwise returns false.
        /// </returns>
        public bool IsInDebugMode()
        {
            return IsBeingDebugged || IsCompiledUnderDebugConfiguration;
        }

        /// <summary>
        /// Indicates whether the current process is being debugged.
        /// </summary>
        private bool IsBeingDebugged
        {
            get
            {
                return Debugger.IsAttached;
            }
        }
        
        /// <summary>
        /// Indicates whether the current process is compiled under DEBUG configuration.
        /// </summary>
        private bool IsCompiledUnderDebugConfiguration
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
}
