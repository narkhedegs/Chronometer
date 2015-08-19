using System;
using Narkhedegs.PerformanceMeasurement;

namespace Chronometer.Tests.Helpers
{
    public class FakeTimer : ITimer
    {
        public TimeSpan Elapsed
        {
            get
            {
                return TimeSpan.FromMilliseconds(1000);
            }
        }

        public bool IsRunning { get; private set; }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Reset()
        {
        }

        public void Restart()
        {
        }
    }
}
