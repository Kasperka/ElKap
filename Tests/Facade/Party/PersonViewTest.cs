using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElKap.Facade.Party;

namespace ElKap.Tests.Facade.Party
{
	[TestClass]
	public class PersonViewTest: BaseTests<PersonView>
	{
		[TestMethod] public void IdTest() => isProperty<string>();

		[TestMethod] public void FirstNameTest() => isProperty<string?>();

		[TestMethod] public void LastNameTest() => isProperty<string?>();

        [TestMethod] public void GenderTest() => isProperty<bool?>();

		[TestMethod] public void DoBTest() => isProperty<DateTime?>();

		[TestMethod] public void FullNameTest() => isProperty<string?>();
	}
}

