﻿#pragma checksum "..\..\sendTo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "450DDF8F8A2B06B4476FC726C2CA8D8DBC076B72"
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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// sendTo
    /// </summary>
    public partial class sendTo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\sendTo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox towpf;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\sendTo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox subjectwpf;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\sendTo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descwpf;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\sendTo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button send;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\sendTo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button senddraft;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\sendTo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button draft;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/sendto.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\sendTo.xaml"
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
            this.towpf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.subjectwpf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.descwpf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.send = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\sendTo.xaml"
            this.send.Click += new System.Windows.RoutedEventHandler(this.Button_sendmsg);
            
            #line default
            #line hidden
            return;
            case 5:
            this.senddraft = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\sendTo.xaml"
            this.senddraft.Click += new System.Windows.RoutedEventHandler(this.Button_senddraft);
            
            #line default
            #line hidden
            return;
            case 6:
            this.draft = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\sendTo.xaml"
            this.draft.Click += new System.Windows.RoutedEventHandler(this.Button_discard);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

