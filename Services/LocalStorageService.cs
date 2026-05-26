using Microsoft.JSInterop;

namespace AtelierWasm.Services;

/// <summary>
/// Обёртка над localStorage через JS interop (функции window.rbStorage).
/// </summary>
public sealed class LocalStorageService(IJSRuntime jsRuntime)
{
    private readonly IJSRuntime _jsRuntime = jsRuntime;

    public ValueTask<string?> GetAsync(string key)
        => _jsRuntime.InvokeAsync<string?>("rbStorage.get", key);

    public ValueTask SetAsync(string key, string value)
        => _jsRuntime.InvokeVoidAsync("rbStorage.set", key, value);
}
