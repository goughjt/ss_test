using System;
using KdTree;
using KdTree.Math;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SpencerStuartTest.ThreeJS;

namespace SpencerStuartTest.Exercise2
{
	/// <summary>
	/// Exercise2 solution is still far from perfect.
	/// I think the answer should look like this:
	/// http://math.stackexchange.com/questions/1964272/finding-the-farthest-point-within-a-cube-from-a-set-of-n-other-points
	/// </summary>
	public class Exercise
	{
		private KdTree<int, int> tree;

		//Only one html file will be made and it will be for the first test class.
		SceneBuilder exampleHtmlSceneBuilder;

		public void Solution(int numTestCases, int numBombs, string htmlFileFullPath, string hyperspaceFileFullPath)
		{
			if (numTestCases < 1 || numTestCases > 10 || numBombs < 3 || numBombs > 50)
				return;

			exampleHtmlSceneBuilder = new SceneBuilder(htmlFileFullPath);
			CreateNewHyperspace(numTestCases, numBombs, hyperspaceFileFullPath);

			bool htmlFileMade = false;

			foreach (var horrificSituation in ReadInputFile(hyperspaceFileFullPath))
			{

				//1 Make a kdtree
				tree = new KdTree<int, int>(3, new IntMath());
				foreach (var bomb in ParseTestCaseLine(horrificSituation))
					tree.Add(bomb.Item1, bomb.Item2);

				//2 balance the tree once all bombs/nodes have been added
				tree.Balance();

				//3. find the most remote bomb
				var greatestNNDistance = 0;
				var mostRemoteBomb = tree.First();

				foreach (var node in tree)
				{
					var nodeNearestNeighbourDistance = SquaredDistanceToNearestNeighbour(node.Point);
					if (nodeNearestNeighbourDistance > greatestNNDistance)
					{
						mostRemoteBomb = node;
						greatestNNDistance = nodeNearestNeighbourDistance;
					}
				}

				//4. Consider the hyperrects of the remotest bomb
				var largestConnectedHyperrect = LargestConnectedHyperrect(mostRemoteBomb);
				//Let's settle for the centre of this rectangle as the safest point.
				var safestPoint = new int[] {(largestConnectedHyperrect.MaxPoint[0] + largestConnectedHyperrect.MinPoint[0]) / 2,(largestConnectedHyperrect.MaxPoint[1] + largestConnectedHyperrect.MinPoint[1]) / 2, (largestConnectedHyperrect.MaxPoint[2] + largestConnectedHyperrect.MinPoint[2]) / 2};

				if (!htmlFileMade)
				{
					exampleHtmlSceneBuilder.AddSafestPoint(safestPoint);
					exampleHtmlSceneBuilder.Finish();
					htmlFileMade = true;
				}

				//5 The requirements specicifically ask for the distance to the safest point's nearest neighbour.
				var requiredDistanceValue = SquaredDistanceToNearestNeighbour(safestPoint);
			}
		}

		private int SquaredDistanceToNearestNeighbour(int[] point)
		{
			IntMath fy = new IntMath();
			var nodeNearestNeighbours = tree.GetNearestNeighbours(point, tree.Count());
			var nodeNearestNeighbour = nodeNearestNeighbours.First(x => x.Point != point);
			var nodeNearestNeighbourPoint = nodeNearestNeighbour.Point;
			return fy.DistanceSquaredBetweenPoints(nodeNearestNeighbourPoint, point);
		}

		private HyperRect<int> LargestConnectedHyperrect(KdTreeNode<int, int> node)
		{
			if (node.IsLeaf)
			{
				return area(node.LeftRect) > area(node.RightRect) ? node.LeftRect : node.RightRect;
			}
			else
			{
				var leftSide = node.LeftChild == null ? node.LeftRect : LargestConnectedHyperrect(node.LeftChild);
				var rightSide = node.RightChild == null ? node.RightRect : LargestConnectedHyperrect(node.RightChild);
				return area(leftSide) > area(rightSide) ? leftSide : rightSide;
			}
		}

		private int area(HyperRect<int> rect)
		{
			var returnInt = 1;
			for (int i = 0; i < 3; i++)
			{
				returnInt = returnInt * (rect.MaxPoint[i] - rect.MinPoint[i]);
			}
			return returnInt < 0 ? -returnInt : returnInt;
		}

		/// <summary>
		/// An ugly parser for text line to aray of 3d points (input samples). Assumes 3D.
		/// </summary>
		/// <returns>The test case line.</returns>
		/// <param name="line">Line.</param>
		private static IEnumerable<Tuple<int[], int>> ParseTestCaseLine(string line)
		{
			var inty = 0;

			var coords = line.Split(',');
			//The smelliest of code smells...
			int coordCountInt = 0;
			int x_coord = 0, y_coord = 0, z_coord=0;
			foreach (var item in coords.Skip(1))
			{
				switch (coordCountInt)
				{
					case 0:
						int.TryParse(item, out x_coord);
						coordCountInt++;
						break;

					case 1:
						
						int.TryParse(item, out y_coord);
						coordCountInt++;
						break;
						
					case 2:
					default:
						int.TryParse(item, out z_coord);
						yield return Tuple.Create(new int[3] { x_coord, y_coord, z_coord}, inty);
						break;
				}
			}


		}

		/// <summary>
		/// Reads the input file and yield returns each line except the first line
		/// </summary>
		/// <returns>The input file.</returns>
		/// <param name="fileName">File name.</param>
		private static IEnumerable<string> ReadInputFile(string hyperspaceFileFullPath)
		{
			//TODO Should do validation of data now but I will not, just to get this done
			using (var reader = File.OpenText(hyperspaceFileFullPath))
			{	
				//don't need first line
				reader.ReadLine();
				while (!reader.EndOfStream)
					yield return reader.ReadLine();
			}
		}

		public void CreateNewHyperspace(int numTestCases, int numBombs, string hyperspaceFileFullPath)
		{
			if (numTestCases <= 0 || numBombs <= 0)
				return;
			Random rand = new Random();
			var stream = File.CreateText(hyperspaceFileFullPath);
			stream.WriteLine(numTestCases);
			for (int i = 0; i < numTestCases; i++)
			{
				stream.Write(numBombs);
				for (int j = 0; j < numBombs; j++)
				{
					var point = new int[3];
					for (int k = 0; k < 3; k++)
					{
						stream.Write(",");
						var nextRand = rand.Next(0, 1000);
						stream.Write(nextRand);
						point[k] = nextRand;
					}
					if (i == 0)
						exampleHtmlSceneBuilder.AddBomb(point);
				}
				stream.WriteLine();
			}
			stream.Close();

		}
	}
}
