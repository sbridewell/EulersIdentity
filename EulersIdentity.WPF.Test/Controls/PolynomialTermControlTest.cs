// <copyright file="PolynomialTermControlTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Controls
{
    using System.Windows.Controls;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Controls;

    /// <summary>
    /// Unit tests for <see cref="PolynomialTermControl"/>.
    /// </summary>
    public class PolynomialTermControlTest
    {
        /// <summary>
        /// Tests that the control initializes correctly.
        /// </summary>
        [Fact]
        public void Control_InitializesCorrectly()
        {
            // Arrange & Act
            Thread staThread = new Thread(() =>
            {
                var control = new PolynomialTermControl();

                // Assert
                control.Should().NotBeNull();
                control.Should().BeAssignableTo<UserControl>();
            });

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }
    }
}