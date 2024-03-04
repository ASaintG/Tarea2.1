using Tarea2._1.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Tarea2._1.servicios
{
	public class CountryServices : CountryService
	{
		private string uriApi = "https://restcountries.com/v3.1/all";

		public async Task<List<Countrys>> Obtener()
		{
			var client = new HttpClient();
			var response = await client.GetAsync(uriApi);
			var responseBody = await response.Content.ReadAsStringAsync();

			// Deserializar la respuesta en un JsonDocument
			using var doc = JsonDocument.Parse(responseBody);

			// Obtener la raíz del documento
			JsonElement root = doc.RootElement;

			// Crear una lista para almacenar los países
			List<Countrys> countries = new List<Countrys>();

			// Iterar a través de los elementos del array de países
			foreach (JsonElement countryElement in root.EnumerateArray())
			{
				// Obtener el nombre común y la bandera de cada país
				string name = countryElement.GetProperty("name").GetProperty("common").GetString();
				string flag = countryElement.GetProperty("flags").GetProperty("png").GetString();

				// Crear un objeto Countrys y agregarlo a la lista
				var country = new Countrys
				{
					name = name,
					flags = flag
				};

				countries.Add(country);
			}

			return countries;
		}
	}
}
