// <copyright file="SomeClassTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    /// <summary>
    /// Unit tests for <see cref="SomeClass"/>.
    /// </summary>
    public class SomeClassTest
    {
        /// <summary>
        /// Tests that the DoSomething method sets the SomeProperty property as expected.
        /// </summary>
        [Fact]
        public void DoSomething_SetsSomeProperty()
        {
            // Arrange
            var someClass = new SomeClass();
            int expectedValue = 42;

            // Act
            someClass.DoSomething(expectedValue);

            // Assert
            Assert.Equal(expectedValue, someClass.SomeProperty);
        }
    }
}
