namespace AsyncDemo;

public class FileDemo
{
	public static void Doe()
	{
		var fileHandle = File.OpenRead("C:\\bla.txt");

		var buff = new byte[1024];

		fileHandle.BeginRead(buff, 0, 1024, new(EndRead), null);
	}

	public static void EndRead(IAsyncResult ar)
	{
	}

	public static async Task LeesData()
	{
		var getal = 14;
		Console.WriteLine("beginnen met lezen");
		var result = await File.ReadAllTextAsync(@"C:\bla\hoi.txt");
		Console.WriteLine($"result: {result}");

		Console.WriteLine(getal);
	}
}