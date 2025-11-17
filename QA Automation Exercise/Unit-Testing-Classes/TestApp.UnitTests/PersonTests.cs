using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]

    public void SetUp()
    {
        _person = new Person();
    }

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        // сортиране по възходящ ред
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        Person firstPerson = new Person();
        firstPerson.Name = "Alice";
        firstPerson.Age = 35;
        firstPerson.Id = "A001";

        Person secondPerson = new Person();
        secondPerson.Name = "Bob";
        secondPerson.Age = 30;
        secondPerson.Id = "B002";

        List<Person> expected = new List<Person>();
        expected.Add(firstPerson);
        expected.Add(secondPerson);

        // Act
        List<Person> result = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        for (int i = 0; i < result.Count; i++)
        {
           Assert.That(result[i].Name, Is.EqualTo(expected[i].Name));
           Assert.That(result[i].Id, Is.EqualTo(expected[i].Id));
           Assert.That(result[i].Age, Is.EqualTo(expected[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        //Arrange
        List<Person> person = new List<Person>();
        string expected = $"Bob with ID: B002 is 30 years old.{Environment.NewLine}" + $"Alice with ID: A001 is 35 years old.";

        Person firstPerson = new Person();
        firstPerson.Name = "Alice";
        firstPerson.Age = 35;
        firstPerson.Id = "A001";

        Person secondPerson = new Person();
        secondPerson.Name = "Bob";
        secondPerson.Age = 30;
        secondPerson.Id = "B002";

        
        person.Add(secondPerson);
        person.Add(firstPerson);

        //Act

        string result = _person.GetByAgeAscending(person);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
