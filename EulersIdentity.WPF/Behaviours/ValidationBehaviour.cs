// <copyright file="ValidationBehaviour.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Behaviours
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using Sde.EulersIdentity.WPF.ValidationRules;

    /// <summary>
    /// Provides an attached property to apply validation rules to a TextBox.
    /// </summary>
    public static class ValidationBehaviour
    {
        /// <summary>
        /// The attached property to enable floating-point validation.
        /// </summary>
        public static readonly DependencyProperty EnableFloatingPointValidationProperty =
            DependencyProperty.RegisterAttached(
                "EnableFloatingPointValidation",
                typeof(bool),
                typeof(ValidationBehaviour),
                new PropertyMetadata(false, OnEnableFloatingPointValidationChanged));

        /// <summary>
        /// Gets the value of the EnableFloatingPointValidation attached property.
        /// </summary>
        /// <param name="element">The element to get the property value from.</param>
        /// <returns>True if floating-point validation is enabled; otherwise, false.</returns>
        public static bool GetEnableFloatingPointValidation(DependencyObject element)
        {
            return (bool)element.GetValue(EnableFloatingPointValidationProperty);
        }

        /// <summary>
        /// Sets the value of the EnableFloatingPointValidation attached property.
        /// </summary>
        /// <param name="element">The element to set the property value on.</param>
        /// <param name="value">True to enable floating-point validation; otherwise, false.</param>
        public static void SetEnableFloatingPointValidation(DependencyObject element, bool value)
        {
            element.SetValue(EnableFloatingPointValidationProperty, value);
        }

        private static void OnEnableFloatingPointValidationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"EnableFloatingPointValidation changed: {e.OldValue} -> {e.NewValue}");
            if (d is TextBox textBox && e.NewValue is bool isEnabled && isEnabled)
            {
                // Retrieve the existing binding on the Text property
                var binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);
                if (binding != null)
                {
                    // Add the floating point validation rule to the binding
                    binding.ValidationRules.Add(new FloatingPointValidationRule());

                    // Re-apply the binding to ensure the validation rule is active
                    BindingOperations.SetBinding(textBox, TextBox.TextProperty, binding);
                }
            }
        }
    }
}