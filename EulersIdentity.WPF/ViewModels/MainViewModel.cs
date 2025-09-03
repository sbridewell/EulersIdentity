// <copyright file="MainViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System;
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
        private string polynomialTermState = string.Empty;
        private string polynomialState = string.Empty;
        private string equationState = string.Empty;
        private double coefficient;
        private double exponent;
        private double xValue;
        private string debugMessages = string.Empty;
        private bool debugEnabled = true;

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
        /// Gets or sets the state of the PolynomialTerm control.
        /// </summary>
        public string PolynomialTermState
        {
            get => this.polynomialTermState;
            set
            {
                if (this.polynomialTermState != value)
                {
                    this.polynomialTermState = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of the Polynomial control.
        /// </summary>
        public string PolynomialState
        {
            get => this.polynomialState;
            set
            {
                if (this.polynomialState != value)
                {
                    this.polynomialState = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of the Equation control.
        /// </summary>
        public string EquationState
        {
            get => this.equationState;
            set
            {
                if (this.equationState != value)
                {
                    this.equationState = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the coefficient value.
        /// </summary>
        public double Coefficient
        {
            get => this.coefficient;
            set
            {
                if (Math.Abs(this.coefficient - value) > 0.0001)
                {
                    this.coefficient = value;
                    this.UpdatePolynomialTermState();
                    this.LogDebugMessage(nameof(this.Coefficient), value);
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the exponent value.
        /// </summary>
        public double Exponent
        {
            get => this.exponent;
            set
            {
                if (Math.Abs(this.exponent - value) > 0.0001)
                {
                    this.exponent = value;
                    this.UpdatePolynomialTermState();
                    this.LogDebugMessage(nameof(this.Exponent), value);
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the x-value.
        /// </summary>
        public double XValue
        {
            get => this.xValue;
            set
            {
                if (Math.Abs(this.xValue - value) > 0.0001)
                {
                    this.xValue = value;
                    this.UpdatePolynomialTermState();
                    this.LogDebugMessage(nameof(this.XValue), value);
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the debug messages.
        /// </summary>
        public string DebugMessages
        {
            get => this.debugMessages;
            set
            {
                if (this.debugMessages != value)
                {
                    this.debugMessages = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether debugging is enabled.
        /// </summary>
        public bool DebugEnabled
        {
            get => this.debugEnabled;
            set
            {
                if (this.debugEnabled != value)
                {
                    this.debugEnabled = value;
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

        private void UpdatePolynomialTermState()
        {
            // Update the polynomial term state based on the coefficient, exponent, and xValue.
            // This is a placeholder for the actual implementation.
            this.PolynomialTermState = $"When x is {this.XValue} then {this.Coefficient}x^{this.Exponent} = {this.Coefficient * Math.Pow(this.XValue, this.Exponent)}";
        }

        private void LogDebugMessage(string propertyName, object value)
        {
            if (this.DebugEnabled)
            {
                this.DebugMessages += $"{DateTime.Now}: {propertyName} set to {value}\n";
                this.OnPropertyChanged(nameof(this.DebugMessages));
            }
        }
    }
}