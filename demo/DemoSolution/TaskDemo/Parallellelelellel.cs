namespace TaskDemo;

public class Parallellelelellel
{
	public static void Doe()
	{
		Parallel.For(0, 1000, (i, loopState) =>
		{
			// loopState.Stop();
		
			if (i % 10 == 0)
			{
				Console.WriteLine("stoppen!");
				loopState.Stop();
			}
		
			Console.WriteLine($"starting for {i}");
			Thread.Sleep(5000);
			Console.WriteLine($"i: {i}");
		});

		Console.WriteLine("waiting for for");
		
		Parallel.Invoke(
			() =>
			{
				Console.WriteLine($"starting {Thread.CurrentThread.ManagedThreadId}");
				Thread.Sleep(2000);
				Console.WriteLine($"klaar met {Thread.CurrentThread.ManagedThreadId}");
			},
			() =>
			{
				Console.WriteLine($"starting {Thread.CurrentThread.ManagedThreadId}");
				Thread.Sleep(4000);
				throw new NotImplementedException("ga weg");
				Console.WriteLine($"klaar met {Thread.CurrentThread.ManagedThreadId}");
			},
			() =>
			{
				Console.WriteLine($"starting {Thread.CurrentThread.ManagedThreadId}");
				Thread.Sleep(2000);
				throw new ArgumentNullException("woooowwwww");
				Console.WriteLine($"klaar met {Thread.CurrentThread.ManagedThreadId}");
			});
		Console.WriteLine("klaar met invoken");
	}
}