import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    port: 3000, // or any other port like 5174, 8080, etc.
    host: '0.0.0.0' // This helps with some network issues
  }
})