// See https://aka.ms/new-console-template for more information

var threadje1 = new Thread(() =>
{
	Console.WriteLine("hallo vanaf thread");

	for (int i = 0; i < 10_000_000; i++)
	{
		// lock (MoeilijkDoen.lockObj)
		// {
			// Console.Write("x");
			// MoeilijkDoen.s_tellertje++;
			Interlocked.Increment(ref MoeilijkDoen.s_tellertje);
			// }
	}
});
var threadje2 = new Thread(() =>
{
	// try
	// {
	// 	Monitor.Enter(MoeilijkDoen.lockObj);
		for (int i = 0; i < 10_000_000; i++)
		{
			// Console.Write(".");
			Interlocked.Increment(ref MoeilijkDoen.s_tellertje);
		}
	// }
	// finally
	// {
	// 	Monitor.Exit(MoeilijkDoen.lockObj);
	// }
});
threadje1.Priority = ThreadPriority.Lowest;
threadje2.Priority = ThreadPriority.Highest;
threadje1.Start();
threadje2.Start();
threadje1.Join();
threadje2.Join();
Console.WriteLine($"Tellertje is nu {MoeilijkDoen.s_tellertje}");

// 2^32 = 2.147.xxx.xxx

ThreadPool.GetAvailableThreads(out var aantal, out var diff);
Console.WriteLine($"aantal/diff: {aantal}/{diff}");


ThreadPool.SetMinThreads(5000, 1000 );
ThreadPool.QueueUserWorkItem(_ =>
{
	Thread.Sleep(1000);
	Console.WriteLine($"hallo vanaf threadpool thread {Thread.CurrentThread.ManagedThreadId}");
});
Thread.Sleep(2500);
Console.WriteLine($"hallo vanaf main thread met 5000 threads {Thread.CurrentThread.ManagedThreadId}");

Console.ReadKey();



class MoeilijkDoen
{
	public static object lockObj = new { };

	public static int s_tellertje = 0;
}
