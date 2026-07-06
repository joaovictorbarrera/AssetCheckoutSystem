interface EnvironmentGlobals {
  process?: {
    env?: Record<string, string | undefined>
  }
}

const backendUrl =
  (globalThis as EnvironmentGlobals).process?.env?.['BackendURL'] ?? 'https://assetcheckoutapi.up.railway.app/api'

export const environment = {
  apiUrl: backendUrl,
}
