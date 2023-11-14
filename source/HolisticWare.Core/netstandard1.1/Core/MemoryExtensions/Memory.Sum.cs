namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Sum
                                        (
                                            this System.Memory<int?> memory
                                        )
		{
            return Span.Sum(memory.Span);
		}

		public static
            int
                                        Sum
                                        (
                                            this System.Memory<int> memory
                                        )
		{
            return Span.Sum(memory.Span);
		}
	}
}
