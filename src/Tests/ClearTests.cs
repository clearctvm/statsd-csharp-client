namespace Tests
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using NUnit.Framework;
	using StatsdClient;

	[TestFixture]
	public class ClearTests
	{
		[Test]
		public void Do()
		{
			var config = new MetricsConfig {StatsdServerName = "192.168.221.28", Prefix = "devel"};

			Metrics.Configure(config);

			var timer1 = new Task(() =>
			{
				for (var i = 0; i < 60000; i++)
				{
					Metrics.Counter("clear.services.experiments.handle");

					using (Metrics.StartTimer("clear.services.experiments.handle"))
					{
						Thread.Sleep(50000 * new Random().Next(1));
					}

					Console.WriteLine("timer1 tick");
				}
			});

			var timer2 = new Task(() =>
			{
				for (var i = 0; i < 60000; i++)
				{
					Metrics.Counter("clear.services.experiments.requests");

					using (Metrics.StartTimer("clear.services.experiments.handle"))
					{
						Thread.Sleep(70000 * new Random().Next(1));
					}

					Console.WriteLine("timer2 tick");
				}
			});

			timer1.Start();
			timer2.Start();

			timer1.Wait();
			timer2.Wait();
		}
	}
}