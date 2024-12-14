namespace ElectiveClassProject
{
    using System;
    using System.Threading;

    public delegate void StopwatchEventHandler(string message);

    public class Stopwatch
    {
        public TimeSpan TimeElapsed { get; private set; }
        public bool IsRunning { get; private set; }

        public event StopwatchEventHandler OnStarted;
        public event StopwatchEventHandler OnStopped;
        public event StopwatchEventHandler OnReset;

        private Timer timer;

        public Stopwatch()
        {
            TimeElapsed = TimeSpan.Zero;
            IsRunning = false;
        }

        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                timer = new Timer(Tick, null, 0, 1000); // Call Tick every second
                OnStarted?.Invoke("Stopwatch started.");
            }
            else
            {
                OnStarted?.Invoke("Stopwatch is already running.");
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                timer?.Dispose();
                OnStopped?.Invoke($"Stopwatch stopped. Elapsed time: {FormatElapsedTime()}");
            }
            else
            {
                OnStopped?.Invoke("Stopwatch is not running.");
            }
        }

        public void Reset()
        {
            Stop();
            TimeElapsed = TimeSpan.Zero;
            OnReset?.Invoke("Stopwatch reset.");
        }

        private void Tick(object state)
        {
            TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
        }

        private string FormatElapsedTime()
        {
            return $"{TimeElapsed.Hours:D2}:{TimeElapsed.Minutes:D2}:{TimeElapsed.Seconds:D2}";
        }
    }
}
