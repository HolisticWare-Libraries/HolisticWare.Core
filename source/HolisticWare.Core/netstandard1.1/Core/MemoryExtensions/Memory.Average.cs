namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Average
                                        (
                                            this System.Memory<int?> memory
                                        )
		{
            return Span.Average(memory.Span);
		}

		public static
            int
                                        Average
                                        (
                                            this System.Memory<int> memory
                                        )
		{
            return Span.Average(memory.Span);
		}
	}
}
