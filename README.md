[![Build status](https://ci.appveyor.com/api/projects/status/3nh27cqep75s2pju?svg=true)](https://ci.appveyor.com/project/narkhedegs/chronometer)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/narkhedegs/Chronometer?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
# Chronometer
Chronometer is a small C# time measurement library which can be used for performance testing.

# Features
* Option to measure execution time of code under test using Stopwatch or using TotalProcessorTime.
* Measure the execution time by running the code under test for user defined number of iterations.
* Option to measure the execution time as average of all the iterations or as normalized mean of the iterations.
* Option to perform warmup (JIT Compilation) before performance test.
* Minimizes risk of incorrect measurement of execution time by preventing measurements when the current process is under debug mode

# Installation
Chronometer is available at [Nuget](https://www.nuget.org/packages/Narkhedegs.Chronometer/) and can be installed as a package using VisualStudio NuGet package manager or via the NuGet command line:
> Install-Package Narkhedegs.Chronometer

# Quick Start
Add an using statement for Narkhedegs.PerformanceMeasurement.
```cs
using Narkhedegs.PerformanceMeasurement;
```
Create an instance of Chronometer and use Measure method to measure the execution time of code under test. Measure method accepts Action Delegate as its first parameter. 
```cs
var chronometer = new Chronometer();
var executionTimeInMilliseconds = chronometer.Measure(CodeUnderTest);
```
By default Chronometer (check out [Chronometer Options](#chronometer-options)) - 
 - only executes the code under test once
 - doesn't perform warmup
 - returns the average of execution time across all the iterations
 - uses System.Diagnostics.StopWatch for measuring the execution time

# Advance Usage
We can change the behaviour of Chronometer by using the overloaded constructor that accepts ChronometerOptions.
```cs
var chronometer = new Chronometer(new ChronometerOptions
{
    NumberOfInterations = 5,
    Warmup = true,
    MeasureUsingProcessorTime = true,
    UseNormalizedMean = true,
    AllowMeasurementsUnderDebugMode = true
});

var executionTimeInMilliseconds = chronometer.Measure(CodeUnderTest);
```
NumberOfIterations can be overwritten by using the overload of Measure method that accepts numberOfIterations parameter.
```cs
var executionTimeInMilliseconds = chronometer.Measure(CodeUnderTest, 10);
```
# Chronometer Options
| Tables        | Type | Description | Default Value |
|:------------- |:------------|:-------------|:-------------| 
| NumberOfInterations      | int? | Number of times the code under test should be executed. This value must be greater than zero. | 1 | 
| Warmup      | bool | If true runs the code under test once before starting the performance test to ensure that it is compiled by JIT.      | false |
| UseNormalizedMean | bool | NormalizedMean gives you the mean of the values discarding the noise. The deviation of each value from the actual mean is calculated and then the values which are farer from the mean of deviation (called absolute deviation) are discarded and finally the mean of remaining values is returned. For example if values are { 1, 2, 3, 2, 100 } in milliseconds, it discards 100, and returns the mean of { 1, 2, 3, 2 } which is 2. Or if timings are { 240, 220, 200, 220, 220, 270 }, it discards 270, and returns the mean of { 240, 220, 200, 220, 220 } which is 220.      | false |
| MeasureUsingProcessorTime      | bool | Mesaures elapsed time using Process.GetCurrentProcess().TotalProcessorTime instead of System.Diagnostics.Stopwatch. | false |
| AllowMeasurementsUnderDebugMode | bool | Decides whether to allow measurements when the current process is being debugged or is compiled under DEBUG configuration. By default this option is set to false to avoid wrong results. | false |

# Reference
* Thanks to [nawfal](http://stackoverflow.com/a/16157458). This code is basically his stack overflow answer wrapped into NuGet package. 
* [Precise time measurement in .NET](http://www.codeproject.com/Articles/61964/Performance-Tests-Precise-Run-Time-Measurements-wi)