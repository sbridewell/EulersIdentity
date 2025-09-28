# Troubleshooting the initial SPA

## Problem statement

I have created a single page application consisting of
- A server application using C# and ASP.net MVC Core - EulersIdentity.Web.Server in C:\Users\simon\source\repos\EulersIdentity\EulersIdentity.Web\EulersIdentity.Web.Server\ listening on port 5098
- A client application using React and Vite - eulersidentity.web.client in C:\Users\simon\source\repos\EulersIdentity\EulersIdentity.Web\eulersidentity.web.client\ listening on port 52943
- A C# class library containing business logic
- A C# class library containing unit tests for the business logic.

The class libraries containing the business logic and the unit tests are working fine, but I am having trouble getting the server and client applications to work together. I haven't yet modified the functionality of the client and server projects, so they still contain the default "weather forecast" application implemented in the default Visual Studio templates.

## Important standing instruction to Copilot

Please do not remove or modify any text inside HTML comments (<!-- ... -->) when updating this document.

## Investigation timeline

<!--
Add a subsection to this section for each step in the investigation. In each subsection, capture
- Date and time
- Action taken
- The reason for taking the action
- The outcome of the action and any observations
- What was learned as a result
-->

### 2025-09-28
- **Action taken:** Verified project structure, ports, and launch settings for both server and client.
- **Reason:** To ensure both applications are running and listening on the expected ports.
- **Outcome:** Server listens on port 5098, client (Vite) on port 52943. Both can be started independently.
- **Learned:** The basic setup and port configuration are correct.

### 2025-09-28
- **Action taken:** Set `<SpaRoot>` in the server `.csproj` to `..\..\eulersidentity.web.client` and verified the working directory.
- **Reason:** Previous errors indicated the working directory for the SPA proxy was incorrect.
- **Outcome:** The working directory now resolves to the correct client project folder.
- **Learned:** The SPA proxy uses the output directory as the base for resolving `<SpaRoot>`, so the relative path must account for this.

### 2025-09-28
- **Action taken:** Created and referenced `launch-dev.cmd` in `<SpaProxyLaunchCommand>`, ensured it is copied to the output directory.
- **Reason:** To avoid issues with quoting and path resolution in the SPA proxy launch command.
- **Outcome:** The script is present in the output directory and launches Vite successfully when run manually.
- **Learned:** The SPA proxy can execute a script, but may not correctly detect Vite's readiness.

### 2025-09-28
- **Action taken:** Observed runtime error from SpaProxy: `System.ArgumentOutOfRangeException: length ('-1') must be a non-negative value.`
- **Reason:** To diagnose why the SPA proxy fails to launch the client.
- **Outcome:** Error occurs because SpaProxy fails to parse the output from the Vite dev server.
- **Learned:** SpaProxy expects specific output from the client dev server (e.g., "Compiled successfully"), which Vite does not provide by default.

### 2025-09-28
- **Action taken:** Confirmed that Vite responds with HTTP 200 OK to GET requests and outputs "ready" and port info to the console.
- **Reason:** To check if SpaProxy's readiness check is based on HTTP response or console output.
- **Outcome:** Vite is running and accessible, but SpaProxy still fails.
- **Learned:** SpaProxy's readiness detection is not solely based on HTTP response; it also parses process output.

### 2025-09-28
- **Action taken:** Started the Vite client manually and the ASP.NET Core server. Browsed to `http://localhost:52943/`.
- **Reason:** To test proxying requests from the server to the client using `spa.UseProxyToSpaDevelopmentServer("http://localhost:52943")`.
- **Outcome:** The server output window displayed hundreds of `Request: GET /weatherforecast` messages, followed by repeated `Response500` errors. The error log shows `System.Net.Http.HttpRequestException: Failed to proxy the request to http://localhost:52943/weatherforecast, because the request to the proxy target failed. No connection could be made because the target machine actively refused it. (localhost:52943)`.
- **Learned:** The ASP.NET Core server is attempting to proxy API requests (e.g., `/weatherforecast`) to the Vite dev server, but the Vite dev server does not handle these API routes, resulting in connection failures and repeated 500 errors.

