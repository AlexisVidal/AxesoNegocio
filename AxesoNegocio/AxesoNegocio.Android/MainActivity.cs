using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;

namespace AxesoNegocio.Droid
{
    [Activity(Label = "AxesoNegocio", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize |
        ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjg4NzAwQDMxMzgyZTMyMmUzMEd1bnZ1dDBKcXJMUWJVdVdacm9mbmpLaHlCd3VzSzFROUVJKytQNVowbm89");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            LoadApplication(new App());
            if ((CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted))
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation }, 0);
            }
            if ((CheckSelfPermission(Manifest.Permission.AccessFineLocation) != (int)Permission.Granted))
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessFineLocation }, 0);
            }
            if ((CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted))
            {
                RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, 0);
            }
            if ((CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted))
            {
                RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage }, 0);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnStart()
        {
            base.OnStart();
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {
                // Do something if there are some pages in the `PopupStack`
            }
            else
            {
                // Do something if there are not any pages in the `PopupStack`
            }
        }
    }
}