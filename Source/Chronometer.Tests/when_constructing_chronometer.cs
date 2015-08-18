using System;
using Chronometer.Tests.Helpers;
using Moq;
using NUnit.Framework;

namespace Chronometer.Tests
{
    [TestFixture]
    public class when_constructing_chronometer
    {
        private Mock<INormalizedMeanCalculator> _normalizedMeanCalculatorMock;
        private ChronometerOptions _options;
        private Mock<ITimerFactory> _timerFactoryMock;

        [SetUp]
        public void SetUp()
        {
            _options = ChronometerOptionsGenerator.Default();
            _normalizedMeanCalculatorMock = new Mock<INormalizedMeanCalculator>();
            _timerFactoryMock = new Mock<ITimerFactory>();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_options_parameter_is_null()
        {
            _options = null;

            Assert.Throws<ArgumentNullException>(
                () => new Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_NumberOfInterations_options_value_is_null()
        {
            _options = ChronometerOptionsGenerator.Default().WithNumberOfIterations(null);

            Assert.Throws<ArgumentException>(
                () => new Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object),
                Properties.Resources.NumberOfIterationsLessThan1ExceptionMessage);
        }

        [Test]
        public void it_should_throw_ArgumentException_if_NumberOfIterations_options_value_is_less_than_1()
        {
            _options = ChronometerOptionsGenerator.Default().WithNumberOfIterations(0);

            Assert.Throws<ArgumentException>(
                () => new Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object),
                Properties.Resources.NumberOfIterationsLessThan1ExceptionMessage);
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_normalizedMeanCalculator_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Chronometer(_options, null, _timerFactoryMock.Object));
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_timerFactory_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Chronometer(_options, _normalizedMeanCalculatorMock.Object, null));
        }

        [Test]
        public void it_should_assign_the_value_of_options_parameter_to_Options_property_if_options_parameter_is_not_null
            ()
        {
            _options = new ChronometerOptions
            {
                NumberOfInterations = 10
            };

            var chronometer = new Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object);

            Assert.AreEqual(chronometer.Options, _options);
        }
    }
}
