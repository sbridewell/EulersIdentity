# Single Page Application (SPA) Framework Options

This document outlines popular client-side frameworks for building SPAs, along with their pros and cons. These options are tailored to the requirement of integrating a Node.js-based client-side application with an ASP.NET Core MVC backend.

## 1. React
React is a JavaScript library for building user interfaces, maintained by Facebook.

### Pros:
- **Component-Based Architecture**: Encourages reusable and maintainable code.
- **Rich Ecosystem**: Extensive libraries and tools for state management (e.g., Redux, MobX).
- **Virtual DOM**: Improves performance by minimizing direct DOM manipulations.
- **Strong Community Support**: Large community and abundant resources.

### Cons:
- **Steep Learning Curve**: Requires understanding of JSX, state management, and other concepts.
- **Boilerplate Code**: Often requires additional setup for state management and routing.
- **Frequent Updates**: Can lead to compatibility issues with third-party libraries.

## 2. Angular
Angular is a full-fledged framework for building SPAs, maintained by Google.

### Pros:
- **Comprehensive Framework**: Includes built-in tools for routing, state management, and HTTP requests.
- **Two-Way Data Binding**: Simplifies synchronization between the model and the view.
- **TypeScript Support**: Encourages type safety and modern JavaScript features.
- **Enterprise-Ready**: Suitable for large-scale applications.

### Cons:
- **Complexity**: Steep learning curve due to its comprehensive nature.
- **Performance Overhead**: Can be slower for smaller applications.
- **Opinionated**: Limited flexibility in choosing tools and libraries.

## 3. Vue.js
Vue.js is a progressive JavaScript framework for building user interfaces.

### Pros:
- **Ease of Use**: Simple syntax and gentle learning curve.
- **Flexibility**: Can be used as a library or a full-fledged framework.
- **Reactive Data Binding**: Simplifies UI updates.
- **Lightweight**: Smaller bundle size compared to Angular.

### Cons:
- **Smaller Ecosystem**: Fewer third-party libraries compared to React and Angular.
- **Limited Enterprise Adoption**: Less common in large-scale enterprise applications.
- **Community Support**: Smaller community compared to React and Angular.

## 4. Svelte
Svelte is a modern framework that compiles components into highly efficient JavaScript at build time.

### Pros:
- **Performance**: No virtual DOM; compiles to optimized JavaScript.
- **Simplicity**: Minimal boilerplate and intuitive syntax.
- **Lightweight**: Smaller bundle sizes and faster load times.

### Cons:
- **Smaller Ecosystem**: Limited third-party libraries and tools.
- **Community Size**: Smaller community compared to React, Angular, and Vue.
- **Learning Curve**: Unique approach may require adjustment for developers familiar with other frameworks.

## 5. Blazor WebAssembly
Blazor is a Microsoft framework for building SPAs using C# and .NET.

### Pros:
- **C# Integration**: Allows sharing code between client and server.
- **Strong .NET Ecosystem**: Leverages existing .NET libraries and tools.
- **Tight Integration with ASP.NET Core**: Simplifies hosting and deployment.

### Cons:
- **Performance**: Larger initial download size due to WebAssembly.
- **Browser Compatibility**: Limited support in older browsers.
- **Smaller Community**: Less mature compared to JavaScript-based frameworks.

## Recommendation
The choice of framework depends on your specific requirements:
- **React**: Best for flexibility and a rich ecosystem.
- **Angular**: Ideal for enterprise-scale applications.
- **Vue.js**: Suitable for smaller projects or developers new to SPAs.
- **Svelte**: Great for performance-critical applications.
- **Blazor**: Perfect for leveraging existing .NET expertise.

Consider the trade-offs and select the framework that aligns with your project's goals.

# Preferred option - React

To integrate a React-based UI into your existing solution, follow these steps:

