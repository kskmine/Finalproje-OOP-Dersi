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
    [Activity(Label = "AnaSayfaActivity")]
    public class AnaSayfaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //string adr = "";
            //string adresStr = Intent.GetStringExtra("adres");
            //adr= adresStr.ToString();

            SetContentView(Resource.Layout.anasayfa);

            Button pizza = FindViewById<Button>(Resource.Id.button1);
            pizza.Click += Pizza_Click;

            Button icecek = FindViewById<Button>(Resource.Id.button2);
            icecek.Click += İcecek_Click;
            // Create your application here
        }

        private void İcecek_Click(object sender, EventArgs e)
        {
            string adresStr = Intent.GetStringExtra("adres");
            string adr = adresStr.ToString();
            var icecekActivity = new Android.Content.Intent(this, typeof(SiparisIcecekActivity));
            icecekActivity.PutExtra("adres", adr.ToString());
            StartActivity(icecekActivity);
        }

        private void Pizza_Click(object sender, EventArgs e)
        {
            string adresStr = Intent.GetStringExtra("adres");
            string adr = adresStr.ToString();
            var pizzaActivity = new Android.Content.Intent(this, typeof(SiparisPizzaActivity));
            pizzaActivity.PutExtra("adres", adr.ToString());
            StartActivity(pizzaActivity);
        }
    }
}