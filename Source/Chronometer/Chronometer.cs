using System;
using System.Collections.Generic;
using System.Linq;

namespace Narkhedegs.PerformanceMeasurement
{
    /// <summary>
    /// Provides a set of methods that you can use to accurately measure the execution time for the code under test.
    /// </summary>
    public class Chronometer : IChronometer
    {
        private readonly INormalizedMeanCalculator _normalizedMeanCalculator;
        private readonly ITimerFactory _timerFactory;
        private readonly IMemoryOptimizer _memoryOptimizer;
        private readonly IPerformanceOptimizer _performanceOptimizer;
        private readonly IDebugModeDetector _debugModeDetector;

        /// <summary>
        /// Options that can be passed to the <see cref="Chronometer"/> to change its behaviour.
        /// </summary>
        public ChronometerOptions Options { get; private set; }

        /// <summary>
        /// Initializes a new instance of Chronometer with default options. 
        ///     By default - 
        ///         NumberOfInterations                 = 1
        ///         Warmup                              = false
        ///         UseNormalizedMean                   = false
        ///         MeasureUsingProcessorTime           = false
        ///         AllowMeasurementsUnderDebugMode     = false
        /// </summary>
        public Chronometer() : this(new ChronometerOptions
        {
            NumberOfInterations = 1,
            Warmup = false,
            UseNormalizedMean = false,
            MeasureUsingProcessorTime = false,
            AllowMeasurementsUnderDebugMode = false
        })
        {
        }

        /// <summary>
        /// Initializes a new instance of Chronometer with the given options.
        /// </summary>
        /// <param name="options"><see cref="ChronometerOptions"/></param>
        public Chronometer(ChronometerOptions options)
            : this(
                options, new NormalizedMeanCalculator(), new TimerFactory(), new MemoryOptimizer(),
                new PerformanceOptimizer(), new DebugModeDetector())
        {
        }

        /// <summary>
        /// Internal constructor for Chronometer. Initializes a new instance of Chronometer with the given options.
        /// </summary>
        /// <param name="options"><see cref="ChronometerOptions"/></param>
        /// <param name="normalizedMeanCalculator">Implementation of <see cref="INormalizedMeanCalculator"/></param>
        /// <param name="timerFactory">Implementation of <see cref="ITimerFactory"/></param>
        /// <param name="memoryOptimizer">Implementation of <see cref="IMemoryOptimizer"/></param>
        /// <param name="performanceOptimizer">Implementation of <see cref="IPerformanceOptimizer"/></param>
        /// <param name="debugModeDetector">Implementation of <see cref="IDebugModeDetector"/></param>
        internal Chronometer(
            ChronometerOptions options, 
            INormalizedMeanCalculator normalizedMeanCalculator,
            ITimerFactory timerFactory,
            IMemoryOptimizer memoryOptimizer,
            IPerformanceOptimizer performanceOptimizer,
            IDebugModeDetector debugModeDetector)
        {
            if(options == null)
                throw new ArgumentNullException("options");

            if(options.NumberOfInterations == null)
                throw new ArgumentException(Properties.Resources.NumberOfIterationsLessThan1ExceptionMessage, "options");

            if(options.NumberOfInterations.HasValue && options.NumberOfInterations.Value < 1)
                throw new ArgumentException(Properties.Resources.NumberOfIterationsLessThan1ExceptionMessage, "options");

            if(normalizedMeanCalculator == null)
                throw new ArgumentNullException("normalizedMeanCalculator");            
            
            if(timerFactory == null)
                throw new ArgumentNullException("timerFactory");

            if (memoryOptimizer == null)
                throw new ArgumentNullException("memoryOptimizer");

            if (performanceOptimizer == null)
                throw new ArgumentNullException("performanceOptimizer");

            if (debugModeDetector == null)
                throw new ArgumentNullException("debugModeDetector");

            Options = options;
            _normalizedMeanCalculator = normalizedMeanCalculator;
            _timerFactory = timerFactory;
            _memoryOptimizer = memoryOptimizer;
            _performanceOptimizer = performanceOptimizer;
            _debugModeDetector = debugModeDetector;
        }

        /// <summary>
        /// Mesaures the execution time for the code under test.
        /// </summary>
        /// <param name="action">Code under test for which you want to measure the execution time.</param>
        /// <param name="numberOfIterations">
        /// Number of times the code under test should be executed. If this value is not null then it overrides 
        /// the value provided using <see cref="ChronometerOptions"/>.
        /// </param>
        /// <returns>
        /// Returns average elapsed time in milliseconds. If UseNormalizedMean property of 
        /// <see cref="ChronometerOptions"/> is set then returns the normalized elapsed time in milliseconds.
        /// </returns>
        public double Measure(Action action, int? numberOfIterations = null)
        {
            if(!Options.AllowMeasurementsUnderDebugMode && _debugModeDetector.IsInDebugMode())
                throw new InvalidOperationException(
                    "Under the current Chronometer configuration, measurements are not allowed when the process is in debug mode. Please set AllowMeasurementsUnderDebugMode chronometer option to true if you would like measurements when the process is under debug mode.");

            if (action == null)
                throw new ArgumentNullException("action");

            if (numberOfIterations.HasValue && numberOfIterations.Value < 1)
                throw new ArgumentException(Properties.Resources.NumberOfIterationsLessThan1ExceptionMessage,
                    "numberOfIterations");

            _memoryOptimizer.Optimize();

            _performanceOptimizer.Optimize();

            //Warm up
            if (Options.Warmup)
            {
                action();
            }

            var timer = _timerFactory.Create(Options);
            numberOfIterations = numberOfIterations ?? Options.NumberOfInterations;
            var timings = new List<double>();
            for (var i = 0; i < numberOfIterations; i++)
            {
                timer.Restart();
                action();
                timer.Stop();

                timings.Add(timer.Elapsed.TotalMilliseconds);
            }

            _performanceOptimizer.Revert();

            return Options.UseNormalizedMean ? _normalizedMeanCalculator.Calculate(timings) : timings.Average();
        }
    }
}
