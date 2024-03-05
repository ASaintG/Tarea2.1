using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Text;
using Tarea2._1.Models;

namespace Tarea2._1;

public partial class Mapita : ContentPage
{
    public Mapita(double latitude, double longitude, Countrys country)
    {
        InitializeComponent();

        var pin = new Pin
        {
            Label = country.name,
            Location = new Location(latitude, longitude),
            Type = PinType.Place
        };

        // Construir la descripci�n del punto
        StringBuilder description = new StringBuilder();
        description.AppendLine($"Pa�s: {country.name}");
        description.AppendLine($"Poblaci�n: {country.pobla}");
        description.AppendLine($"�rea territorial: {country.area} km�");

        // Asignar la descripci�n al pin
        pin.Label = description.ToString();

        mapa.Pins.Add(pin);
        mapa.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromKilometers(100)));
    }
}