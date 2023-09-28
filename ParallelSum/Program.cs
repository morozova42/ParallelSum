using ParallelSum;
using System.Diagnostics;

internal class Program
{
	private static void Main(string[] args)
	{
		int[] ArrayS = new int[100000].Select(x => Random.Shared.Next(0, 100)).ToArray();
		int[] ArrayM = new int[1000000].Select(x => Random.Shared.Next(0, 100)).ToArray();
		int[] ArrayL = new int[10000000].Select(x => Random.Shared.Next(0, 100)).ToArray();

		Console.WriteLine("Start calculating for ArrayS");
		CalculateAndPrint(ArrayS);
		Console.WriteLine();

		Console.WriteLine("Start calculating for ArrayM");
		CalculateAndPrint(ArrayM);
		Console.WriteLine();

		Console.WriteLine("Start calculating for ArrayL");
		CalculateAndPrint(ArrayL);
	}

	private static void CalculateAndPrint(int[] array)
	{
		Stopwatch sw = Stopwatch.StartNew();
		var sumOfArraySimple = array.GetSumSimple();
		Console.WriteLine($"For {array.Length} array sumOfArraySimple = {sumOfArraySimple} in {sw.ElapsedMilliseconds} ms");

		sw.Restart();
		var sumOfArrayParallel = array.GetSumParallel();
		Console.WriteLine($"For {array.Length} array sumOfArrayParallel = {sumOfArrayParallel} in {sw.ElapsedMilliseconds} ms");

		sw.Restart();
		var sumOfArrayPLINQ = array.GetSumPLINQ();
		Console.WriteLine($"For {array.Length} array sumOfArrayPLINQ = {sumOfArrayPLINQ} in {sw.ElapsedMilliseconds} ms");

		sw.Stop();
	}
}