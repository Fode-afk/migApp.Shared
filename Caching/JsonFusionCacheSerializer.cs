using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ZiggyCreatures.Caching.Fusion.Serialization;

namespace migApp.Shared.Caching;

public sealed class JsonFusionCacheSerializer : IFusionCacheSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };
  
    public byte[] Serialize<T>(T? obj)
    {
        if (obj == null) return Array.Empty<byte>();
        return JsonSerializer.SerializeToUtf8Bytes(obj, _options);
    }

    public ValueTask<byte[]> SerializeAsync<T>(T? obj, CancellationToken token = default)
    {
        if (obj == null) return ValueTask.FromResult(Array.Empty<byte>());
        return ValueTask.FromResult(JsonSerializer.SerializeToUtf8Bytes(obj, _options));
    }

    public T? Deserialize<T>(byte[] data)
    {
        if (data == null || data.Length == 0) return default;
        return JsonSerializer.Deserialize<T>(data, _options);
    }

    public ValueTask<T?> DeserializeAsync<T>(byte[] data, CancellationToken token = default)
    {
        if (data == null || data.Length == 0) return ValueTask.FromResult<T?>(default);
        return ValueTask.FromResult(JsonSerializer.Deserialize<T>(data, _options));
    }
}
