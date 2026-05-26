// Обёртка над localStorage, вызываемая из C# через JS interop.
// Должна быть загружена ДО blazor.webassembly.js.
window.rbStorage = {
    get: function (key) {
        try {
            return localStorage.getItem(key);
        } catch {
            return null;
        }
    },
    set: function (key, value) {
        try {
            localStorage.setItem(key, value);
        } catch {
            /* игнорируем ошибки квоты / приватного режима */
        }
    }
};
