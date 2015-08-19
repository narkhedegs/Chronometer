using Narkhedegs.PerformanceMeasurement;

namespace Chronometer.Tests.Helpers
{
    public static class ChronometerOptionsGenerator
    {
        public static ChronometerOptions Default()
        {
            return new ChronometerOptions
            {
                NumberOfInterations = 1
            };
        }

        public static ChronometerOptions WithNumberOfIterations(this ChronometerOptions options, int? numberOfIterations)
        {
            options.NumberOfInterations = numberOfIterations;
            return options;
        }        
        
        public static ChronometerOptions WithWarmup(this ChronometerOptions options)
        {
            options.Warmup = true;
            return options;
        }

        public static ChronometerOptions WithMeasureUsingProcessorTime(this ChronometerOptions options)
        {
            options.MeasureUsingProcessorTime = true;
            return options;
        }

        public static ChronometerOptions WithUseNormalizedMean(this ChronometerOptions options)
        {
            options.UseNormalizedMean = true;
            return options;
        }
    }
}
