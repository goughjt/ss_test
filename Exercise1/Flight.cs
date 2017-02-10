using System;

namespace SpencerStuartTest.Exercise1
{
	/// <summary>
	/// Flight is a number of steps. If this number is less than or equal to zero, Flight will act like it has zero steps.
	/// </summary>
	internal class Flight : StrideConsumer
	{
		public Flight(int NumStairs)
		{
			this.NumStairs = NumStairs;
		}
		public int NumStairs
		{
			get;
			set;
		}
		public Tuple<int?, string> GetNumStrides(int NumStairsPerStride)
		{
			if (NumStairs <= 0)
				return Tuple.Create((int?)0, "Flight does not have enough stairs");
			else if(NumStairsPerStride <= 0)
				return Tuple.Create((int?)0, "Strider does not stride");
			else
				return Tuple.Create((int?)(NumStairs / NumStairsPerStride) + (NumStairs % NumStairsPerStride == 0 ? 0 : 1), string.Empty);
		}
	}
}
