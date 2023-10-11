/** @type {import('tailwindcss').Config} */
module.exports = {
  prefix: "tw-",
  corePlugins: {
    preflight: false,
  },
  content: [
    './TreasureCache.Presentation/Pages/**/*.cshtml',
    './TreasureCache.Presentation/Views/**/*.cshtml',
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

