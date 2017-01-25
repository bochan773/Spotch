
using Plugin.Geolocator;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Spotch.Controller
{
    class GeoManager
    {
        /* Plugin.Geolocator.Abstractions */
        public Plugin.Geolocator.Abstractions.Position geo_position;
        public Xamarin.Forms.GoogleMaps.Position google_position;

        // return CurrentPosition
        public async Task<Xamarin.Forms.GoogleMaps.Position> getCurrent()
        {
            Plugin.Geolocator.Abstractions.IGeolocator locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50; // <- 1. 50mの精度に指定

            geo_position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            google_position = convertPosition(geo_position);

            return google_position;
        }
        
        // Convert Geolocator.Abstractions.Position to GoogleMaps.Position
        public Xamarin.Forms.GoogleMaps.Position convertPosition(Plugin.Geolocator.Abstractions.Position instance)
        {
            Xamarin.Forms.GoogleMaps.Position p = 
                new Xamarin.Forms.GoogleMaps.Position(
                    instance.Latitude,
                    instance.Longitude
                    );
            return p;
        }

    }
}
