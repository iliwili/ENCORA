﻿#pragma checksum "..\..\CircleGame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F29AD426E665577E4D8E12504BFAB3DE0E3E0FF1F2357AD4F4745625DC28DE0E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using les8;


namespace les8 {
    
    
    /// <summary>
    /// CircleGame
    /// </summary>
    public partial class CircleGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cnvs;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblScore;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTimer;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAccuracy;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bStartGame;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bGoBack;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEndGame;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CircleGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEndScore;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/les8;component/circlegame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CircleGame.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cnvs = ((System.Windows.Controls.Canvas)(target));
            
            #line 9 "..\..\CircleGame.xaml"
            this.cnvs.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickEvent);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblScore = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblTimer = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblAccuracy = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.bStartGame = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\CircleGame.xaml"
            this.bStartGame.Click += new System.Windows.RoutedEventHandler(this.ClickEvent_StartGame);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\CircleGame.xaml"
            this.bGoBack.Click += new System.Windows.RoutedEventHandler(this.ClickEvent_StartGame);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblEndGame = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblEndScore = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
