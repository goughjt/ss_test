using System;
using NUnit.Framework;
using SpencerStuartTest.Exercise3;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SpencerStuartTest
{
	[TestFixture]
	public class AcceptanceTests_Exercise3
	{
		private Exercise ex;
		[OneTimeSetUp]
		public void init()
		{
			ex = new Exercise();
		}

		[Test]
		[TestCaseSource(typeof(TestCaseFactory_Exercise3), "TestCases")]
		public byte[] SolutionTest(byte[] f, byte[] s)
		{
			//Assert
			return ex.Add_UsingARecursiveAlgorithm_ValuesAreAdded(f, s).result;
		}

	}


	internal class TestCaseFactory_Exercise3
	{
		static int i = 0;

		/// <summary>
		/// These are the required test cases
		/// </summary>
		/// <value>The required test cases.</value>
		public static IEnumerable TestCases
		{
			get
			{
				yield return new TestCaseData(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 })
					.Returns(new byte[] { 2, 2, 2 })
					.SetName(TestName());
				
				yield return new TestCaseData(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 })
					.Returns(new byte[] { 1, 2, 0 })
					.SetName(TestName());

				yield return new TestCaseData(new byte[] { 255, 255, 255 }, new byte[] { 255, 255, 255 })
					.Returns(new byte[] { 255, 255, 254 })
					.SetName(TestName());

				yield return new TestCaseData(new byte[] { 2, 1, 255 }, new byte[] { 0, 0, 1 })
					.Returns(new byte[] { 2, 2, 0 })
					.SetName(TestName());
			}
		}

		/// <summary>
		/// This is actually a really bad way of naming tests
		/// </summary>
		/// <returns>The name.</returns>
		private static string TestName()
		{
			return "Exercise3_Test" + i++;
		}
	}
}
