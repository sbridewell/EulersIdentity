// <copyright file="MainWindowTest.Steps.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using System;
    using FlaUI.Core;
    using FlaUI.Core.AutomationElements;
    using FlaUI.UIA2;
    using FluentAssertions;
    using LightBDD.Framework;
    using LightBDD.XUnit2;

    /// <summary>
    /// Test steps for <see cref="MainWindowTest"/>.
    /// </summary>
    public partial class MainWindowTest : UITestBase
    {
        private string? mainWindowTitle;
        private string? selectedTabTitle;

        #region given steps

        private void TheApplicationIsStarted()
        {
            this.StartApplication();
        }

        #endregion

        #region when steps

        private void IGetTheTitleOfTheApplication()
        {
            this.mainWindowTitle = this.GetMainWindow().Title;
        }

        private void ISelectATabInTheMainWindow(int tabIndex)
        {
            var tabItem = this.SelectTab(tabIndex);
            this.selectedTabTitle = tabItem.Name;
        }

        #endregion

        #region then steps

        private void TheTitleOfTheMainWindowShouldBe(string expectedTitle)
        {
            this.mainWindowTitle.Should().Be(expectedTitle);
        }

        private void TheTitleOfTheSelectedTabShouldBe(string expectedTabTitle)
        {
            this.selectedTabTitle.Should().Be(expectedTabTitle);
        }

        #endregion
    }
}