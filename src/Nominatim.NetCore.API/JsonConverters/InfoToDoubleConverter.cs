using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nominatim.NetCore.API.JsonConverters
{
    /// <summary>
    /// [Reference (How to write custom converters for JSON serialization (marshalling) in .NET
    /// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to)]
    /// </summary>
    internal class InfoToDoubleConverter : JsonConverter<double>
    {
        /// <summary>
        /// deserialize 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override double Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            double returnValue = 0;
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                // return (double)jsonDoc.RootElement.GetRawText();
                double d = 0;
                if (Double.TryParse(jsonDoc.RootElement.GetRawText(), out d))
                {
                    returnValue = d;
                }
                

                returnValue = d;
            }

            return returnValue;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
