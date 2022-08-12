﻿using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIDesignAndAnimationLab.AnimationTimelines;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDesignAndAnimationLab.Demos.Gooey
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GooeyEllipseDemo2Page : Page
    {
        private GaussianBlurEffect _blurEffect;
        private Vector2 _centerPoint;
        private ICanvasImage _image;
        private ICanvasBrush _leftBrush;
        private Vector2Timeline _leftTimeline;
        private ICanvasBrush _rightBrush;
        private Vector2Timeline _rightTimeline;
        private DateTime _startTime;

        public GooeyEllipseDemo2Page()
        {
            InitializeComponent();
            var easingFunction = new ExponentialEase { EasingMode = EasingMode.EaseInOut };
            _leftTimeline = new Vector2Timeline(new Vector2(-100, 0), new Vector2(100, 0), 2, null, true, true, easingFunction);
            _rightTimeline = new Vector2Timeline(new Vector2(100, 0), new Vector2(-100, 0), 2, null, true, true, easingFunction);
        }

        private void OnCanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _centerPoint = Canvas.ActualSize / 2;
        }

        private void OnCreateResource(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            _startTime = DateTime.Now;
            _leftBrush = new CanvasSolidColorBrush(sender, Colors.IndianRed);
            _rightBrush = new CanvasSolidColorBrush(sender, Colors.PaleVioletRed);
            _blurEffect = new GaussianBlurEffect()
            {
                BlurAmount = 20f,
            };

            _image = new ColorMatrixEffect()
            {
                ColorMatrix = new Matrix5x4()
                {
                    M11 = 1,
                    M12 = 0,
                    M13 = 0,
                    M14 = 0,
                    M21 = 0,
                    M22 = 1,
                    M23 = 0,
                    M24 = 0,
                    M31 = 0,
                    M32 = 0,
                    M33 = 1,
                    M34 = 0,
                    M41 = 0,
                    M42 = 0,
                    M43 = 0,
                    M44 = 18,
                    M51 = 0,
                    M52 = 0,
                    M53 = 0,
                    M54 = -7,
                },
                Source = _blurEffect
            };
        }

        private void OnDraw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var source = new CanvasCommandList(sender);
            var totalTime = DateTime.Now - _startTime;
            using (var drawingSession = source.CreateDrawingSession())
            {
                drawingSession.FillCircle(_centerPoint + _leftTimeline.GetCurrentValue(totalTime), 100, _leftBrush);
                drawingSession.FillCircle(_centerPoint + _rightTimeline.GetCurrentValue(totalTime), 60, _rightBrush);
            }

            _blurEffect.Source = source;
            args.DrawingSession.DrawImage(_image);
            Canvas.Invalidate();
        }
    }
}