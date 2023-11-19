namespace ParallelSum
{
	public static class IntArrayExtensions
	{
		private static Thread[] threads = new Thread[10];
		private static int[] sums = new int[10];
		private static IEnumerable<int[]> chunks;
		private static void ChunkSum(object? obj)
		{
			int? index = obj as int?;
			sums[index.Value] = chunks.ElementAt(index.Value).Sum();
		}

		public static int GetSumSimple(this int[] array)
		{
			return array.Sum();
		}

		public static int GetSumParallel(this int[] array)
		{
			int chunkSize = array.Length / 10;
			chunks = array.Chunk(chunkSize);

			for (int i = 0; i < 10; i++)
			{
				threads[i] = new Thread(ChunkSum);
			}
			threads[9].Start(9);
			for (int i = 8; i >= 0; i--)
			{
				threads[i].Start(i);
				threads[i + 1].Join();
			}
			threads[0].Join();
			return sums.Sum();
		}

		public static int GetSumPLINQ(this int[] array)
		{
			return array.AsParallel().Sum();
		}
	}
}
