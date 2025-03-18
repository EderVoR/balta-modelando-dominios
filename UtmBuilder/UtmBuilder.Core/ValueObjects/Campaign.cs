using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
	public class Campaign : ValueObject
	{
        public Campaign(string source, string medium, string name, 
			string? id = null, string? term = null, string? content = null)
        {
            Source = source;
			Medium = medium;
			Name = name;
			Id = id;
			Term = term;
			Content = content;

			InvalidCampaignException.ThrowIfInvalid(source, "Source inválido");
			InvalidCampaignException.ThrowIfInvalid(medium, "Medium invalido");
			InvalidCampaignException.ThrowIfInvalid(name, "Name invalido");
        }

        public string Source { get; }
		public string Medium { get; }
		public string Name { get; }
		public string? Id { get; }
		public string? Term { get; }
		public string? Content { get; }
	}
}
