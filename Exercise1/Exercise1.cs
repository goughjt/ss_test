using System;
using System.Collections.Generic;
using System.Linq;

namespace SpencerStuartTest.Exercise1
{
	/// <summary>
	/// Exercise1 is about Flights, Landings, Staircases and a Human striding up them.
	/// </summary>
	public class Exercise
	{
		/// <summary>
		/// Solution returns the number of strides required to surmount the specified Flights, given NumStairsPerStride, as wel as a possible non-empty error-message. It should not reveal the underlying logic.
		/// </summary>
		/// <param name="Flights">Flights.</param>
		/// <param name="NumStairsPerStride">Number stairs per stride.</param>
		public Tuple<int?, string> Solution(IEnumerable<int> Flights, int NumStairsPerStride)
		{
			if (NumStairsPerStride <= 0)
			{
				return Tuple.Create((int?)null, "Your human is stationary or moving the wrong way");
			}
			if (Flights == null || !Flights.Any() || Flights.Any(x => x <= 0))
			{
				return Tuple.Create((int?)null, "Your flights are poorly contructed");
			}

			//TODO hardcoded int StridesConsumedPerLanding
			var staircase = new Staircase(Flights, 2);

			return staircase.GetNumStrides(NumStairsPerStride);
		}
	}

}
