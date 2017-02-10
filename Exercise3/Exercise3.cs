using System;
using System.Linq;
using NUnit.Framework;

namespace SpencerStuartTest.Exercise3
{
	/// <summary>
	/// Exercise 3 was very quick to research :)
	/// http://stackoverflow.com/questions/31844188/interview-test-adding-using-a-recursive-algorithm-c-sharp
	/// </summary>
	public class Exercise
	{
		private int remainder;

		/// <summary>
		/// Method to reverse order byte arrays and send them to a recursive function.
		/// </summary>
		/// <returns>The using AR ecursive algorithm values are added.</returns>
		/// <param name="f">F.</param>
		/// <param name="s">S.</param>
		public AddResult Add_UsingARecursiveAlgorithm_ValuesAreAdded(byte[] f, byte[] s)
		{
			remainder = 0;

			//Arrange
			f = f.Reverse().ToArray();
			s = s.Reverse().ToArray();

			//Act
			var result = AddRecursive(f, s).Reverse().ToArray();

			//Return
			return new AddResult
			{
				f = f,
				s = s,
				result = result
			};
		}

		/// <summary>
		/// Recursive method for adding bytes.
		/// </summary>
		/// <returns>The recursive.</returns>
		/// <param name="f">F.</param>
		/// <param name="s">S.</param>
		private byte[] AddRecursive(byte[] f, byte[] s)
		{
			if (f.Length == 0) return new byte[] { };
			int tempresult = f[0] + s[0] + remainder;
			byte[] z = new byte[]
			{ (byte)(tempresult) };
			remainder = tempresult / (byte.MaxValue + 1);
			return z.Concat(AddRecursive(f.Skip(1).ToArray(), s.Skip(1).ToArray())).ToArray();
		}
	}

	/// <summary>
	/// AddResult should encapsulate the required output. We return the input arrays with the result.
	/// </summary>
	public struct AddResult
	{
		public byte[] f { get; set;}
		public byte[] s { get; set; }
		public byte[] result { get; set; }
	}
}
