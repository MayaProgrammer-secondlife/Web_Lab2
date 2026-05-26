using Microsoft.JSInterop;

namespace AtelierWasm.Services;

public sealed class LocalStorageService(IJSRuntime jsRuntime)
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;

    public ValueTask<string?> GetAsync(string key)
        => _jsRuntime.InvokeAsync<string?>("rbStorage.get", key);

    public ValueTask SetAsync(string key, string value)
        => _jsRuntime.InvokeVoidAsync("rbStorage.set", key, value);
}
