using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
	[TestClass]
	public class CampaignTests
	{
		[TestMethod]
		[DataRow("", "", "", true)]
		[DataRow("utm", "source", "", true)]
		[DataRow("media", "", "", true)]
		[DataRow("media", "medium", "name", false)]
		public void TestCampaign(string source, string medium, string name, bool exceptionError)
		{
			if(exceptionError)
			{
				try
				{
					new Campaign(source, medium, name);
					Assert.Fail();
				}
				catch(InvalidCampaignException)
				{
					Assert.IsTrue(true);
				}
			}
			else
			{
				new Campaign(source, medium, name);
				Assert.IsTrue(true);
			}
		}
	}
}
