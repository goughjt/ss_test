using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using KdTree;
using KdTree.Math;

struct Person
{
	public string Name;
	public int Age;
}

namespace KdTree.Tests
{
	[TestFixture]
	public class PriorityQueueTests
	{
		private PriorityQueue<string, float> queue;
		private List<Person> people;

		[SetUp]
		public void Setup()
		{
			queue = new PriorityQueue<string, float>(2, new FloatMath());
			
			people = new List<Person>();
			people.AddRange(new Person[]
			{
				new Person() { Name = "Chris", Age = 16 },
				new Person() { Name = "Stewie", Age = 1 },
				new Person() { Name = "Brian", Age = 10 },
				new Person() { Name = "Meg", Age = 15 },
				new Person() { Name = "Peter", Age = 41 },
				new Person() { Name = "Lois", Age = 38 }
			});
		}

		[TearDown]
		public void TearDown()
		{
			queue = null;
		}

		//[Test]
		//[Category("PriorityQueue<TItem, TPriority>")]
		//public void TestQueue()
		//{
			//foreach (var person in people)
			//	queue.Enqueue(person.Name, person.Age);

			//var peopleSortedByAgeDesc = people.OrderByDescending(p => p.Age).ToArray();

			//for (var index = 0; index < peopleSortedByAgeDesc.Length; index++)
			//{
			//	var person = peopleSortedByAgeDesc[index];

			//	Assert.AreEqual(person.Name, queue.Dequeue());

			//	Assert.AreEqual(peopleSortedByAgeDesc.Length - index - 1, queue.Count);
			//}

			//Assert.AreEqual(0, queue.Count);
		//}
	}
}
