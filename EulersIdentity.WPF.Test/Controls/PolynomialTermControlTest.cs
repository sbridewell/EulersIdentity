// <copyright file="PolynomialTermControlTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Views
{
    using System.Threading;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Views;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialTermControl"/> class.
    /// </summary>
    public class PolynomialTermControlTest
    {
        /// <summary>
        /// Tests that the control initializes correctly.
        /// </summary>
        [Fact]
        public void TestPolynomialTermControlInitialization()
        {
            // Arrange
            PolynomialTermControl control = null;

            var thread = new Thread(() =>
            {
                control = new PolynomialTermControl();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Act
            // No action needed for initialization test.

            // Assert
            control.Should().NotBeNull();
        }
    }
}