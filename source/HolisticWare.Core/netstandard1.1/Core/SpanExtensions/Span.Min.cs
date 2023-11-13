namespace Core
{
	public static partial class
                                        Span
	{
		public static
            int?
                                        Min
                                        (
                                            this System.Span<int?> span
                                        )
		{
            int? result = int.MaxValue;

            for(int i = 0; i < span.Length; i++)
            {
                if (span[i] < result)
                {
                    result = span[i];
                }
            }

            return result / span.Length;
		}

		public static
            int
                                        Min
                                        (
                                            this System.Span<int> span
                                        )
		{
            int result = int.MaxValue;

            for(int i = 0; i < span.Length; i++)
            {
                if (span[i] < result)
                {
                    result = span[i];
                }
            }

            return result / span.Length;
		}
	}
}
