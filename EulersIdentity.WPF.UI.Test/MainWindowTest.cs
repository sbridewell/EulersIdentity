// <copyright file="MainWindowTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using LightBDD.Framework;
    using LightBDD.Framework.Scenarios;
    using LightBDD.XUnit2;

    /// <summary>
    /// Scenarios for testing the main window.
    /// </summary>
    public partial class MainWindowTest
    {
        /// <summary>
        /// Tests that the main window has the correct title.
        /// </summary>
        [Scenario]
        public void MainWindow_HasCorrectTitle()
        {
            this.Runner.RunScenario(
                given => this.TheApplicationIsStarted(),
                when => this.IGetTheTitleOfTheApplication(),
                then => this.TheTitleOfTheMainWindowShouldBe("Euler's Identity"));
        }

        /// <summary>
        /// Tests that the main window contains a tab control with the correct tab titles.
        /// </summary>
        [Scenario]
        public void MainWindow_HasCorrectTabTitles()
        {
            this.Runner.RunScenario(
                given => this.TheApplicationIsStarted(),
                when => this.ISelectATabInTheMainWindow(0),
                then => this.TheTitleOfTheSelectedTabShouldBe("Polynomial Term"),
                when => this.ISelectATabInTheMainWindow(1),
                then => this.TheTitleOfTheSelectedTabShouldBe("Polynomial"));
        }
    }
}