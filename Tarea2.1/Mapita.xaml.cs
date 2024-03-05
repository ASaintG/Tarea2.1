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

        // Construir la descripción del punto
        StringBuilder description = new StringBuilder();
        description.AppendLine($"País: {country.name}");
        description.AppendLine($"Población: {country.pobla}");
        description.AppendLine($"Área territorial: {country.area} km²");

        // Asignar la descripción al pin
        pin.Label = description.ToString();

        mapa.Pins.Add(pin);
        mapa.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromKilometers(100)));
    }
}