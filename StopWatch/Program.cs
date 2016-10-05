using System;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new StopWatch();
            Console.WriteLine("Press enter to begin the stopwatch");
            Console.ReadLine();
            stopwatch.Start();
            Thread.Sleep(1000);
            stopwatch.End();
            Console.WriteLine($"Duration:  {stopwatch.GetInterval()}");
            Console.ReadLine();
        }
    }
    class StopWatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isRunning;

        public void Start()
        {
            if (_isRunning)
                throw new InvalidOperationException("Stopwatch is already running");

            _startTime = DateTime.Now;
            _isRunning = true;
        }

        public void End()
        {
            if (!_isRunning)
                throw new InvalidOperationException("Stopwatch is not running");

            _endTime = DateTime.Now;
            _isRunning = false;
        }

        public TimeSpan GetInterval()
        {
            return _endTime - _startTime;
        }
    }
}
