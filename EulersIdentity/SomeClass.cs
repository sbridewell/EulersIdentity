// <copyright file="SomeClass.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// A dummy class so that we have something to test.
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// Gets a property.
        /// </summary>
        public int SomeProperty { get; private set; }

        /// <summary>
        /// A method which sets the property.
        /// </summary>
        /// <param name="someParameter">The parameter to set the property to.</param>
        public void DoSomething(int someParameter)
        {
            this.SomeProperty = someParameter;
        }
    }
}
