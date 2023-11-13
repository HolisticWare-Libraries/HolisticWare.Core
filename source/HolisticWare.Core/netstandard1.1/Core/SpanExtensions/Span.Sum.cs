namespace Core
{
	public static partial class
                                        Span
	{
		public static
            int?
                                        Sum
                                        (
                                            this System.Span<int?> span
                                        )
		{
            int? result = 0;

            for(int i = 0; i < span.Length; i++)
            {
                result += span[i];
            }

            return result;
		}

		public static
            int
                                        Sum
                                        (
                                            this System.Span<int> span
                                        )
		{
            int result = 0;

            for(int i = 0; i < span.Length; i++)
            {
                result += span[i];
            }

            return result;
		}
	}
}
