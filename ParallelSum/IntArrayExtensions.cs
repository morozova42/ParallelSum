namespace ParallelSum
{
	public static class IntArrayExtensions
	{
		private static int sum;
		private static void ChunkSum(object? obj)
		{
			int[] array = obj as int[];
			for (int i = 0; i < array.Length; i++)
			{
				Interlocked.Add(ref sum, array[i]);
			}
		}

		public static int GetSumSimple(this int[] array)
		{
			return array.Sum();
		}

		public static int GetSumParallel(this int[] array)
		{
			List<Thread> threads = new List<Thread>();
			int chunkSize = array.Length / 10;
			var chunks = array.Chunk(chunkSize);

			for (int i = 0; i < 10; i++)
			{
				threads.Add(new Thread(ChunkSum));
			}
			for (int i = 0; i < threads.Count; i++)
			{
				threads[i].Start(chunks.ElementAt(i));
			}
			return sum;
		}

		public static int GetSumPLINQ(this int[] array)
		{
			return array.AsParallel().Sum();
		}
	}
}
