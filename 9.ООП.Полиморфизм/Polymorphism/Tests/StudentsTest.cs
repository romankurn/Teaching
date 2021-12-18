using FluentAssertions;
using Moq;
using NUnit.Framework;
using Polymorphism;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tests
{
	[TestFixture]
	public class Tests
	{
		private Student _student;
		private University _university;

		private Mock<IStudentCollection> _studentCollectionMock = new Mock<IStudentCollection>();

		private List<Student> _fakeStudents1 = new List<Student>();
		private List<Student> _fakeStudents2 = new List<Student>();
		private List<Student> _fakeStudents3 = new List<Student>();

		[OneTimeSetUp]
		public void CallBeforeAll()
		{
			_student = new Student($"{Guid.NewGuid()}", 1, "1", 1);
			_university = new University(new StudentCollectionWrapper());

			StudentTestHelper.AddFakeStudent(_student);

			_fakeStudents1.Add(new Student("name1", 1, "1", 1));
			_fakeStudents1.Add(new Student("name1", 2, "2", 1));
		}

		[SetUp]
		public void CallBeforeEvery()
		{
			Debug.WriteLine("Test will be started after this method finish");
		}

		[TearDown]
		public void ClearAfterEvery()
		{
			Debug.WriteLine("Test completed");
		}

		[OneTimeTearDown]
		public void ClearAfterAll()
		{
			StudentTestHelper.RemoveStudentById(_student.Id);
		}

		//"All tests will be started after this method finish"
		//"Test will be started after this method finish"
		//"PersonCloneTest"
		//"Test completed"
		//"Test will be started after this method finish"
		//"PersonToStringTest"
		//"Test completed"
		//"All tests completed"

		[Test]
		public void PersonCloneTest()
		{
			Debug.WriteLine("PersonCloneTest");

			var person1 = new Person("Person1", 1);
			var person2 = (Person)person1.Clone();

			person2.Name.Should().Be("Person1");
			person2.Age.Should().Be(1);

			person1.Name = "newName";
			person1.Age = 11;

			person2.Name.Should().Be("Person1");
			person2.Age.Should().Be(1);
		}

		[Test]
		public void PersonToStringTest()
		{
			Debug.WriteLine("PersonToStringTest");

			var person = new Person("Name1", 1);
			var str = person.ToString();

			str.Should().Be("Person. Name: Name1, Age: 1");
		}

		[Test]
		public void PersonEqualsTest()
		{
			Debug.WriteLine("PersonEqualsTest");

			var person1 = new Person("Name1", 1);
			var person2 = new Person("Name2", 2);
			var person3 = new Person("Name1", 1);
			var person4 = new Person("Name2", 1);
			var person5 = new Person("Name1", 2);

			person1.Equals(person2).Should().BeFalse();
			person1.Equals(person3).Should().BeTrue();
			person1.Equals(person4).Should().BeFalse();
			person1.Equals(person5).Should().BeFalse();
		}

		[Test]
		public void PersonEqualsOtherObjectsTest()
		{
			Debug.WriteLine("PersonEqualsOtherObjectsTest");

			var person1 = new Person("Name1", 1);
			var student1 = new Student("Name1", 1, "f1", 1);

			person1.Equals(student1).Should().BeFalse();
			student1.Equals(person1).Should().BeFalse();

			person1.Equals("person1").Should().BeFalse();
		}

		[Test]
		public void GetStudentByNameTest()
		{
			var students = _university.GetStudentsByName(_student.Name).ToList();

			students.Count.Should().Be(1);
			students[0].Equals(_student).Should().BeTrue();
		}


		[Test] 
		public void GetStudentByNameWithMoqTest()
		{
			_studentCollectionMock.Setup(r => r.GetStudents("name1")).Returns(_fakeStudents1);

			_university = new University(_studentCollectionMock.Object);

			var students = _university.GetStudentsByName("name1").ToList();

			students.Count.Should().Be(2);
			students[0].Equals(_fakeStudents1[0]).Should().BeTrue();
			students[1].Equals(_fakeStudents1[1]).Should().BeTrue();
		}
	}
}