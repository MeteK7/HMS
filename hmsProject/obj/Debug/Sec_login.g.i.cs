﻿#pragma checksum "..\..\Sec_login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D2A34EFD1F84246B9859C92EF8F662582B343CF"
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
using hmsProject;


namespace hmsProject {
    
    
    /// <summary>
    /// Sec_login
    /// </summary>
    public partial class Sec_login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid sec_login;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LB_Username;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lb_Pass;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Username;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_Password;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cb_clinic;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lb_Clinic;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Sec_login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Login;
        
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
            System.Uri resourceLocater = new System.Uri("/hmsProject;component/sec_login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Sec_login.xaml"
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
            this.sec_login = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.LB_Username = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Lb_Pass = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txt_Username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_Password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.Cb_clinic = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\Sec_login.xaml"
            this.Cb_clinic.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cb_clinic_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Lb_Clinic = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btn_Login = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Sec_login.xaml"
            this.btn_Login.Click += new System.Windows.RoutedEventHandler(this.btn_Login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

