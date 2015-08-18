using System;
using Chronometer.Tests.Helpers;
using NUnit.Framework;

namespace Chronometer.Tests
{
    [TestFixture]
    public class when_creating_a_timer
    {
        private TimerFactory _timerFactory;

        [SetUp]
        public void SetUp()
        {
            _timerFactory = new TimerFactory();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_options_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _timerFactory.Create(null));
        }

        [Test]
        public void it_should_return_ProcessorTimer_if_MeasureUsingProcessorTime_option_is_true()
        {
            var timer = _timerFactory.Create(ChronometerOptionsGenerator.Default().WithMeasureUsingProcessorTime());

            Assert.IsInstanceOf<ProcessorTimer>(timer);
        }        
        
        [Test]
        public void it_should_return_StopwatchTimer_if_MeasureUsingProcessorTime_option_is_false()
        {
            var timer = _timerFactory.Create(ChronometerOptionsGenerator.Default());

            Assert.IsInstanceOf<StopwatchTimer>(timer);
        }
    }
}
