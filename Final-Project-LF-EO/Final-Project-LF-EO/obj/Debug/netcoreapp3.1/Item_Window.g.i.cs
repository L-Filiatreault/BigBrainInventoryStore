﻿#pragma checksum "..\..\..\Item_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41D6F5697BF9B47A7064A730178B5B0A9BF0EF61"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Final_Project_LF_EO;
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


namespace Final_Project_LF_EO {
    
    
    /// <summary>
    /// Item_Window
    /// </summary>
    public partial class Item_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\Item_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItem;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Item_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCategories;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Item_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAvaQty;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Item_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMinQty;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Item_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAisle;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Item_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSupplier;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Final-Project-LF-EO;component/item_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Item_Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.cmbCategories = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\Item_Window.xaml"
            this.cmbCategories.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbCategories_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtAvaQty = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtMinQty = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtAisle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtSupplier = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 67 "..\..\..\Item_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\Item_Window.xaml"
            ((System.Windows.Controls.Button)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

