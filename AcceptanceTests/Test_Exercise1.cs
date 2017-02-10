using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using SpencerStuartTest.Exercise1;

namespace SpencerStuartTest
{
	[TestFixture]
	class AcceptanceTests_Exercise1
	{
		private Exercise ex;
		[OneTimeSetUp]
		public void init()
		{
			ex = new Exercise();
		}

		[TestCaseSource(typeof(TestCaseFactory_Exercise1), "RequiredTestCases")]
		public int? SolutionTest(IEnumerable<int> Flights, int NumStairsPerStride)
		{
			return ex.Solution(Flights, NumStairsPerStride).Item1;
		}

		[TestCaseSource(typeof(TestCaseFactory_Exercise1), "ExtraTestCases")]
		public string SolutionTestExtra(IEnumerable<int> Flights, int NumStairsPerStride)
		{
			return ex.Solution(Flights, NumStairsPerStride).Item2;
		}
	}

	internal class TestCaseFactory_Exercise1
	{
		static int i = 0;
		/// <summary>
		/// These are the required test cases
		/// </summary>
		/// <value>The required test cases.</value>
		public static IEnumerable RequiredTestCases
		{
			get
			{
				yield return new TestCaseData(new List<int> { 15 }, 2).Returns(8).SetName(TestName());
				yield return new TestCaseData(new List<int> { 15, 15 }, 2).Returns(18).SetName(TestName());
				yield return new TestCaseData(new List<int> { 5, 11, 9, 13, 8, 30, 14 }, 3).Returns(44).SetName(TestName());
			}
		}
		/// <summary>
		/// These are some extra test cases I made up
		/// </summary>
		/// <value>The extra test cases.</value>
		public static IEnumerable ExtraTestCases
		{
			get
			{
				yield return new TestCaseData(new List<int> { 5, 11, 9, 13, 8, 30, 14 }, 0).Returns("Your human is stationary or moving the wrong way").SetName(TestName()).SetDescription("NOT part of requirements");
				yield return new TestCaseData(new List<int> { 5, 11, 9, 13, 8, 30, -14 }, 3).Returns("Your flights are poorly contructed").SetName(TestName()).SetDescription("NOT part of requirements");
			}
		}

		/// <summary>
		/// This is actually a really bad way of naming tests
		/// </summary>
		/// <returns>The name.</returns>
		private static string TestName()
		{
			return "Exercise1_Test" + i++;
		}
	}
}
