using System.Diagnostics;

namespace TaskDemo;

public class Plinq
{
	public static void Doe()
	{
		var getallen = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

		var stopwatch = new Stopwatch();
		stopwatch.Start();
		getallen.AsParallel().Where(x => HeleZwareFilterOperatie(x)).ForAll(item =>
		{
			Console.WriteLine($"item: {item}");	
		});
		
		// foreach (var item in getallen.AsParallel().Where(x => HeleZwareFilterOperatie(x)))
		// {
		// 	Console.WriteLine($"item: {item}");	
		// }
		stopwatch.Stop();
		Console.WriteLine($"Tijd: {stopwatch.ElapsedMilliseconds}");
	}

	public static bool HeleZwareFilterOperatie(int item)
	{
		Thread.SpinWait(400_000_000); // voorkomen dat je de CPU aandacht verliest
		return true;
	}
}