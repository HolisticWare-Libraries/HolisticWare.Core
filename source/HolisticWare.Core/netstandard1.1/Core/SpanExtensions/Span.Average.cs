namespace Core
{
	public static partial class
                                        Span
	{
		public static
            int?
                                        Average
                                        (
                                            this System.Span<int?> span
                                        )
		{
            int? result = 0;

            for(int i = 0; i < span.Length; i++)
            {
                result += span[i];
            }

            return result / span.Length;
		}

		public static
            int
                                        Average
                                        (
                                            this System.Span<int> span
                                        )
		{
            int result = 0;

            for(int i = 0; i < span.Length; i++)
            {
                result += span[i];
            }

            return result / span.Length;
		}
	}
}
