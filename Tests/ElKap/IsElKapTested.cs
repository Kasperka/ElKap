using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElKap.Tests.ElKap
{
	[TestClass] public class IsSoftTested : IsAssemblyTested
	{
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"ElKap.ElKap\"");
    }
}