## 1. Create a New Project Using the "React and ASP.NET Core" Template
1. Open Visual Studio 2022 Community Edition.
2. Select **Create a new project** from the start window.
3. Search for **React and ASP.NET Core** in the project templates.
4. Choose the **React and ASP.NET Core (JavaScript)** option for a JavaScript-based React client.
5. Configure the project:
   - Enter a name for the project (e.g., `EulersIdentity.Web`).
   - Choose the location where the project will be created.
   - Ensure the project is added to the existing solution by selecting the appropriate checkbox.
6. Click **Create** to generate the project.

### Potential Issues:
- **Template Availability**: The "React and ASP.NET Core" template may not be installed by default in Visual Studio. You might need to install the required workloads (e.g., "ASP.NET and web development") or update Visual Studio.

### Recommendations:
- Ensure the required workloads are installed in Visual Studio.
- Verify that Node.js and npm are installed and up-to-date.

## 2. Project Structure and Configuration
1. The template will create a combined project containing:
   - An ASP.NET Core backend configured to serve the React client. This is in the `EulersIdentity.Web.Server` folder of the `EulersIdentity.Web` folder.
   - A `eulersidentity.web.client` folder containing the React application. This is a subfolder of the `EulersIdentity.Web` folder.
2. Add the package `Microsoft.AspNetCore.SpaServices.Extensions` to the ASP.NET Core project if it's not already included. If using .net 8 then use version 8.0.20 of this package.
3. Open the `Startup.cs` or `Program.cs` file to verify the SPA configuration. This call must be after `app.UseStaticFiles` but before `app.MapFallbackToFile`:
    ```csharp
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    ```
   ```csharp
   app.UseSpa(spa =>
   {
       spa.Options.SourcePath = "eulersidentity.web.client";

       if (env.IsDevelopment())
       {
           spa.UseReactDevelopmentServer(npmScript: "start");
       }
   });
   ```
4. Ensure the `eulersidentity.web.client` folder is included in the project and contains the React app files.
5. Navigate to the `eulersidentity.web.client` folder in the terminal and run:
   ```
   npm install
   ```
   This will install the required dependencies for the React application.
6. Add scripts to `package.json` for starting the development server and for building a production version of the client:
  ```json
  "build:prod": "npm run build",
  "start": "npm run dev"
  ```
7. If the EulersIdentity.Web.Server folder doesn't already contain a wwwroot folder, create it

### Potential Issues:
- **SPA Middleware Configuration**: The `UseSpa` middleware assumes the `eulersidentity.web.client` folder is correctly set up. If the folder is missing or misconfigured, the application won't serve the React app.
- **Production Build**: The instructions don't specify how to handle production builds of the React app. Without a proper build process, the app may not work as expected in production.

## 3. Start the Development Server
1. Navigate to the `eulersidentity.web.client` folder in the terminal.
2. Run the following command to start the React development server:
   ```
   npm start
   ```
3. Access the application at `https://localhost:<backend-port>`. This will result in a warning in the browser because the React development server uses a self-signed certificate. In this case it's safe to proceed.

### Potential Issues:
- **Development Server Proxy**: The `spa.UseReactDevelopmentServer(npmScript: "start")` command relies on the React development server. If Node.js or npm is not installed, or if there are issues with the `npm start` script, the development server won't run.

### Recommendations:
- Test the `npm start` script independently to ensure it works before integrating it with the ASP.NET Core backend.

## 4. Set Up Jest for Unit Testing
1. Navigate to the `eulersidentity.web.client` folder in the terminal.
2. Install Jest and related dependencies:
   ```
   npm install --save-dev jest @testing-library/react @testing-library/jest-dom jest-environment-jsdom identity-obj-proxy
   ```
3. Update the `scripts` section in `eulersidentity.web.client/package.json` to include:
   ```json
   "test": "jest"
   ```
4. Create a `jest.config.js` file in the `eulersidentity.web.client` directory. Note that `<rootDir>` is intended as a literal string, Jest will resolve this to the root directory of the React client:
   ```javascript
   module.exports = {
      testEnvironment: 'jsdom',
      setupFilesAfterEnv: ['<rootDir>/src/setupTests.js'],
      moduleNameMapper: {
        '\\.(css|scss)$': 'identity-obj-proxy',
      },
      transform: {
        '^.+\\.[jt]sx?$': 'babel-jest',
      },
   };
   collectCoverage: true,
   collectCoverageFrom: ["src/**/*.{js,jsx}"],
   ```
