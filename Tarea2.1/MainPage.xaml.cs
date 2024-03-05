using Tarea2._1.servicios;
using Tarea2._1.Models;
namespace Tarea2._1
{
    public partial class MainPage : ContentPage
    {
        private readonly CountryService countryService;
        private const int MaxDisplayedCountries = 60;
        public MainPage(CountryService service)
        {
            InitializeComponent();
            countryService = service;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            var data = await countryService.Obtener();
            listViewCountrys.ItemsSource = data.Take(MaxDisplayedCountries).ToList();
            searchStackLayout.IsVisible = true;
            CounterBtn.IsVisible = false;
        }

        private async void OnRegionSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedRegion = picker.SelectedItem as string;

            if (selectedRegion != null)
            {
                loading.IsVisible = true;
                var data = await countryService.ObtenerRegion(selectedRegion);
                listViewCountrys.ItemsSource = data.Take(MaxDisplayedCountries).ToList();
            }
        }


        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                // Filtrar los países según el texto de búsqueda
                var filteredCountries = (listViewCountrys.ItemsSource as List<Countrys>)
                    .Where(country => country.name.ToLower().Contains(searchText.ToLower()))
                    .ToList();

                listViewCountrys.ItemsSource = filteredCountries.Take(MaxDisplayedCountries).ToList();
            }
            else
            {
                // Si el campo de búsqueda está vacío, mostrar todos los países
                OnCounterClicked(sender, e);
            }
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is Countrys selectedCountry)
            {
                bool answer = await DisplayAlert("Confirmación", $"¿Deseas ir a {selectedCountry.name}?", "Sí", "No");
                if (answer)
                {
                    // Pasar la latitud y longitud al constructor de Mapita
                    await Navigation.PushAsync(new Mapita(selectedCountry.lati, selectedCountry.longi, selectedCountry));
                }
            }

            ((ListView)sender).SelectedItem = null; // Desactivar el resaltado del elemento seleccionado
        }
    }
}