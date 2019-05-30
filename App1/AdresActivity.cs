using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "AdresActivity")]
    public class AdresActivity : Activity
    {
        //EditText adres_bil = FindViewById<EditText>(Resource.Id.editText3);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adres);
            
            Button adres_button = FindViewById<Button>(Resource.Id.button1);
            adres_button.Click += Adres_button_Click;

            //EditText adres_bil = FindViewById<EditText>(Resource.Id.editText3);
            
            // Create your application here
        }

        private void Adres_button_Click(object sender, EventArgs e)
        {
            EditText adres_bil = FindViewById<EditText>(Resource.Id.editText3);
            var anasayfaActivity = new Android.Content.Intent(this, typeof(AnaSayfaActivity));
            anasayfaActivity.PutExtra("adres", adres_bil.Text.ToString());

            StartActivity(anasayfaActivity);
        }
    }
}