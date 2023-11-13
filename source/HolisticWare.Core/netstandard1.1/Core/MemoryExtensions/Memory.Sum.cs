namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Sum
                                        (
                                            this System.Memory<int?> Memory
                                        )
		{
            int? result = 0;

            for(int i = 0; i < Memory.Length; i++)
            {
                result += Memory[i];
            }

            return result;
		}

		public static
            int
                                        Sum
                                        (
                                            this System.Memory<int> Memory
                                        )
		{
            int result = 0;

            for(int i = 0; i < Memory.Length; i++)
            {
                result += Memory[i];
            }

            return result;
		}
	}
}
