using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace WinUIDesignAndAnimationLab
{
    public partial class ProgressButton
    {


        /// <summary>
        /// 获取或设置Content的值
        /// </summary>
        public object Content
        {
            get => (object)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        /// 标识 Content 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(nameof(Content), typeof(object), typeof(ProgressButton), new PropertyMetadata(default(object)));

      

        /// <summary>
        /// 获取或设置State的值
        /// </summary>  
        public ProgressState State
        {
            get { return (ProgressState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        /// <summary>
        /// 标识 State 依赖属性。
        /// </summary>
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(ProgressState), typeof(ProgressButton), new PropertyMetadata(ProgressState.Idle, OnStateChanged));

        private static void OnStateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ProgressButton target = obj as ProgressButton;
            ProgressState oldValue = (ProgressState)args.OldValue;
            ProgressState newValue = (ProgressState)args.NewValue;
            if (oldValue != newValue)
                target.OnStateChanged(oldValue, newValue);
        }

        public bool IsPressed { get; private set; }

        public bool IsPointerOver { get; private set; }
    }
}
