﻿#pragma checksum "..\..\..\ReportIssuesForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E654CF892D9D3D6CBBEBEE95107137E414FA43BF"
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
using System.Windows.Controls.Ribbon;
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


namespace Programming_3B_Part_1 {
    
    
    /// <summary>
    /// ReportIssuesForm
    /// </summary>
    public partial class ReportIssuesForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAttachFile;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBackToMenu;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLocation;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbDescription;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFeedback;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBarFormFilling;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel OverlayStack;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\ReportIssuesForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBarOverlay;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Programming 3B Part 1;component/reportissuesform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReportIssuesForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnAttachFile = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\ReportIssuesForm.xaml"
            this.btnAttachFile.Click += new System.Windows.RoutedEventHandler(this.btnAttachFile_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\ReportIssuesForm.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnBackToMenu = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\ReportIssuesForm.xaml"
            this.btnBackToMenu.Click += new System.Windows.RoutedEventHandler(this.btnBackToMenu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtLocation = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\ReportIssuesForm.xaml"
            this.txtLocation.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtLocation_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.categoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\ReportIssuesForm.xaml"
            this.categoryComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rtbDescription = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 45 "..\..\..\ReportIssuesForm.xaml"
            this.rtbDescription.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rtbDescription_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblFeedback = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.progressBarFormFilling = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 9:
            this.OverlayStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.progressBarOverlay = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
