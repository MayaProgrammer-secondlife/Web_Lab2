(function () {
    "use strict";

    var THEME_KEY = "atelier_theme";

    function setTheme(theme) {
        document.documentElement.setAttribute("data-theme", theme);
        try { localStorage.setItem(THEME_KEY, theme); } catch (_) {}
    }

    function loadTheme() {
        var saved = null;
        try { saved = localStorage.getItem(THEME_KEY); } catch (_) {}
        if (saved === "dark" || saved === "light") {
            setTheme(saved);
        } else if (window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches) {
            setTheme("dark");
        } else {
            setTheme("light");
        }
    }

    loadTheme();

    document.addEventListener("click", function (e) {
        if (e.target && e.target.id === "theme-toggle") {
            var isDark = document.documentElement.getAttribute("data-theme") === "dark";
            setTheme(isDark ? "light" : "dark");
        }
    });
})();