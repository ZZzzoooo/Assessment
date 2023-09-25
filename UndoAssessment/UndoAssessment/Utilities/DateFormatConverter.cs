using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace UndoAssessment.Utilities
{
    public class CustomDateTimeConverter : DateTimeConverterBase
    {
        private const string Format = "dd.MM.yyyy HH:mm:ss";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(Format));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact((string)reader.Value, Format, CultureInfo.InvariantCulture);
        }
    }
}
