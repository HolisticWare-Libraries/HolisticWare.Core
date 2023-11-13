namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Average
                                        (
                                            this System.Memory<int?> Memory
                                        )
		{
            int? result = 0;

            for(int i = 0; i < Memory.Length; i++)
            {
                result += Memory[i];
            }

            return result / Memory.Length;
		}

		public static
            int
                                        Average
                                        (
                                            this System.Memory<int> Memory
                                        )
		{
            int result = 0;

            for(int i = 0; i < Memory.Length; i++)
            {
                result += Memory[i];
            }

            return result / Memory.Length;
		}
	}
}
