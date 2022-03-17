using System;
using ElKap.Data.Party;
using ElKap.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace ElKap.Infra.Party
{
    public class PersonsRepo : Repo<Person, PersonData>, IPersonsRepo
    {
        public PersonsRepo(DbContext c, DbSet<PersonData> s) : base(c, s) { }

        protected override Person toDomain(PersonData d) => new Person(d);
    }
}

