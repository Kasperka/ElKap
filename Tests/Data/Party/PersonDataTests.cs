using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElKap.Data.Party;

namespace ElKap.Tests.Data.Party
{
    [TestClass]
	public class PersonDataTests: BaseTests<PersonData>
	{ 
		[TestMethod] public void IdTest() => isProperty<string>();

		[TestMethod] public void FirstNameTest() => isProperty<string?>();

		[TestMethod] public void LastNameTest() => isProperty<string?>();

		[TestMethod] public void GenderTest() => isProperty<bool?>();

		[TestMethod] public void DoBTest() => isProperty<DateTime?>();
	}
}