﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using KdTree;
using KdTree.Math;

struct Planet
{
	public string Name;
	public float DistanceFromEarth;
}

namespace KdTree.Tests
{
	[TestFixture]
	public class NearestNeighbourListTests
	{
		private NearestNeighbourList<Planet, float> nearestNeighbours;
		private List<Planet> neighbouringPlanets;

		[SetUp]
		public void Setup()
		{
			nearestNeighbours = new NearestNeighbourList<Planet, float>(5, new FloatMath());

			neighbouringPlanets = new List<Planet>();
			neighbouringPlanets.AddRange(new Planet[]
			{
				new Planet() { Name = "Mercury", DistanceFromEarth =   91700000f },
				new Planet() { Name = "Venus",   DistanceFromEarth =   41400000f },
				new Planet() { Name = "Mars",    DistanceFromEarth =   78300000f },
				new Planet() { Name = "Jupiter", DistanceFromEarth =  624400000f },
				new Planet() { Name = "Saturn",  DistanceFromEarth = 1250000000f },
				new Planet() { Name = "Uranus",  DistanceFromEarth = 2720000000f },
				new Planet() { Name = "Neptune", DistanceFromEarth = 4350000000f }
			});
		}

		[TearDown]
		public void TearDown()
		{
			nearestNeighbours = null;
		}

		private void AddItems()
		{
			foreach (var planet in neighbouringPlanets)
			{
				nearestNeighbours.Add(planet, planet.DistanceFromEarth);
			}
		}

		[Test]
		[Category("NearestNeighbourList")]
		public void TestAddAndCount()
		{
			AddItems();

			Assert.AreEqual(5, nearestNeighbours.Count);
		}

		[Test]
		[Category("NearestNeighbourList")]
		public void TestRemoveFurtherest()
		{
			AddItems();

			var sortedPlanets = neighbouringPlanets
				.OrderBy(p => p.DistanceFromEarth)
				.Take(5)
				.OrderByDescending(p => p.DistanceFromEarth)
				.ToArray();

			for (var index = 0; index < sortedPlanets.Length; index++)
			{
				Assert.AreEqual(
					sortedPlanets[index].Name,
					nearestNeighbours.RemoveFurtherest().Name);
			}

			Assert.AreEqual(0, nearestNeighbours.Count);
		}
	}
}
