using System.Text.Json;

namespace Fleury.Extensions;

public static class CloneExtension
{
    public static T Clone<T>(this T? obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Object to clone cannot be null.");
        }
        string jsonString = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }
}
