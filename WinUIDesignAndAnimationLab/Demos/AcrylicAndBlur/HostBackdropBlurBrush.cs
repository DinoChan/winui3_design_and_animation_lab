﻿using CommunityToolkit.WinUI.UI.Media;
using CommunityToolkit.WinUI.UI.Media.Pipelines;

using Microsoft.UI.Xaml;
using Microsoft.UI.Composition;
using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace WinUIDesignAndAnimationLab.Demos
{
    public class HostBackdropBlurBrush : XamlCompositionEffectBrushBase
    {
        /// <summary>
        /// The <see cref="EffectSetter{T}"/> instance currently in use
        /// </summary>
        private EffectSetter<float> amountSetter;

        /// <summary>
        /// Gets or sets the amount of gaussian blur to apply to the background.
        /// </summary>
        public double Amount
        {
            get => (double)GetValue(AmountProperty);
            set => SetValue(AmountProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Amount"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AmountProperty = DependencyProperty.Register(
            nameof(Amount),
            typeof(double),
            typeof(HostBackdropBlurBrush),
            new PropertyMetadata(0.0, new PropertyChangedCallback(OnAmountChanged)));

        /// <summary>
        /// Updates the UI when <see cref="Amount"/> changes
        /// </summary>
        /// <param name="d">The current <see cref="BackdropBlurBrush"/> instance</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance for <see cref="AmountProperty"/></param>
        private static void OnAmountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is HostBackdropBlurBrush brush &&
                brush.CompositionBrush is CompositionBrush target)
            {
                brush.amountSetter?.Invoke(target, (float)brush.Amount);
            }
        }

        /// <inheritdoc/>
        protected override PipelineBuilder OnPipelineRequested()
        {
            return PipelineBuilder.FromHostBackdrop().Blur((float)Amount, out this.amountSetter);
        }
    }
}