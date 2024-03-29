﻿using System;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Animation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace WinUIDesignAndAnimationLab.Demos;

public sealed partial class ThreeActionsWithOneClick
{
    private bool _isAnimateBegin;
    private readonly Storyboard _progressStoryboard;

    public ThreeActionsWithOneClick()
    {
        InitializeComponent();
        _progressStoryboard = CreateStoryboard();
    }

    private void OnLikeButtonTapped(object sender, TappedRoutedEventArgs e)
    {
        if (LikeButton.State != ProgressState.Completed)
            LikeButton.State = ProgressState.Completed;
        else
            LikeButton.State = ProgressState.Idle;
    }


    private void OnGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        var progressButton = sender as ProgressButton;
        if (progressButton.State == ProgressState.Idle)
            progressButton.State = ProgressState.Completed;
        else
            progressButton.State = ProgressState.Idle;
    }


    private void OnGestureRecognizerHolding(object sender, HoldingEventArgs e)
    {
        var progressButton = sender as ProgressButton;
        if (e.HoldingState == HoldingState.Started)
        {
            if (!_isAnimateBegin)
            {
                _isAnimateBegin = true;
                (_progressStoryboard.Children[0] as DoubleAnimation).From = progressButton.Minimum;
                (_progressStoryboard.Children[0] as DoubleAnimation).To = progressButton.Maximum;
                Storyboard.SetTarget(_progressStoryboard.Children[0] as DoubleAnimation, progressButton);
                _progressStoryboard.Begin();
            }
        }
        else
        {
            _isAnimateBegin = false;
            _progressStoryboard.Stop();
        }
    }


    private Storyboard CreateStoryboard()
    {
        var animation = new DoubleAnimation
        {
            EnableDependentAnimation = true,
            Duration = TimeSpan.FromSeconds(2)
        };

        Storyboard.SetTargetProperty(animation, nameof(ProgressButton.Value));
        var storyboard = new Storyboard();
        storyboard.Children.Add(animation);
        storyboard.Completed += OnProgressStoryboardCompleted;
        storyboard.FillBehavior = FillBehavior.Stop;
        return storyboard;
    }

    private void OnProgressStoryboardCompleted(object sender, object e)
    {
        LikeButton.State = ProgressState.Completed;
        CoinButton.State = ProgressState.Completed;
        FavoriteButton.State = ProgressState.Completed;
    }
}