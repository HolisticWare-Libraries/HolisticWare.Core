namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Min
                                        (
                                            this System.Memory<int?> memory
                                        )
		{
            return Span.Min(memory.Span);
		}

		public static
            int
                                        Min
                                        (
                                            this System.Memory<int> memory
                                        )
		{
            return Span.Min(memory.Span);
		}
	}
}
