using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using Microsoft.Maui;
using Android.Content;
using Microsoft.Maui.Essentials;

namespace FileDefender_MAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
    }

}