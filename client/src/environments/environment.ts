interface EnvironmentGlobals {
  process?: {
    env?: Record<string, string | undefined>
  }
}

const backendUrl =
  (globalThis as EnvironmentGlobals).process?.env?.['BackendURL'] ?? 'https://localhost:7035/api'

export const environment = {
  apiUrl: backendUrl,
}
