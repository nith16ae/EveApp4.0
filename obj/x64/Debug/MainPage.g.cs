﻿#pragma checksum "E:\Libraries\Documents\College\Classes\COMPE361\EveApp4.0\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "96CB4F6DE379B43C8ECB8EFA0273218E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EveOnlineApp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 18
                {
                    this.ProgressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 3: // MainPage.xaml line 21
                {
                    this.GridViewSell = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 4: // MainPage.xaml line 48
                {
                    this.GridViewBuy = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 5: // MainPage.xaml line 75
                {
                    this.btn_start = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_start).Click += this.Btn_start_Click;
                }
                break;
            case 6: // MainPage.xaml line 76
                {
                    this.regionBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // MainPage.xaml line 77
                {
                    this.dropdown_regions_box = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.dropdown_regions_box).SelectionChanged += this.dropdown_regions_box_SelectionChanged;
                }
                break;
            case 8: // MainPage.xaml line 290
                {
                    this.searchBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // MainPage.xaml line 291
                {
                    this.searchButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.searchButton).Click += this.searchButton_Click;
                }
                break;
            case 10: // MainPage.xaml line 292
                {
                    this.restoreButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.restoreButton).Click += this.restoreButton_Click;
                }
                break;
            case 11: // MainPage.xaml line 294
                {
                    this.Sell_border = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 12: // MainPage.xaml line 295
                {
                    this.Buy_border = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 13: // MainPage.xaml line 297
                {
                    this.Sell_label = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // MainPage.xaml line 298
                {
                    this.Buy_label = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // MainPage.xaml line 299
                {
                    this.Sell_item_name = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // MainPage.xaml line 300
                {
                    this.Sell_item_id = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // MainPage.xaml line 301
                {
                    this.Sell_price = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // MainPage.xaml line 302
                {
                    this.Buy_item_name = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // MainPage.xaml line 303
                {
                    this.Buy_item_id = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // MainPage.xaml line 304
                {
                    this.Buy_price = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

