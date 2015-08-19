using System;
using System.Collections.Generic;
using Chronometer.Tests.Helpers;
using Moq;
using Narkhedegs.PerformanceMeasurement;
using NUnit.Framework;

namespace Chronometer.Tests
{
    [TestFixture]
    public class when_measuring_execution_time
    {
        private Narkhedegs.PerformanceMeasurement.Chronometer _chronometer;
        private ChronometerOptions _options;
        private Mock<INormalizedMeanCalculator> _normalizedMeanCalculatorMock;
        private Mock<ITimerFactory> _timerFactoryMock;

        [SetUp]
        public void SetUp()
        {
            _options = ChronometerOptionsGenerator.Default();
            _normalizedMeanCalculatorMock = new Mock<INormalizedMeanCalculator>();

            _timerFactoryMock = new Mock<ITimerFactory>();
            _timerFactoryMock.Setup(x => x.Create(It.IsAny<ChronometerOptions>())).Returns(new FakeTimer());

            _chronometer = new Narkhedegs.PerformanceMeasurement.Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object);
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_action_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _chronometer.Measure(null));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_numberOfIterations_parameter_is_less_than_1()
        {
            Action doNothing = () => { };

            Assert.Throws<ArgumentException>(() => _chronometer.Measure(doNothing, 0),
                Narkhedegs.PerformanceMeasurement.Properties.Resources.NumberOfIterationsLessThan1ExceptionMessage);
        }

        [Test]
        public void it_should_execute_code_under_test_once_before_performance_test_if_Warmup_option_is_true()
        {
            var numberOfTimesActionIsExecuted = 0;
            Action action = () => numberOfTimesActionIsExecuted += 1;
            _options = ChronometerOptionsGenerator.Default().WithWarmup();

            _chronometer = new Narkhedegs.PerformanceMeasurement.Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object);
            _chronometer.Measure(action);

            Assert.AreEqual(2, numberOfTimesActionIsExecuted);
        }

        [Test]
        public void it_should_not_execute_code_under_test_once_before_performance_test_if_Warmup_option_is_false()
        {
            var numberOfTimesActionIsExecuted = 0;
            Action action = () => numberOfTimesActionIsExecuted += 1;

            _chronometer = new Narkhedegs.PerformanceMeasurement.Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object);
            _chronometer.Measure(action);

            Assert.AreEqual(1, numberOfTimesActionIsExecuted);
        }

        [Test]
        public void it_should_execute_code_under_test_for_value_of_numberOfIterations()
        {
            var numberOfTimesActionIsExecuted = 0;
            Action action = () => numberOfTimesActionIsExecuted += 1;
            _options = ChronometerOptionsGenerator.Default().WithNumberOfIterations(10);

            _chronometer = new Narkhedegs.PerformanceMeasurement.Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object);
            _chronometer.Measure(action);

            Assert.AreEqual(10, numberOfTimesActionIsExecuted);
        }

        [Test]
        public void it_should_call_NormalizedMeanCalculator_if_UseNormalizedMean_option_is_true()
        {
            Action doNothing = () => { };
            _options = ChronometerOptionsGenerator.Default().WithUseNormalizedMean();

            _chronometer = new Narkhedegs.PerformanceMeasurement.Chronometer(_options, _normalizedMeanCalculatorMock.Object, _timerFactoryMock.Object);
            _chronometer.Measure(doNothing);

            _normalizedMeanCalculatorMock.Verify(calculator => calculator.Calculate(It.IsAny<IEnumerable<double>>()),
                Times.Once);
        }
    }
}
