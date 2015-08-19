[![Build status](https://ci.appveyor.com/api/projects/status/3nh27cqep75s2pju?svg=true)](https://ci.appveyor.com/project/narkhedegs/chronometer)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/narkhedegs/Chronometer?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
# Chronometer
Chronometer is a small C# time measurement library which can be used for performance testing.
* Option to measure execution time of code under test using Stopwatch or using TotalProcessorTime.
* Measure the execution time by running the code under test for user defined number of iterations.
* Option to measure the execution time as average of all the iterations or as normalized mean of the iterations.
* Option to perform warmup (JIT Compilation) before performance test.

# Installation
Chronometer is available at Nuget.org and can be installed as a package using VisualStudio NuGet package manager or via the NuGet command line:
> Install-Package Chronometer

# Usage
Add an using statement for Narkhedegs.PerformanceMeasurement.
```cs
using Narkhedegs.PerformanceMeasurement;
```
Create an instance of Chronometer and use Measure method to measure the execution time of code under test. Measure method accepts Action Delegate as its first parameter. 
```cs
var chronometer = new Chronometer();
var executionTimeInMilliseconds = chronometer.Measure(CodeUnderTest);
```
We can change the behaviour of Chronometer by using the overloaded constructor that accepts ChronometerOptions.
```cs
var chronometer = new Chronometer(new ChronometerOptions
{
    NumberOfInterations = 5,
    Warmup = true,
    MeasureUsingProcessorTime = true,
    UseNormalizedMean = true
});

var executionTimeInMilliseconds = chronometer.Measure(CodeUnderTest);
```
NumberOfIterations can be overwritten by using the overload of Measure method that accepts numberOfIterations parameter.
```cs
var executionTimeInMilliseconds = chronometer.Measure(CodeUnderTest, 10);
```
## Chronometer Options
| Tables        | Type | Description | Default Value |
|:------------- |:------------|:-------------|:-------------| 
| NumberOfInterations      | int? | Number of times the code under test should be executed. This value must be greater than zero. | 1 | 
| Warmup      | bool | If true runs the code under test once before starting the performance test to ensure that it is compiled by JIT.      | false |
| UseNormalizedMean | bool | NormalizedMean gives you the mean of the values discarding the noise. The deviation of each value from the actual mean is calculated and then the values which are farer from the mean of deviation (called absolute deviation) are discarded and finally the mean of remaining values is returned. For example if values are { 1, 2, 3, 2, 100 } in milliseconds, it discards 100, and returns the mean of { 1, 2, 3, 2 } which is 2. Or if timings are { 240, 220, 200, 220, 220, 270 }, it discards 270, and returns the mean of { 240, 220, 200, 220, 220 } which is 220.      | false |
| MeasureUsingProcessorTime      | bool | Mesaures elapsed time using Process.GetCurrentProcess().TotalProcessorTime instead of System.Diagnostics.Stopwatch. | false |

# Reference
* Thanks to [nawfal](http://stackoverflow.com/a/16157458). This code is basically his stack overflow answer wrapped into NuGet package. 
* http://www.codeproject.com/Articles/61964/Performance-Tests-Precise-Run-Time-Measurements-wi