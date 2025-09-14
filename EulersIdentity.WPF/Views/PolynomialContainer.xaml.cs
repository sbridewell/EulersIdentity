// <copyright file="PolynomialContainer.xaml.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Views
{
    using System.Windows.Controls;

    /// <summary>
    /// Represents a user control for managing and displaying polynomial-related data or functionality.
    /// </summary>
    /// <remarks>This class is a partial class that extends <see cref="UserControl"/> and is intended to be
    /// used as part of a graphical user interface. It provides the necessary initialization for its
    /// components.</remarks>
    public partial class PolynomialContainer : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialContainer"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the necessary components for the <see
        /// cref="PolynomialContainer"/> instance.</remarks>
        public PolynomialContainer()
        {
            this.InitializeComponent();
        }
    }
}