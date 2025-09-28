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

## Current state

<!--
After each step, update this section with
- What is working
- What is not working
-->

- **What is working:**
  - Server and client projects build and run independently.
  - Vite dev server starts and serves the client app on port 52943.
  - Server app starts and serves Swagger UI on port 5098.
  - Manual requests to both ports succeed.

- **What is not working:**
  - SpaProxy middleware fails to launch and detect readiness of the Vite dev server when started via `launch-dev.cmd`.
  - Integration between server and client via SpaProxy is not functioning as expected.

## Next steps / hypotheses

<!--
After each step, update this section with
- A list of possible next actions, with their rationale
- Open questions or uncertainties
-->

- Try starting the Vite dev server manually and use `spa.UseProxyToSpaDevelopmentServer("http://localhost:52943")` in `Program.cs` to proxy requests during development.
- Investigate if Vite can be configured to output a readiness string SpaProxy expects (e.g., "Compiled successfully").
- Review SpaProxy and Vite documentation for compatibility notes or recommended integration patterns.
- Consider using a different proxy approach if SpaProxy is not compatible with Vite out-of-the-box.

**Open questions:**
- Is there a way to configure SpaProxy to recognize Vite's output as a readiness signal?
- Are there community solutions or middleware for integrating ASP.NET Core with Vite?

## References

<!--
Update this section with
- Links to documentation, source code or related issues
- Any relevant files or code or configuration snippets
-->

- [SpaProxy source code](https://github.com/dotnet/aspnetcore/tree/main/src/Middleware/Spa/SpaProxy)
- [Vite documentation](https://vitejs.dev/guide/)
- [ASP.NET Core SPA documentation](https://learn.microsoft.com/en-us/aspnet/core/spa/?view=aspnetcore-8.0)
- `EulersIdentity.Web.Server.csproj`
- `launchSettings.json`
- `Program.cs`
- `launch-dev.cmd`
- `spa.proxy.json`
