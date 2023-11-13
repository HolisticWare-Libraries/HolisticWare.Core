namespace Core
{
	public static partial class
                                        Memory
	{
		public static
            int?
                                        Min
                                        (
                                            this System.Memory<int?> Memory
                                        )
		{
            int? result = int.MaxValue;

            for(int i = 0; i < Memory.Length; i++)
            {
                if (Memory[i] < result)
                {
                    result = Memory[i];
                }
            }

            return result / Memory.Length;
		}

		public static
            int
                                        Min
                                        (
                                            this System.Memory<int> Memory
                                        )
		{
            int result = int.MaxValue;

            for(int i = 0; i < Memory.Length; i++)
            {
                if (Memory[i] < result)
                {
                    result = Memory[i];
                }
            }

            return result / Memory.Length;
		}
	}
}
