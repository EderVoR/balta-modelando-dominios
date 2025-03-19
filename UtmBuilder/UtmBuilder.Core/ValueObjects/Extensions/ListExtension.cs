namespace UtmBuilder.Core.ValueObjects.Extensions
{
	public static class ListExtension
	{
		public static void AddIfNotNull(this List<string> list, string key, string? value)
		{
			if (!string.IsNullOrEmpty(value))
				list.Add($"{key}={value}");
		}
	}
}