5. Add a `src/setupTests.js` file to configure Jest:
   ```javascript
   import '@testing-library/jest-dom';
   ```

### Potential Issues:
- **Jest Configuration**: Jest may require additional configuration for React projects.
- **Test Coverage**: If you don't configure Jest to include all files, some files may be excluded from test coverage reports.

## 5. Set Up ESLint for Code Quality
1. Navigate to the `eulersidentity.web.client` folder in the terminal.
2. Install ESLint and relevant plugins:
   ```
   npm install --save-dev eslint eslint-plugin-react eslint-plugin-react-hooks eslint-plugin-jsx-a11y eslint-plugin-import
   ```
3. Create an `.eslintrc.json` file in the `eulersidentity.web.client` directory:
   ```json
   {
     "env": {
       "browser": true,
       "es6": true
     },
     "extends": [
       "eslint:recommended",
       "plugin:react/recommended",
       "plugin:jsx-a11y/recommended",
       "plugin:import/errors",
       "plugin:import/warnings"
     ],
     "parserOptions": {
       "ecmaFeatures": {
         "jsx": true
       },
       "ecmaVersion": 6,
       "sourceType": "module"
     },
     "plugins": [
       "react",
       "jsx-a11y",
       "import"
     ],
     "rules": {
       "react/react-in-jsx-scope": "off",
       "import/order": ["error", { "alphabetize": { "order": "asc" } }]
     },
     "settings": {
       "react": {
         "version": "detect"
       }
     }
   }
   ```
4. Add a linting script to `eulersidentity.web.client/package.json`:
   ```json
   "lint": "eslint \"src/**/*.{js,jsx}\""
   ```

### Potential Issues:
- **Plugin Compatibility**: Some ESLint plugins may require additional configuration or dependencies.

### Recommendations:
- Test the ESLint configuration with a sample file to ensure it works as expected. A simple way to do this is to add a line to one of the .js files which declares an unused variable, e.g. `var foo = 'foo';` and then run `npm run lint` to see if it is reported.

## 6. Install and Configure Babel to Transpile to ES6
1. Navigate to the `eulersidentity.web.client` folder in the terminal.
2. Install Babel and the necessary presets:
   ```
   npm install --save-dev @babel/core @babel/cli @babel/preset-env @babel/preset-react babel-jest
   ```
3. Create a `.babelrc` file in the `eulersidentity.web.client` directory:
   ```json
   {
     "presets": [
       [
         "@babel/preset-env",
         {
           "targets": {
             "esmodules": true
           }
         }
       ]
       "@babel/preset-react"
     ]
   }
   ```
4. Update the `scripts` section in `eulersidentity.web.client/package.json` to include a build step:
   ```json
   "build:babel": "babel src --out-dir dist --copy-files --ignore node_modules,dist"
   ```
5. Run the Babel build process before deploying the application:
   ```
   npm run build:babel
   ```

### Potential Issues:
- **Babel Configuration**: Some features may require additional Babel plugins.

### Recommendations:
- Test the Babel build process to ensure all features are correctly transpiled.
- Test the Jest setup with a simple test case to ensure it works as expected.

## 7. Add references to React
Ensure React is imported into any .jsx files and unit test files that use React components:
```javascript
import React from 'react';
```

## 8. Build and Run the Solution
1. Start the ASP.NET Core backend:
   ```sh
   dotnet run
   ```
   This will start the backend server. Ensure it is running before proceeding to test the integration.
2. Start the React development server:
   ```
   npm start
   ```
3. Access the application at `https://localhost:<backend-port>`.

By following these steps, you will have a React-based UI integrated with your ASP.NET Core backend, configured to target ES6 and transpile newer features using Babel.

### Recommendations:
- Test the integration between the React app and ASP.NET Core backend in both development and production environments.
