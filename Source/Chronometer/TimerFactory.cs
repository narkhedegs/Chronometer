using System;

namespace Chronometer
{
    /// <summary>
    /// Factory for Timers <see cref="ITimer"/>
    /// </summary>
    internal class TimerFactory : ITimerFactory
    {
        /// <summary>
        /// Instantiates and returns correct timer based on the <see cref="ChronometerOptions"/>. If value of 
        /// ChronometerOptions.MeasureUsingProcessorTime is true then returns <see cref="ProcessorTimer"/> otherwise 
        /// returns <see cref="StopwatchTimer"/>.
        /// </summary>
        /// <param name="options"><see cref="ChronometerOptions"/></param>
        /// <returns>Implementation of <see cref="ITimer"/></returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if options parameter is null.</exception>
        public ITimer Create(ChronometerOptions options)
        {
            if(options == null)
                throw new ArgumentNullException("options");

            ITimer timer;

            if (options.MeasureUsingProcessorTime)
            {
                timer = new ProcessorTimer();
            }
            else
            {
                timer = new StopwatchTimer();
            }

            return timer;
        }
    }
}
