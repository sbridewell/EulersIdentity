// <copyright file="SomeClassTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test
{
    using FluentAssertions;

    /// <summary>
    /// Dummy unit test to check test project setup.
    /// </summary>
    public class SomeClassTest
    {
        private readonly SomeClass c = new();

        /// <summary>
        /// Dummy test method to check test project setup.
        /// </summary>
        [Fact]
        public void TestMethod()
        {
            this.c.SetProperty(2);
            this.c.SomeProperty.Should().Be(2);
        }
    }
}
