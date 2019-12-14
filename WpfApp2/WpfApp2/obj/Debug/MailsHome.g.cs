﻿#pragma checksum "..\..\MailsHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13592B7FE38A6035C52ECAE8FF512E4966EC3E71"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// MailsHome
    /// </summary>
    public partial class MailsHome : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image im;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock usernamewpf;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInbox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSent;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSpam;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDraft;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button contmsg;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\MailsHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock msgs;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/mailshome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MailsHome.xaml"
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
            this.im = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.usernamewpf = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            
            #line 31 "..\..\MailsHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_logOut);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 54 "..\..\MailsHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_info);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 55 "..\..\MailsHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_New);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnInbox = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\MailsHome.xaml"
            this.btnInbox.Click += new System.Windows.RoutedEventHandler(this.Button_inbox);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSent = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\MailsHome.xaml"
            this.btnSent.Click += new System.Windows.RoutedEventHandler(this.Button_Sent);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSpam = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\MailsHome.xaml"
            this.btnSpam.Click += new System.Windows.RoutedEventHandler(this.Button_spam);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDraft = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\MailsHome.xaml"
            this.btnDraft.Click += new System.Windows.RoutedEventHandler(this.Button_draft);
            
            #line default
            #line hidden
            return;
            case 10:
            this.contmsg = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\MailsHome.xaml"
            this.contmsg.Click += new System.Windows.RoutedEventHandler(this.Button_cont);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.msgs = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 12:
            
            #line 151 "..\..\MailsHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Delete);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 152 "..\..\MailsHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Reply);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

