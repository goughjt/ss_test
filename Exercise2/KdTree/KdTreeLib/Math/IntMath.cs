using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdTree.Math
{
	[Serializable]
	public class IntMath : TypeMath<int>
	{
		public override int Compare(int a, int b)
		{
			return a.CompareTo(b);
		}

		public override bool AreEqual(int a, int b)
		{
			return a == b;
		}

		public override int MinValue
		{
			get { return int.MinValue; }
		}

		public override int MaxValue
		{
			get { return int.MaxValue; }
		}

		public override int Zero
		{
			get { return 0; }
		}

		public override int NegativeInfinity { get { return 0; } }

		public override int PositiveInfinity { get { return 1000; } }

		public override int Add(int a, int b)
		{
			return a + b;
		}

		public override int Subtract(int a, int b)
		{
			return a - b;
		}

		public override int Multiply(int a, int b)
		{
			return a * b;
		}

		public override int DistanceSquaredBetweenPoints(int[] a, int[] b)
		{
			int distance = Zero;
			int dimensions = a.Length;

			// Return the absolute distance between 2 hyper points
			for (var dimension = 0; dimension < dimensions; dimension++)
			{
				int distOnThisAxis = Subtract(a[dimension], b[dimension]);
				int distOnThisAxisSquared = Multiply(distOnThisAxis, distOnThisAxis);

				distance = Add(distance, distOnThisAxisSquared);
			}

			return distance;
		}
	}
}
