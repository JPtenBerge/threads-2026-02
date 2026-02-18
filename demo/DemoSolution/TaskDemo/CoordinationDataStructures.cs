using System.Collections.Concurrent;
using System.Globalization;

namespace TaskDemo;

public class CoordinationDataStructures
{
	// public static Dictionary<int, int> s_dict = new();
	public static ConcurrentDictionary<int, int> s_dict = new();
	
	public static void Doe()
	{
		var t1 = new Task(VulDict);
		var t2 = new Task(VulDict);
		t1.Start();
		t2.Start();
		
		Task.WaitAll(t1, t2);

		foreach (var entry in s_dict)
		{
			Console.WriteLine($"{entry.Key}: {entry.Value}");
		}
	}

	public static void VulDict()
	{
		for (int i = 0; i < 10; i++)
		{
			s_dict.TryAdd(i, 4);
		}
	}
}