using System.Text.Json.Serialization;

namespace Company.Function.Model;

public record Person([property: JsonPropertyName("name")] string Name, [property: JsonPropertyName("age")] int Age);