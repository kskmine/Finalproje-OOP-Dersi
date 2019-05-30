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
    [Activity(Label = "SiparisIcecekActivity")]
    public class SiparisIcecekActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.siparis_icecekler);
            

            Button sepete_gec = FindViewById<Button>(Resource.Id.button4);
            sepete_gec.Click += Sepete_gec_Click;

            Button kutucola = FindViewById<Button>(Resource.Id.button1);
            kutucola.Click += Kutucola_Click;

            Button kutusprite = FindViewById<Button>(Resource.Id.button2);
            kutusprite.Click += Kutusprite_Click;

            Button cococola = FindViewById<Button>(Resource.Id.button3);
            cococola.Click += Cococola_Click;

            // Create your application here
        }

        private void Cococola_Click(object sender, EventArgs e)
        {
            Button cococola = FindViewById<Button>(Resource.Id.button3);
            fiyat = cococola.Text;
            TextView textbilgi = FindViewById<TextView>(Resource.Id.textView4);
            bilgi = textbilgi.Text;
        }

        private void Kutusprite_Click(object sender, EventArgs e)
        {
            Button kutusprite = FindViewById<Button>(Resource.Id.button2);
            fiyat = kutusprite.Text;
            TextView textbilgi = FindViewById<TextView>(Resource.Id.textView3);
            bilgi = textbilgi.Text;
        }

        

        private void Kutucola_Click(object sender, EventArgs e)
        {
            Button kutucola = FindViewById<Button>(Resource.Id.button1);
            fiyat = kutucola.Text;
            TextView textbilgi = FindViewById<TextView>(Resource.Id.textView2);
            bilgi = textbilgi.Text;

        }
        string fiyat;
        string bilgi;
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