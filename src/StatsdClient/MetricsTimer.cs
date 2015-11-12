using System;

namespace StatsdClient
{
	public class MetricsTimer : IDisposable
	{
		private readonly string _name;
		private readonly Stopwatch _stopWatch;
		private bool _disposed;
	    private readonly double _sampleRate = 1;
		private readonly int payload;

		public MetricsTimer(string name, double sampleRate = 1, int payload = 0)
		{
			_name = name;
            _sampleRate = sampleRate;
		    this.payload = payload;
		    _stopWatch = new Stopwatch();
			_stopWatch.Start();
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_stopWatch.Stop();
				Metrics.Timer(_name, _stopWatch.ElapsedMilliseconds() + payload, _sampleRate);
			}
		}
	}
}