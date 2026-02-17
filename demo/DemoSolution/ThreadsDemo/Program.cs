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

class MoeilijkDoen
{
	public static object lockObj = new { };

	public static int s_tellertje = 0;
}