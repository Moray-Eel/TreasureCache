/** @type {import('tailwindcss').Config} */
module.exports = {
  corePlugins: {
    preflight: false,
  },
  content: [
    './TreasureCache.Presentation/Pages/**/*.cshtml',
    './TreasureCache.Presentation/Views/**/*.cshtml',
    "./**/*.razor", "./**/*.cshtml", "./**/*.html"
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/aspect-ratio'),
    require('@tailwindcss/typography'),
    require('tailwindcss-children'),
  ],
}

