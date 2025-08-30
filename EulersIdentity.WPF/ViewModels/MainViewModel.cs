// <copyright file="MainViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents the main ViewModel for the application.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private string selectedTab;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.Tabs = new ObservableCollection<string>
            {
                "PolynomialTerm",
                "Polynomial",
                "Equation",
            };
            this.selectedTab = this.Tabs[0];
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets the collection of tab names.
        /// </summary>
        public ObservableCollection<string> Tabs { get; }

        /// <summary>
        /// Gets or sets the selected tab.
        /// </summary>
        public string SelectedTab
        {
            get => this.selectedTab;
            set
            {
                if (this.selectedTab != value)
                {
                    this.selectedTab = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        [ExcludeFromCodeCoverage]
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}