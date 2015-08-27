using System;
using System.Diagnostics;
using System.Threading;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Implements <see cref="ITimer"/> using <see cref="System.Diagnostics.Stopwatch"/>.
    /// </summary>
    internal class StopwatchTimer : ITimer
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// Gets the total elapsed time measured by the current instance.
        /// </summary>
        public TimeSpan Elapsed {
            get
            {
                return _stopwatch.Elapsed;
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the Stopwatch timer is running.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return _stopwatch.IsRunning;
            } 
        }

        /// <summary>
        /// Initializes a new instance of StopwatchTimer. Uses the second Core/Processor for the test. Prevents 
        /// normal processes from interrupting threads. Prevents normal threads from interrupting this thread.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws NotSupportedException if the hardware doesn't support high resolution counter. 
        /// </exception>
        public StopwatchTimer()
        {
            if (!Stopwatch.IsHighResolution)
                throw new NotSupportedException("Your hardware doesn't support high resolution counter.");

            //Use the second Core/Processor for the test.
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);

            //Prevent "Normal" processes from interrupting threads.
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            //Prevent "Normal" threads from interrupting this thread.
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }

        /// <summary>
        /// Starts, or resumes, measuring elapsed time for an interval.
        /// </summary>
        public void Start()
        {
            _stopwatch.Start();
        }

        /// <summary>
        /// Stops measuring elapsed time for an interval.
        /// </summary>
        public void Stop()
        {
            _stopwatch.Stop();
        }

        /// <summary>
        /// Stops time interval measurement and resets the elapsed time to zero.
        /// </summary>
        public void Reset()
        {
            _stopwatch.Reset();
        }

        /// <summary>
        /// Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.  
        /// </summary>
        public void Restart()
        {
            _stopwatch.Restart();
        }
    }
}
