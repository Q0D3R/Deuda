{
  "exclude": [
    "**/bin",
    "**/bower_components",
    "**/jspm_packages",
    "**/node_modules",
    "**/obj",
    "**/platforms"
  ]
}

// wwwroot/js/theme.js
window.setTheme = (isDark) => {
    document.body.classList.toggle('dark-mode', isDark);
};
