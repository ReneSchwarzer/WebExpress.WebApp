using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebExpress.WebApp.WebNotificaation
{
    /// <summary>
    /// Conversion of notification type from and to json.
    /// </summary>
    public class TypeNotificationConverter : JsonConverter<TypeNotification>
    {
        /// <summary>
        /// Read and convert json to TypeNotification.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public override TypeNotification Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (TypeNotification)Enum.Parse(typeof(TypeNotification), reader.GetString(), true);
        }

        /// <summary>
        /// Writes the value as json.
        /// </summary>
        /// <param name="writer">Der writer.</param>
        /// <param name="type">The value.</param>
        /// <param name="options">The options.</param>
        public override void Write(Utf8JsonWriter writer, TypeNotification type, JsonSerializerOptions options)
        {
            writer.WriteStringValue(type.ToClass());
        }
    }
}
