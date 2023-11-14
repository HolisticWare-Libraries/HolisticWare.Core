namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Max
                                        (
                                            this System.Memory<int?> memory
                                        )
		{
            return Span.Max(memory.Span);
		}

		public static
            int
                                        Max
                                        (
                                            this System.Memory<int> memory
                                        )
		{
            return Span.Max(memory.Span);
		}
	}
}
