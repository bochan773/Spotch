using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace Spotch.Controller
{
    class MapManager
    {
        /*
        private readonly Map _map;
        public MapManager(Map map)
        {
            this._map = map;
        }

        public async Task<IEnumerable<Position>> FindAddress(string addressQuery)
        {
            var geoCoder = new Geocoder();
            var locations = await geoCoder.GetPositionsForAddressAsync(addressQuery);
            return locations;
        }

        public void ClearAllPins()
        {
            _map.Pins.Clear();
        }

        public void AddLocationPins(IEnumerable<Position> positions)
        {
            Pin pin = null;
            foreach (var position in positions)
            {
                pin = new Pin
                {
                    Type = PinType.Generic,
                    Position = position,
                    Label = ""
                };
                _map.Pins.Add(pin);
            }
            if (null != pin)
            {
                FocusMapToPosition(pin.Position, AppDefaults.MapFocusRegion);
            }
        }

        public void FocusMapToPosition(Position position, double regionRadius)
        {
            var mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromMiles(regionRadius));
            this._map.MoveToRegion(mapSpan);
        }
        */
    }
}
