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

### 2025-10-05
- **Action taken:** Commented out the calls to `app.UseSpa` and `app.MapFallbackToFile` in `Program.cs`.
- **Reason:** To determine if SPA middleware or fallback routing was intercepting API and Swagger requests.
- **Outcome:** With these lines commented out, `http://localhost:5098/swagger/index.html` correctly displays the Swagger UI, and `http://localhost:5098/api/test` returns "Hello from API" as expected.
- **Learned:** The SPA middleware and fallback routing were intercepting all requests, including those intended for API controllers and Swagger, causing them to return the SPA UI instead of the expected API responses.

### 2025-10-05
- **Action taken:** Updated fallback routing to exclude `/api` and `/swagger` paths from SPA proxying, as suggested.
- **Reason:** To ensure only true SPA routes are proxied to the Vite dev server, while API and Swagger routes are handled by ASP.NET Core.
- **Outcome:** Browsing to `http://localhost:5098/swagger` now displays a runtime error:  
  `SocketException: No connection could be made because the target machine actively refused it.`  
  `HttpRequestException: Failed to proxy the request to http://localhost:52943/swagger, because the request to the proxy target failed.`
- **Learned:** The fallback routing is still proxying `/swagger` requests to the Vite dev server, which does not serve Swagger, resulting in a connection error.

### 2025-10-05
- **Action taken:** Updated the fallback routing in `Program.cs` to further exclude `/api`, `/swagger`, `/swagger-ui`, `/v3`, and `/favicon.ico` from SPA proxying.
- **Reason:** To prevent SPA middleware from intercepting requests to API and Swagger endpoints.
- **Outcome:** Despite these changes, browsing to `http://localhost:5098/swagger` still results in a runtime error:  
  `SocketException: No connection could be made because the target machine actively refused it.`  
  `HttpRequestException: Failed to proxy the request to http://localhost:52943/swagger, because the request to the proxy target failed.`
- **Learned:** The fallback routing is still incorrectly proxying `/swagger` requests to the Vite dev server, which does not serve Swagger, resulting in a connection error. The exclusion logic in the predicate may not be functioning as intended.

### 2025-10-05
- **Action taken:** Browsed to `http://localhost:5098/` and observed the message: "Launching the SPA proxy... This page will automatically redirect to http://localhost:52943 when the SPA proxy is ready." Waited, but the page never redirected.
- **Reason:** To verify that the SPA proxy and Vite dev server integration is working as expected.
- **Outcome:** Browsing to `http://localhost:52943/` in Firefox displays the error: "Firefox can’t establish a connection to the server at localhost:52943." This suggests that the Vite dev server is not running or not accessible.
- **Learned:** The SPA proxy is waiting for the Vite dev server to become available, but since the Vite server is not running, it cannot redirect or serve the SPA. The client-side application is unavailable.

### 2025-10-05
- **Action taken:** Ran `npm run dev` in the `eulersidentity.web.client` directory. The client application started successfully. Debugged the `EulersIdentity.Web.Server.csproj` project in Visual Studio and browsed to `http://localhost:52943/`.
- **Reason:** To verify that the Vite dev server and React client are running and accessible.
- **Outcome:** The browser displays the default weather forecast UI with the message:  
  "Loading... Please refresh once the ASP.NET backend has started. See https://aka.ms/jspsintegrationreact for more details."  
  Refreshing the page does not change its content.
- **Learned:** The React client is running, but it cannot fetch data from the ASP.NET backend. The loading message persists, indicating that the API call to `/api/weatherforecast` is not succeeding.

### 2025-10-05
- **Action taken:** Inspected the browser's developer tools while running the Vite dev server and browsing to `http://localhost:52943/`. Observed network requests to `http://localhost:52943/api/weatherforecast`.
- **Reason:** To verify whether the React client is able to fetch data from the ASP.NET backend API.
- **Outcome:** The request to `/api/weatherforecast` returns a `200 OK` status, but the response body is an HTML page (the Vite index.html), not the expected JSON data. The `Content-Type` is `text/html` instead of `application/json`.
- **Learned:** The Vite dev server is handling `/api/weatherforecast` requests itself and serving the SPA HTML, rather than proxying them to the ASP.NET backend. This means the client cannot access backend API data when running on port 52943.

### 2025-10-05
- **Action taken:** Updated `vite.config.js` to proxy all `/api` requests to the ASP.NET Core backend at `http://localhost:5098`.
- **Reason:** The React client was unable to fetch data from the backend API because the Vite dev server was serving HTML for `/api/weatherforecast` instead of proxying the request.
- **Outcome:** After updating the proxy configuration and restarting the Vite dev server, the React client successfully fetched data from the backend API. The weather forecast table populated as expected, and both the client and server applications now work as intended.
- **Learned:** Correct proxy configuration in `vite.config.js` is essential for development scenarios where the client and server run on different ports. This enables seamless API communication and resolves issues where the client receives HTML instead of JSON.

- Restarted the Vite dev server to apply the new proxy settings.
- Confirmed that the React client could successfully fetch data from the backend API and display it in the UI.

**Open questions:**  
- None; the integration is now working as expected.

## References

<!--
Update this section with
- Links to documentation, source code or related issues
- Any relevant files or code or configuration snippets
-->

- [Vite Proxy Configuration](https://vitejs.dev/config/server-options.html#server-proxy)
- [ASP.NET Core SPA documentation](https://learn.microsoft.com/en-us/aspnet/core/spa/?view=aspnetcore-8.0)
- `vite.config.js`
- `EulersIdentity.Web.Server.csproj`
- `Program.cs`
- `WeatherForecastController.cs`
