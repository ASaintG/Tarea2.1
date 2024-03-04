using Tarea2._1.Models;

namespace Tarea2._1.servicios
{
	public interface CountryService
	{
		public Task<List<Countrys>> Obtener();
        public Task<List<Countrys>> ObtenerRegion(string region);

    }
}
