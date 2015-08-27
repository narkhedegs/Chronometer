### New in 0.0.3 (Released 2015/08/27)
* Re-factor Chronometer class to move memory optimization functionality into its own class
* Re-factor Chronometer class to move performance optimization functionality into its own class
* Add functionality to detect debug mode and prevent measurement under debug mode by default
* Add AllowMeasurementsUnderDebugMode option to ChronometerOptions to override the default behaviour in debug mode

### New in 0.0.2 (Released 2015/08/19)
* Change NuGet package id to Narkhedegs.Chronometer

### New in 0.0.1 (Released 2015/08/19)
* First release of Chronometer
* Option to measure execution time of code under test using Stopwatch or using TotalProcessorTime
* Measure the execution time by running the code under test for user defined number of iterations
* Option to measure the execution time as average of all the iterations or as normalized mean of the iterations
* Option to perform warmup (JIT Compilation) before performance test