### 2025-09-28
- **Action taken:** Updated routing in `Program.cs` to map API controllers before SPA middleware, as suggested.
- **Reason:** To ensure only SPA routes are proxied to the Vite dev server, and API routes are handled by ASP.NET Core.
- **Outcome:** The server output window still displays hundreds of `Request: GET /weatherforecast` messages followed by hundreds of `Response: 500` messages. No error message is shown between them.
- **Learned:** Mapping controllers before SPA middleware does not resolve the issue. API requests to `/weatherforecast` are still not being handled correctly, possibly due to route configuration.

### 2025-09-28
- **Action taken:** Updated client code to request data from `/api/weatherforecast`. Observed network activity in the browser.
- **Reason:** To verify that API requests are routed correctly and handled by ASP.NET Core.
- **Outcome:** The browser console shows a GET request to `http://localhost:52943/api/weatherforecast` with a 200 OK response, but the response body is empty. This causes a deserialization error in the client.
- **Learned:** The API endpoint is being reached and responds successfully, but no data is returned in the response body.

### 2025-09-28
- **Action taken:** Added a minimal `TestController` with `[ApiController]` and `[Route("api/[controller]")]` to verify API routing. Browsed to `http://localhost:5098/api/test`.
- **Reason:** To rule out issues with the `WeatherForecastController` and confirm whether any API controller is reachable.
- **Outcome:** Browsing to both `http://localhost:5098/api/test` and `http://localhost:5098/api/weatherforecast` returns the SPA UI (HTML), not the expected API response. Similarly, browsing to `http://localhost:5098/swagger` also returns the SPA UI.
- **Learned:** API controllers are not being discovered or routed correctly. All requests, including those to API endpoints and Swagger, are being handled by the SPA fallback.

## Current state

<!--
After each step, update this section with
- What is working
- What is not working
-->

- **What is working:**
  - Server and client projects build and run independently.
  - Vite dev server starts and serves the client app on port 52943.

- **What is not working:**
  - All API endpoints (`/api/test`, `/api/weatherforecast`) and Swagger (`/swagger`) return the SPA UI instead of the expected API or documentation response.
  - API controllers are not being discovered or routed correctly.

## Next steps / hypotheses

<!--
After each step, update this section with
- A list of possible next actions, with their rationale
- Open questions or uncertainties
-->

- Investigate the implementation of the `WeatherForecastController` and the `WeatherForecast` model to ensure the API returns data as expected.
- Test the `/api/weatherforecast` endpoint directly (e.g., using a browser or Postman) to inspect the raw response.
- Check for issues with model binding, serialization, or controller logic that could result in an empty response.
- Review server logs for any warnings or errors during API request handling.
- Double-check the order of middleware in `Program.cs` to ensure `app.MapControllers()` is registered before `app.UseSpa()` and `app.MapFallbackToFile("/index.html")`.
- Confirm that the server project is being run (not the client) and is listening on port 5098.
- Temporarily comment out or remove the `app.UseSpa()` and `app.MapFallbackToFile("/index.html")` lines in `Program.cs` to see if API endpoints and Swagger become accessible.
- Check for any global route constraints, custom middleware, or configuration in `Program.cs` that could be affecting routing.
- Review the output of `dotnet build` for any warnings or errors related to controller discovery or routing.
- If the issue persists, create a minimal new ASP.NET Core Web API project and compare its `Program.cs` and configuration to identify any differences.

**Open questions:**
- Is there any custom middleware or configuration that could be intercepting all requests before they reach the controllers?
- Is the correct server project being run, and is it building and launching as expected?

## References

<!--
Update this section with
- Links to documentation, source code or related issues
- Any relevant files or code or configuration snippets
-->

- [SpaProxy source code](https://github.com/dotnet/aspnetcore/tree/main/src/Middleware/Spa/SpaProxy)
- [Vite documentation](https://vitejs.dev/guide/)
- [ASP.NET Core SPA documentation](https://learn.microsoft.com/en-us/aspnet/core/spa/?view=aspnetcore-8.0)
- [ASP.NET Core Routing](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-8.0)
- [ASP.NET Core Model Binding and Serialization](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0)
- `EulersIdentity.Web.Server.csproj`
- `launchSettings.json`
- `Program.cs`
- `WeatherForecastController.cs`
- `TestController.cs`
- `WeatherForecast.cs`
- `launch-dev.cmd`
- `spa.proxy.json`
