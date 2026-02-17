// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// var t = new Task<int>(() =>
// {
// 	Thread.Sleep(2000);
// 	Console.WriteLine($"in task {Thread.CurrentThread.ManagedThreadId}");
// 	return 42;
// });
// t.Start();

// var task = Task.Run(() =>
// {
// 	return 14;
// });

// new TaskFactory<int>().StartNew()

// Task afwachten? await

// Console.WriteLine($"Result1: {t.GetAwaiter().GetResult()}");
// Console.WriteLine($"Result2: {t.Result}");
// Console.WriteLine($"Result3: {t.Result}");
// Console.WriteLine($"Result4: {t.Result}");
// Console.WriteLine($"Result5: {t.Result}");

// Thread.Sleep(1000);
// Console.WriteLine($"in main {Thread.CurrentThread.ManagedThreadId}");


// cancellationtoken


var cts = new CancellationTokenSource();
Console.WriteLine("meteen annuleren");
cts.Cancel();
 
Task.Run(() =>
{
	Console.WriteLine("starting task");
	for (int i = 0; i < 50_000_000; i++)
	{
		cts.Token.ThrowIfCancellationRequested();
		Console.WriteLine($"i: {i}");
	}
}, cts.Token);

Console.WriteLine("even dutje doen");
Thread.Sleep(2000);
Console.WriteLine("canceling!");
cts.Cancel();

Console.ReadKey();