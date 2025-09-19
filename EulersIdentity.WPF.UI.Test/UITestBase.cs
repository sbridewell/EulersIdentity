// <copyright file="UITestBase.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using FlaUI.Core;
    using FlaUI.Core.AutomationElements;
    using FlaUI.Core.Tools;
    using FlaUI.UIA2;
    using LightBDD.XUnit2;

    /// <summary>
    /// Base class for UI test classes, providing common functionality for interacting with the application.
    /// </summary>
    public abstract class UITestBase : FeatureFixture, IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// Gets the application instance.
        /// </summary>
        protected Application? Application { get; private set; }

        /// <summary>
        /// Gets the automation framework instance.
        /// </summary>
        protected AutomationBase? Automation { get; private set; }

        /// <inheritdoc cref="IDisposable" />
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Starts the application and initializes the automation framework.
        /// </summary>
        protected void StartApplication()
        {
            // Path to the WPF application executable
            var appPath = @"..\..\..\..\EulersIdentity.WPF\bin\Debug\net8.0-windows7.0\Sde.EulersIdentity.WPF.exe";

            // Verify the file exists
            if (!File.Exists(appPath))
            {
                throw new InvalidOperationException($"The application executable was not found at: {appPath}");
            }

            // Launch the application
            this.Application = Application.Launch(appPath);

            // Initialize the UI Automation framework
            this.Automation = new UIA2Automation();
        }

        /// <summary>
        /// Retrieves the main window of the application.
        /// </summary>
        /// <returns>The main window of the application.</returns>
        protected Window GetMainWindow()
        {
            if (this.Application == null || this.Automation == null)
            {
                throw new InvalidOperationException("The application is not started or the automation framework is not initialized.");
            }

            var mainWindow = this.Application.GetMainWindow(this.Automation);

            if (mainWindow == null)
            {
                throw new InvalidOperationException("Failed to retrieve the main window of the application.");
            }

            return mainWindow;
        }

        /// <summary>
        /// Finds the TabControl in the main window.
        /// </summary>
        /// <returns>The TabControl element.</returns>
        protected Tab FindTabControl()
        {
            var mainWindow = this.GetMainWindow();
            var tabControl = mainWindow.FindFirstDescendant(
                cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Tab))?.AsTab();

            if (tabControl == null)
            {
                throw new InvalidOperationException("Failed to find the Tab control in the main window.");
            }

            return tabControl;
        }

        /// <summary>
        /// Selects a tab in the TabControl by index.
        /// </summary>
        /// <param name="tabIndex">The index of the tab to select.</param>
        /// <returns>The selected TabItem.</returns>
        protected TabItem SelectTab(int tabIndex)
        {
            var tabControl = this.FindTabControl();
            var tabItem = tabControl.TabItems?.ElementAtOrDefault(tabIndex);

            if (tabItem == null)
            {
                throw new InvalidOperationException($"No tab item found at index {tabIndex} in the Tab control.");
            }

            tabItem.Select();
            return tabItem;
        }

        /// <summary>
        /// Finds a control of the specified type within a specific tab.
        /// </summary>
        /// <typeparam name="T">The type of the control to find.</typeparam>
        /// <param name="tabIndex">The index of the tab to search in.</param>
        /// <param name="automationId">The automation ID of the control.</param>
        /// <returns>The control element.</returns>
        protected T FindControlInTab<T>(int tabIndex, string automationId)
            where T : AutomationElement
        {
            this.SelectTab(tabIndex);
            var mainWindow = this.GetMainWindow();
            var control = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(automationId))?.As<T>();

            if (control == null)
            {
                throw new InvalidOperationException($"Failed to find the control with AutomationId '{automationId}' in tab at index {tabIndex}.");
            }

            return control;
        }

        /// <summary>
        /// Finds a control in the main window by its AutomationId with retry logic.
        /// </summary>
        /// <typeparam name="T">The type of the control to find.</typeparam>
        /// <param name="automationId">The AutomationId of the control.</param>
        /// <returns>The control element.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the control is not found.</exception>
        protected T FindControlByAutomationId<T>(string automationId)
            where T : AutomationElement
        {
            var mainWindow = this.GetMainWindow();
            mainWindow.Focus();
            var retryResult = Retry.WhileNull(
                () => mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(automationId))?.As<T>(),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromMilliseconds(100));

            if (retryResult == null)
            {
                throw new InvalidOperationException($"RetryResult for AutomationId '{automationId}' is null.");
            }

            var automationElement = retryResult.Result;
            if (automationElement == null)
            {
                throw new InvalidOperationException($"AutomationElement for AutomationId '{automationId}' is null.");
            }

            return automationElement;
        }

        /// <summary>
        /// Retrieves the text value of a TextBlock control by its automation ID.
        /// </summary>
        /// <param name="automationId">The automation ID of the TextBlock.</param>
        /// <returns>The text value of the TextBlock.</returns>
        protected string GetTextBlockValue(string automationId)
        {
            var textBlock = this.FindControlByAutomationId<Label>(automationId);
            return textBlock.Text;
        }

        /// <summary>
        /// Disposes of resources used by the test class.
        /// </summary>
        /// <param name="disposing">A value indicating whether the method is called from Dispose.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Close the application window if it is still open
                    if (this.Application != null && !this.Application.HasExited)
                    {
                        this.Application.Close();
                    }

                    // Dispose managed state (managed objects)
                    this.Application?.Dispose();
                    this.Automation?.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}