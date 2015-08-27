using Narkhedegs.PerformanceMeasurement;
using NUnit.Framework;

namespace Chronometer.Tests
{
    [TestFixture]
    public class when_constructing_chronometer_using_a_default_constructor
    {
        private IChronometer _chronometer;

        [SetUp]
        public void SetUp()
        {
            _chronometer = new Narkhedegs.PerformanceMeasurement.Chronometer();
        }

        [Test]
        public void it_should_set_the_default_value_of_NumberOfInterations_to_1()
        {
            Assert.AreEqual(1, _chronometer.Options.NumberOfInterations);
        }

        [Test]
        public void it_should_set_the_default_value_of_Warmup_to_false()
        {
            Assert.AreEqual(false, _chronometer.Options.Warmup);
        }        
        
        [Test]
        public void it_should_set_the_default_value_of_UseNormalizedMean_to_false()
        {
            Assert.AreEqual(false, _chronometer.Options.UseNormalizedMean);
        }        
        
        [Test]
        public void it_should_set_the_default_value_of_MeasureUsingProcessorTime_to_false()
        {
            Assert.AreEqual(false, _chronometer.Options.MeasureUsingProcessorTime);
        }        
        
        [Test]
        public void it_should_set_the_default_value_of_AllowMeasurementsUnderDebugMode_to_false()
        {
            Assert.AreEqual(false, _chronometer.Options.AllowMeasurementsUnderDebugMode);
        }
    }
}
