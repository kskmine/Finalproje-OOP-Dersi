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
    [Activity(Label = "SubeActivity")]
    public class SubeActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sube);
          
            
            Button ekle = FindViewById<Button>(Resource.Id.canımı_okudu);
            ekle.Click += Ekle_Click;
            // Create your application here
        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            EditText adres_bil = FindViewById<EditText>(Resource.Id.editText1);
            var anasayfaActivity = new Android.Content.Intent(this, typeof(AnaSayfaActivity));
            anasayfaActivity.PutExtra("adres", adres_bil.Text.ToString());

            StartActivity(anasayfaActivity);
        }
    }
}