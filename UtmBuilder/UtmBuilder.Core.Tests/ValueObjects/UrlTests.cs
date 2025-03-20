using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
	[TestClass]
	public class UrlTests
	{
		private const string InvalidUrl = "banana";
		private const string ValidUrl = "https://balta.io";

		[TestMethod]
		[ExpectedException(typeof(InvalidUrlException))]
		public void DeveRetornarUmaExcecaoQuandoUrlForInvalido()
		{
			new Url(InvalidUrl);
			//try
			//{
			//	var url = new Url("banana");
			//	Assert.Fail();
			//}
			//catch(InvalidUrlException ex)
			//{
			//	Assert.IsTrue(true);
			//}
		}

		[TestMethod]
		public void NãoDeveRetornarUmaExcecaoQuandoUrlForValido()
		{
			new Url(ValidUrl);
		}

		[TestMethod]
		[DataRow(" ", true)]
		[DataRow("http", true)]
		[DataRow("banana", true)]
		[DataRow("https://balta.io", false)]
		public void TestUrl(string link, bool expectException)
		{
			if(expectException)
			{
				try
				{
					new Url(link);
					Assert.Fail();
				}
				catch(InvalidUrlException)
				{
					Assert.IsTrue(true);
				}
			}
		}
	}
}
