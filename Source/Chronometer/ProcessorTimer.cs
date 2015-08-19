using System;
using System.Diagnostics;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Implements <see cref="ITimer"/> by measuring Process.GetCurrentProcess().TotalProcessorTime.
    /// </summary>
    public class ProcessorTimer : ITimer
    {
        private bool _isRunning;
        private TimeSpan _startTime;
        private TimeSpan _endTime;

        /// <summary>
        /// Gets the total elapsed time measured by the current instance.
        /// </summary>
        public TimeSpan Elapsed
        {
            get
            {
                if (IsRunning)
                    throw new NotSupportedException("Getting elapsed time while timer is running is not supported.");

                return _endTime - _startTime;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the timer is running.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            } 
        }

        /// <summary>
        /// Starts, or resumes, measuring elapsed time for an interval.
        /// </summary>
        public void Start()
        {
            _startTime = Process.GetCurrentProcess().TotalProcessorTime;
            _isRunning = true;
        }

        /// <summary>
        /// Stops measuring elapsed time for an interval.
        /// </summary>
        public void Stop()
        {
            _endTime = Process.GetCurrentProcess().TotalProcessorTime;
            _isRunning = false;
        }

        /// <summary>
        /// Stops time interval measurement and resets the elapsed time to zero.
        /// </summary>
        public void Reset()
        {
            _startTime = TimeSpan.Zero;
            _endTime = TimeSpan.Zero;
        }

        /// <summary>
        /// Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.  
        /// </summary>
        public void Restart()
        {
            Stop();
            Reset();
            Start();
        }
    }
}
