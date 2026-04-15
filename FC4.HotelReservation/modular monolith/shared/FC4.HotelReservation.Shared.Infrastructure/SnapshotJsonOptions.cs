using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace FC4.HotelReservation.Shared.Infrastructure;

public class SnapshotJsonOptions
{
    private static readonly JsonSerializerOptions Options = CreateOptions();

    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { AllowNonPublicConstructor, AllowNonPublicSetters, ExcludeTransientProperties }
            }
        };
        return options;
    }

    private static void AllowNonPublicConstructor(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        if (typeInfo.CreateObject is not null)
            return;

        typeInfo.CreateObject = () => Activator.CreateInstance(typeInfo.Type, nonPublic: true)!;
    }

    private static void AllowNonPublicSetters(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        foreach (var property in typeInfo.Properties)
        {
            if (property.Set is not null)
                continue;

            var propertyInfo = typeInfo.Type.GetProperty(property.Name,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.IgnoreCase);

            if (propertyInfo is null)
                continue;

            var setter = propertyInfo.GetSetMethod(nonPublic: true);
            if (setter is not null)
            {
                property.Set = (obj, value) => setter.Invoke(obj, [value]);
            }
        }
    }

    private static void ExcludeTransientProperties(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        for (var i = typeInfo.Properties.Count - 1; i >= 0; i--)
        {
            if (typeInfo.Properties[i].Name is "Events")
                typeInfo.Properties.RemoveAt(i);
        }
    }

    public static string Serialize<T>(T aggregate) => JsonSerializer.Serialize(aggregate, aggregate!.GetType(), Options);

    public static T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, Options);
}