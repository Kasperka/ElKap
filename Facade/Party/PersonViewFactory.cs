using System;
using Data.Party;
using Domain.Party;
namespace Facade.Party
{
	public class PersonViewFactory
	{
		public Person Create(PersonView v) => new(new PersonData {
			Id = v.Id,
			FirstName = v.FirstName,
			LastName = v.LastName,
			Gender = v.Gender,
			DoB = v.DoB,
		});

		public PersonView Create(Person o) => new() { 
			Id = o.Id,
			FirstName = o.FirstName,
			LastName = o.LastName,
			Gender = o.Gender,
			DoB = o.DoB,
            FullName = o.ToString()
		};
	}
}

