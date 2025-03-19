﻿using System.Reflection.Metadata.Ecma335;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;
using UtmBuilder.Core.ValueObjects.Extensions;

namespace UtmBuilder.Core
{
	public class Utm
	{
        public Utm(Url url, Campaign campaign)
        {
            Url = url;
            Campaign = campaign;
        }
        /// <summary>
        /// Url Principal
        /// </summary>
        public Url Url { get; set; }

        /// <summary>
        /// Dados da campanha
        /// </summary>
        public Campaign Campaign { get; set; }

        public static implicit operator string(Utm utm)
            => utm.ToString();

        public static implicit operator Utm(string link)
        {
            if (string.IsNullOrEmpty(link))
                throw new InvalidUrlException();

            var url = new Url(link);
            var segments = url.Adress.Split("?");

            if (segments.Length == 1)
                throw new InvalidUrlException("Segmentos não informados na URL");

            var pars = segments[1].Split("&");
            var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
			var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
			var campaign = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
			var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
			var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
			var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

            var utm = new Utm(new Url(segments[0]), new Campaign(source, medium, campaign, id, term, content));
            return utm;
		}

		public override string ToString()
		{
            var segments = new List<string>();
            segments.AddIfNotNull("utm_source", Campaign.Source);
			segments.AddIfNotNull("utm_medium", Campaign.Medium);
			segments.AddIfNotNull("utm_campaign", Campaign.Name);
			segments.AddIfNotNull("utm_id", Campaign.Id);
			segments.AddIfNotNull("utm_term", Campaign.Term);
			segments.AddIfNotNull("utm_content", Campaign.Content);
			return $"{Url.Adress}?{string.Join("&", segments)}";
		}
	}
}
