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
    [Activity(Label = "SiparisPizzaActivity")]
    public class SiparisPizzaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.siparispizza);
           
            Button sepete_gec = FindViewById<Button>(Resource.Id.button4);
            sepete_gec.Click += Sepete_gec_Click;

            Button klasik = FindViewById<Button>(Resource.Id.button1);
            klasik.Click += Klasik_Click;

            Button sosyal = FindViewById<Button>(Resource.Id.button2);
            sosyal.Click += Sosyal_Click;

            Button konyalim = FindViewById<Button>(Resource.Id.button3);
            konyalim.Click += Konyalim_Click;

        }

        private void Konyalim_Click(object sender, EventArgs e)
        {
            Button konyalim = FindViewById<Button>(Resource.Id.button3);
            fiyat = konyalim.Text;
            TextView textbilgi = FindViewById<TextView>(Resource.Id.textView5);
            bilgi = textbilgi.Text;
        }

        private void Sosyal_Click(object sender, EventArgs e)
        {
            Button sosyal = FindViewById<Button>(Resource.Id.button2);
            fiyat = sosyal.Text;
            TextView textbilgi = FindViewById<TextView>(Resource.Id.textView4);
            bilgi = textbilgi.Text;
        }

        string fiyat;
        string bilgi;
        private void Klasik_Click(object sender, EventArgs e)
        {
            Button klasik = FindViewById<Button>(Resource.Id.button1);
            fiyat = klasik.Text;
            TextView textbilgi = FindViewById<TextView>(Resource.Id.textView3);
            bilgi = textbilgi.Text;

        }

        private void Sepete_gec_Click(object sender, EventArgs e)
        { 
            
            string adresStr = Intent.GetStringExtra("adres");
            string adr = adresStr.ToString();
            var sepetimActivity = new Android.Content.Intent(this, typeof(SepetimActivity));
            sepetimActivity.PutExtra("adres", adr.ToString());
            sepetimActivity.PutExtra("fiyat", fiyat.ToString());
            sepetimActivity.PutExtra("bilgi", bilgi.ToString());
            StartActivity(sepetimActivity);
        }
        
    }
}