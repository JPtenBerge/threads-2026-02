namespace AsyncDemo;

public class AsyncEnum
{
	public static async Task Doe()
	{
		var alles = GeefGetallen();
		
		await foreach (var getal in alles)
		{
			Console.WriteLine($"getal: {getal}");
		}

		// await foreach (var conn in GetConnections())
		// {
		// 	
		// }
		
	}

	public static async IAsyncEnumerable<int> GeefGetallen()
	{
		Console.WriteLine("eerste");
		yield return 4;
		await Task.Delay(2000);
		Console.WriteLine("tweede");
		yield return 8;
		await Task.Delay(2000);
		Console.WriteLine("derde");
		yield return 15;
		await Task.Delay(2000);
		Console.WriteLine("vierde");
		yield return 16;
		await Task.Delay(2000);
		Console.WriteLine("vijfde");
		yield return 23;
		await Task.Delay(2000);
		Console.WriteLine("zesde");
		yield return 42;
	}
}