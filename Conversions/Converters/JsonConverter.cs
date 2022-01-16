using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Conversions.Converters
{
    public class JsonConverter<T> : ValueConverter<T, string>
    {
        public JsonConverter()
            : this(null)
        {

        }

        public JsonConverter(JsonSerializerOptions options)
            : base(
                    item => JsonSerializer.Serialize(item, options),
                    value => JsonSerializer.Deserialize<T>(value, options)
                )                                  
        {

        }
    }
}
