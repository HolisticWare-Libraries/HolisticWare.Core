namespace Core
{
	public static partial class
                                        Span
	{
		public static
            int?
                                        Max
                                        (
                                            this System.Span<int?> span
                                        )
		{
            int? result = int.MinValue;

            for(int i = 0; i < span.Length; i++)
            {
                if (span[i] > result)
                {
                    result = span[i];
                }
            }

            return result / span.Length;
		}

		public static
            int
                                        Max
                                        (
                                            this System.Span<int> span
                                        )
		{
            int result = int.MinValue;

            for(int i = 0; i < span.Length; i++)
            {
                if (span[i] > result)
                {
                    result = span[i];
                }
            }

            return result;
		}
	}
}
