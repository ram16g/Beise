﻿using Beise.ViewModels;
using Beise.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Beise
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ArticlePage), typeof(ArticlePage));
        }

    }
}
