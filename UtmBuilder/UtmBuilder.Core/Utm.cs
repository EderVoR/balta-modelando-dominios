using UtmBuilder.Core.ValueObjects;

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
    }
}
