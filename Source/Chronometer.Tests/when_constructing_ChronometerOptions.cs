using Narkhedegs.PerformanceMeasurement;
using NUnit.Framework;

namespace Chronometer.Tests
{
    [TestFixture]
    public class when_constructing_ChronometerOptions
    {
        [Test]
        public void it_should_assign_a_default_value_of_1_to_NumberOfInterations_property()
        {
            var options = new ChronometerOptions();

            Assert.AreEqual(1, options.NumberOfInterations);
        }
    }
}
