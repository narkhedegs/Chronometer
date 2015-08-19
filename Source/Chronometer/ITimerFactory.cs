using System;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Factory for Timers <see cref="ITimer"/>
    /// </summary>
    internal interface ITimerFactory
    {
        /// <summary>
        /// Instantiates and returns correct timer based on the <see cref="ChronometerOptions"/>. If value of 
        /// ChronometerOptions.MeasureUsingProcessorTime is true then returns <see cref="ProcessorTimer"/> otherwise 
        /// returns <see cref="StopwatchTimer"/>.
        /// </summary>
        /// <param name="options"><see cref="ChronometerOptions"/></param>
        /// <returns>Implementation of <see cref="ITimer"/></returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if options parameter is null.</exception> 
        ITimer Create(ChronometerOptions options);
    }
}
