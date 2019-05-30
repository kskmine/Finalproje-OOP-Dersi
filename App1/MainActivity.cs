using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button adres_button = FindViewById<Button>(Resource.Id.adres_button1);
            adres_button.Click += Adres_button_Click;
            Button adres_button1 = FindViewById<Button>(Resource.Id.adres_button1);
            

            Button sube_button = FindViewById<Button>(Resource.Id.sube_button);
            sube_button.Click += Sube_button_Click;
        }

        private void Sube_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(SubeActivity));
        }
        private void Adres_button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(AdresActivity));
        }

    }
}