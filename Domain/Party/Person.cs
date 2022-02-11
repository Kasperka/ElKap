using System;
using Data.Party;
namespace Domain.Party
{
	public class Person
	{
		private const string defaultStr = "Undefined";
		private const bool defaultGender = true;
		private DateTime defaultDate => DateTime.MinValue;
		private PersonData data;

		public Person() : this(new PersonData()) { }
		public Person(PersonData d) => data = d;
		public string Id => data?.Id ?? defaultStr;
		public string FirstName => data?.FirstName ?? defaultStr;
		public string LastName => data?.LastName ?? defaultStr;
		public bool Gender => data?.Gender ?? defaultGender;
		public DateTime DoB => data?.DoB ?? defaultDate;
		public PersonData Data => data;

		public override string ToString() => $"{FirstName} {LastName} ({Gender}, {DoB})";
    }
}

