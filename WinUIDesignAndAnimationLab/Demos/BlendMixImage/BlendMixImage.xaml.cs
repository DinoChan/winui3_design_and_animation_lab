using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace WinUIDesignAndAnimationLab.Demos
{
    public sealed partial class BlendMixImage : UserControl
    {
        public BlendMixImage()
        {
            this.InitializeComponent();


            ElementCompositionPreview.SetElementChildVisual(BackgroundElement, CreateVisual("sea.jpg"));
            ElementCompositionPreview.SetElementChildVisual(BackgroundElement2, CreateVisual("sea2.jpg"));
        }

        private SpriteVisual CreateVisual(string imageName)
        {
            var compositor = MainWindow.CurrentWindow.Compositor;
            var (foreground, foregroundBrush) = CreateBrush(imageName, Colors.Cyan);
            var (background, backgroundBrush) = CreateBrush(imageName, Colors.Red);
            foregroundBrush.Offset = new Vector2(10, 0);

            var brush = CreateBrush(foreground, background, BlendEffectMode.Darken);

            var imageVisual = compositor.CreateSpriteVisual();
            imageVisual.Brush = brush;
            imageVisual.Size = new Vector2(800, 384);
            return imageVisual;

        }

        private (CompositionBrush compositionBrush, CompositionSurfaceBrush compositionSurfaceBrush) CreateBrush(string imageName, Color color)
        {
            var compositor = MainWindow.CurrentWindow.Compositor;
            var loadedSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/Images/" + imageName));
            var compositionSurfaceBrush = compositor.CreateSurfaceBrush();
            compositionSurfaceBrush.Surface = loadedSurface;
            var compositionBrush = CreateBrush(compositionSurfaceBrush, compositor.CreateColorBrush(color), BlendEffectMode.Lighten);
            return (compositionBrush, compositionSurfaceBrush);
        }

        private CompositionBrush CreateBrush(CompositionBrush foreground, CompositionBrush background, BlendEffectMode blendEffectMode)
        {
            var compositor = MainWindow.CurrentWindow.Compositor;
            var effect = new BlendEffect()
            {
                Mode = blendEffectMode,
                Foreground = new CompositionEffectSourceParameter("Main"),
                Background = new CompositionEffectSourceParameter("Tint"),
            };
            var effectFactory = compositor.CreateEffectFactory(effect);
            var compositionBrush = effectFactory.CreateBrush();
            compositionBrush.SetSourceParameter("Main", foreground);
            compositionBrush.SetSourceParameter("Tint", background);

            return compositionBrush;
        }
    }
}
