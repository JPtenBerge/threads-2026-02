namespace TaskDemo;

public enum Kleur
{
	Blauw,
	Rood,
	Geel
}

public class Barriertje
{
	private const int NrOfParticipants = 5;
	public static void Doe()
	{
		var barrier = new Barrier(NrOfParticipants);
		// barrier.
		
		// Task.Run(() =>
		// {
		// 	barrier.
		// })

		for (int i = 0; i < NrOfParticipants; i++)
		{
			var t = new Task(() =>
			{
				Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} op naar eerste horde");
				Thread.Sleep(Random.Shared.Next(50, 100) * 50);
				Console.WriteLine("eerste horde behaalt! signaling");
				barrier.SignalAndWait();
				Console.WriteLine("iedereen heeft de horde overwonnen");
				
				Console.WriteLine("op naar de volgende horde");
				Thread.Sleep(Random.Shared.Next(50, 100) * 50);
				Console.WriteLine("yes weer behaald! weer signaling");
				barrier.SignalAndWait();
				Console.WriteLine("iedereen heeft ook deze horde overwonnen");
			});
			t.Start();
		}

	}

}