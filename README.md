# Live at:
# https://assetcheckoutportal.vercel.app/
# https://assetcheckoutapi.up.railway.app/swagger

## Required ENV Variables
- **JwtKey** -> JWT Sigining Secret (e.g. SuperSecretDevelopmentKey1234567890)
- **FrontendURL** -> Used for CORS (e.g. https://localhost:4200)
- **BackendURL** -> Tells Client which server to use (e.g. https://localhost:7035/api)

## Optional ENV Variables
- **AccessTokenExpirationMinutes** -> How long access tokens are good for. Defaults to 15 minutes.
- **RefreshTokenExpirationDays** -> How long refresh tokens are good for. Defaults to 7 days.
