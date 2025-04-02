using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;

public sealed record CursorRestaurant(string Name)
{
    public static string Encode(string name)
    {
        var cursor = new CursorRestaurant(name);
        string json = JsonSerializer.Serialize(cursor);
        
        return Base64UrlTextEncoder.Encode(Encoding.UTF8.GetBytes(json));
    }

    public static CursorRestaurant? Decode(string cursor)
    {
        if (string.IsNullOrEmpty(cursor))
        {
            return null;
        }

        try
        {
            string json = Encoding.UTF8.GetString(Base64UrlTextEncoder.Decode(cursor));
            
            return JsonSerializer.Deserialize<CursorRestaurant>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}