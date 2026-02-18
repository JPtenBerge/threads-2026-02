using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AsyncDemo;

public static class ProcessExtensions
{
	public static TaskAwaiter<int> GetAwaiter(this Process process)
	{
		var tcs = new TaskCompletionSource<int>();
		process.Exited += (sender, args) =>
		{
			tcs.SetResult(process.ExitCode);
		};
		process.EnableRaisingEvents = true;
		return tcs.Task.GetAwaiter();
	}
}