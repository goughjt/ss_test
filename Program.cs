using System;

namespace SpencerStuartTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{	
			Console.WriteLine(@"
ΣΣΣ	To see proof of solutions to exercises, please install Nunit and then run the unit tests.

Exercise 1 -FINISHED- the code explains itself

Exercise 2 -PARTIALLY_FINISHED- uses KD Tree technique to find most remote sample node and assumes ""safest point"" is somewhere in the largest child-connected hypersphere. It also makes a super sweet firstTestCaseHyperspace.html file (see htmlFileFullPath).

Exercise 2 uses modified KdTree implementation by https://github.com/codeandcats/KdTree
	and htmlFileFullPath template taken from https://github.com/stemkoski/stemkoski.github.com/tree/master/Three.js (the ""Helpers"" example).

Exercise 3 -FINISHED- the code explains itself

");
			Console.ReadKey();
		}
	}
}
