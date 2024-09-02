/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",  
  ],
  theme: {
    extend: {
      colors: {
        'normal': '#5482F6',
        'normal-hover': '#4c75dd',
        'primario-light': '#CAD8FC',
        'normal-neutro': '#8e8e93',
      },
      fontFamily: {
        'inter': ['Inter', 'sans-serif'], 
      },
      letterSpacing: {
        'wide': '0.42px', 
      },
      spacing: {
        'tiny': '4px',
        'small': '12px',
        'medium': '16px',
        'base': '24px',
        'large': '48px',
        'x-large': '64px',
        'tiny-ios': '5.5px',
        'small-ios': '16.5px',
        'medium-ios': '22px',
        'base-ios': '27.5px',
        'large-ios': '44px',
        'x-large-ios': '53px',
        'custom-width': '170px',
        'custom-height': '17px',
      }
    }
  },
  plugins: [],
}
