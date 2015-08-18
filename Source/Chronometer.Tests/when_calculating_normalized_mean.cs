using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chronometer.Tests
{
    [TestFixture]
    public class when_calculating_normalized_mean
    {
        private NormalizedMeanCalculator _normalizedMeanCalculator;

        [SetUp]
        public void SetUp()
        {
            _normalizedMeanCalculator = new NormalizedMeanCalculator();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_values_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _normalizedMeanCalculator.Calculate(null));
        }

        [Test]
        public void it_should_return_NaN_if_values_parameter_is_empty()
        {
            var response = _normalizedMeanCalculator.Calculate(new List<double>());

            Assert.AreEqual(double.NaN, response);
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3, 2, 100 }, 2)]
        [TestCase(new double[] { 240, 220, 200, 220, 220, 270 }, 220)]
        public void it_should_correctly_calculate_normalized_mean(IEnumerable<double> given, double expected)
        {
            var normalizedMean = _normalizedMeanCalculator.Calculate(given);

            Assert.AreEqual(expected, normalizedMean);
        }
    }
}
