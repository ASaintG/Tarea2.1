using Tarea2._1.servicios;
using Tarea2._1.Models;
namespace Tarea2._1
{
	public partial class MainPage : ContentPage
	{
		int count = 0;
		private readonly CountryService countryService;
		public MainPage(CountryService service)
		{
			InitializeComponent();
			countryService = service;
		}

		private async void OnCounterClicked(object sender, EventArgs e)
		{
			
			loading.IsVisible = true;
			var data = await countryService.Obtener();
			listViewCountrys.ItemsSource = data;

			searchStackLayout.IsVisible = true;
			CounterBtn.IsVisible = false;
		}
		private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			string searchText = e.NewTextValue;
			if (!string.IsNullOrWhiteSpace(searchText))
			{
				// Filtrar los países según el texto de búsqueda
				var filteredCountries = listViewCountrys.ItemsSource.Cast<Countrys>()
					.Where(country => country.name.ToLower().Contains(searchText.ToLower()))
					.ToList();

				listViewCountrys.ItemsSource = filteredCountries;
			}
			else
			{
				// Si el campo de búsqueda está vacío, mostrar todos los países
				OnCounterClicked(sender, e);
			}
		}

		
	}

}
