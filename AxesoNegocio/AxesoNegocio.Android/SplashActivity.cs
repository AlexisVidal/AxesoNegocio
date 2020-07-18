﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AxesoNegocio.Droid
{
    [Activity(Label = "Axeso Negocio",
        Icon = "@mipmap/icon",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/Theme.SplashE",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.StartActivity(typeof(MainActivity));
            Finish();
            OverridePendingTransition(0, 0);
        }
    }
}