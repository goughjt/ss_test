using System;
namespace SpencerStuartTest.Exercise1
{
	/// <summary>
	/// Stride consumer is an interface to represent anything that can be thought of as consuming strides from a human, 
	/// </summary>
	interface StrideConsumer
	{
		/// <summary>
		/// Gets the number of strides and possibly an error message.
		/// </summary>
		/// <returns>The number of strides.</returns>
		/// <param name="NumStairsPerStride">Number stairs per stride.</param>
		Tuple<int?, string> GetNumStrides(int NumStairsPerStride);
	}
}
