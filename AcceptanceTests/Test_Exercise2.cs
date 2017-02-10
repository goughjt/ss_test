using NUnit.Framework;
using SpencerStuartTest.Exercise2;

namespace SpencerStuartTest
{
	[TestFixture]
	class AcceptanceTests_Exercise2
	{
		private Exercise ex;
		[OneTimeSetUp]
		public void init()
		{
			ex = new Exercise();
		}

		[Test]
		public void SolutionTest()
		{
			//NB change PROJECTS_DIR as per your system.
			string projectsDirectory = "/Users/myUser/Downloads";
			string htmlFileFullPath = projectsDirectory + "/SpencerStuartTest/SpencerStuartTest/Exercise2/ThreeJS/firstTestCaseHyperspace.html";
			string hyperspaceFileFullPath = projectsDirectory + "/SpencerStuartTest/SpencerStuartTest/Exercise2/hyperspace.txt";
			ex.Solution(3, 50, htmlFileFullPath, hyperspaceFileFullPath);
		}
	}
}
