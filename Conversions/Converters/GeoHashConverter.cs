using Conversions.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NGeoHash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions.Converters
{
    internal class GeoHashConverter : ValueConverter<Coordinate, string>
    {
        public GeoHashConverter()
            : base(
                  coordinate => coordinate.ToGeoHash(),
                  value => value.ToCoordinate()
                  )
        {
        }
    }

    // Install-Package NGeoHash
    public static class CoordinateExtensions
    {
        public static string ToGeoHash(this Coordinate coordinate) => GeoHash.Encode(coordinate.Latitude, coordinate.Longitude);

        public static Coordinate ToCoordinate(this string geoHash)
        {
            var decoded = GeoHash.Decode(geoHash);

            return new Coordinate(decoded.Coordinates.Lat, decoded.Coordinates.Lon);
        }
        
    }

}
