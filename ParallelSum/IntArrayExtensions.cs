namespace ParallelSum
{
	public static class IntArrayExtensions
	{
		public static int GetSumSimple(this int[] array)
		{
			return array.Sum();
		}

		public static int GetSumParallel(this int[] array)
		{
			int sum = 0;
			Parallel.ForEach(array, i => Interlocked.Add(ref sum, i));
			return sum;
		}

		public static int GetSumPLINQ(this int[] array)
		{
			return array.AsParallel().Sum();
		}
	}
}
