using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Tarea2._1.Models;

namespace Tarea2._1;

public partial class Mapita : ContentPage
{
	public Mapita(double latitude, double longitude, Countrys country)
	{
		InitializeComponent();

        var pin = new Pin
        {            
            Label = $"País: {country.name}\nPoblación: {country.pobla}\nÁrea territorial: {country.area} km²",
            Location = new Location(latitude, longitude), // Usar Position en lugar de Location
            Type = PinType.Place
        };

        // Agregar el pin al mapa
        mapa.Pins.Add(pin);
        // Centrar el mapa en la ubicación del pin
        mapa.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromKilometers(100)));
    }
}