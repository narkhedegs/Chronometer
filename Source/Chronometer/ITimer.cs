using System;

namespace Chronometer
{
    /// <summary>
    /// Provides a set of methods and properties that you can use to accurately measure elapsed time.
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// Gets the total elapsed time measured by the current instance.
        /// </summary>
        TimeSpan Elapsed { get; }

        /// <summary>
        /// Gets a value indicating whether the timer is running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Starts, or resumes, measuring elapsed time for an interval.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops measuring elapsed time for an interval.
        /// </summary>
        void Stop();

        /// <summary>
        /// Stops time interval measurement and resets the elapsed time to zero.
        /// </summary>
        void Reset();

        /// <summary>
        /// Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.  
        /// </summary>
        void Restart();
    }
}
