using System;
using System.Collections.Generic;
using System.Linq;

namespace SpencerStuartTest.Exercise1
{
	/// <summary>
	/// Staircase is a class which assumes that every flight but the final flight has a subsequent landing. It returns 0 if its flights have been poorly constructed although we should catch this earlier if possible.
	/// </summary>
	internal class Staircase : StrideConsumer
	{
		public Staircase(IEnumerable<int> Flights, int StridesConsumedPerLanding)
		{
			this.Flights = Flights.Select(x => new Flight(x)).ToList();
			this.StridesConsumedPerLanding = StridesConsumedPerLanding;

		}

		private int StridesConsumedPerLanding { get; set; }

		public IEnumerable<Flight> Flights { get; set; }

		public Tuple<int?, string> GetNumStrides(int NumStairsPerStride)
		{
			if (Flights == null || !Flights.Any())
				//This should never be hit
				return Tuple.Create((int?)null, "Your flights are poorly contructed");
			else
				//We do -1 because there is no landing for the final flight
				return Tuple.Create((int?)Flights.Sum(x => x.GetNumStrides(NumStairsPerStride).Item1) + (Flights.Count() - 1) * StridesConsumedPerLanding, string.Empty);
		}
	}
}
