using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
	public class Url : ValueObject
	{
		/// <summary>
		/// Endereço principal da URL
		/// </summary>
		/// <param name="adress">Parametro de endereço principal</param>
		public Url(string adress)
        {
            InvalidUrlException.ThrowIfInvalid(adress);
            Adress = adress;
        }

        ///<sumary>
        /// Endereço principal da URL
        ///</sumary>
        public string Adress { get; }
    }
}