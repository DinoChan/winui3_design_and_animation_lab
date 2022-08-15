using WinUIDesignAndAnimationLab.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

using Windows.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Windows.UI;
using Microsoft.UI;

namespace WinUIDesignAndAnimationLab.Demos.BubbleButton
{
    public class SimpleShadowPanel : ContentControl
    {
        public SimpleShadowPanel()
        {
            this.DefaultStyleKey = typeof(SimpleShadowPanel);
            RegisterPropertyChangedCallback(ContentProperty, ContentPropertyChanged);
            RegisterPropertyChangedCallback(BackgroundProperty, BackgroundPropertyChanged);
            this.SizeChanged += SimpleShadowPanel_SizeChanged;
        }

        Rectangle ShadowHost;
        Visual HostVisual;
        Compositor _Compositor;
        SpriteVisual _ShadowVisual;
        DropShadow _Shadow;


        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ShadowHost = GetTemplateChild("ShadowHost") as Rectangle;

            SetupComposition();
            UpdateShadow();
        }

        private void SetupComposition()
        {
            if (DesignMode.DesignModeEnabled) return;
            HostVisual = ElementCompositionPreview.GetElementVisual(ShadowHost);
            _Compositor = HostVisual.Compositor;

            _ShadowVisual = _Compositor.CreateSpriteVisual();
            _ShadowVisual.BindSize(HostVisual);

            _Shadow = _Compositor.CreateDropShadow();
            _Shadow.Offset = Vector3.Zero;
            _Shadow.BlurRadius = 25f;

            _ShadowVisual.Shadow = _Shadow;

            ElementCompositionPreview.SetElementChildVisual(ShadowHost, _ShadowVisual);
        }

        private Color GetBackgroundColor()
        {
            if (Background is SolidColorBrush brush)
            {
                return brush.Color;
            }
            return Colors.Transparent;
        }

        private void UpdateShadow()
        {
            if (_Shadow != null)
            {
                _Shadow.Color = GetBackgroundColor();
                if (Content is Rectangle rect)
                {
                    _Shadow.Mask = rect.GetAlphaMask();
                }
            }
        }


        private void SimpleShadowPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateShadow();
        }

        private void BackgroundPropertyChanged(DependencyObject sender, DependencyProperty dp)
        {
            UpdateShadow();
        }

        private void ContentPropertyChanged(DependencyObject sender, DependencyProperty dp)
        {
            UpdateShadow();
        }

    }
}
