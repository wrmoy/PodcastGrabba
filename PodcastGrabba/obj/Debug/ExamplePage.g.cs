﻿

#pragma checksum "C:\Users\William\Documents\Visual Studio 2013\Projects\PodcastGrabba\PodcastGrabba\ExamplePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "98D61A44361AC9CD22F2CB8E521ED75B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PodcastGrabba
{
    partial class ExamplePage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\ExamplePage.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).NavigationCompleted += this.Browser_NavigationCompleted;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 22 "..\..\ExamplePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.ForwardAppBarButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 30 "..\..\ExamplePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.HomeAppBarButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


