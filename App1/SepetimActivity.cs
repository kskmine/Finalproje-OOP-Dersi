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
using App1.Model;

namespace App1
{
    [Activity(Label = "SepetimActivity")]
    public class SepetimActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            string adresStr = Intent.GetStringExtra("adres");
            string bilgiStr = Intent.GetStringExtra("bilgi");
            string fiyatStr = Intent.GetStringExtra("fiyat");
            SetContentView(Resource.Layout.sepetim);

            TextView textStr = FindViewById<TextView>(Resource.Id.adres);
            TextView blgStr = FindViewById<TextView>(Resource.Id.siparisd);
            TextView fytStr = FindViewById<TextView>(Resource.Id.fiyat);
            fytStr.Text = fiyatStr.ToString();
            blgStr.Text = bilgiStr.ToString();
            textStr.Text = adresStr.ToString();

            Button uyeol = FindViewById<Button>(Resource.Id.bt_nuye);
            uyeol.Click += Uyeol_Click;
            Button siparis = FindViewById<Button>(Resource.Id.btn_siparis);
            siparis.Click += Siparis_Click;

            // Create your application here
        }

        private void Siparis_Click(object sender, EventArgs e)
        {
          

         
            App1.SepetHelper.createDatabase();
            App1.ProfileHelper.createDatabase();

            Model.Sepet sepetRecord = new Model.Sepet();
            sepetRecord.kullaniciAdi = FindViewById<EditText>(Resource.Id.kullanici).Text;
            sepetRecord.siparisBilgi = FindViewById<TextView>(Resource.Id.siparisd).Text;
            sepetRecord.Tutar = FindViewById<TextView>(Resource.Id.fiyat).Text;
            sepetRecord.Adres = FindViewById<TextView>(Resource.Id.adres).Text;

            string sifre = FindViewById<EditText>(Resource.Id.sifreg).Text;

            Profile kullanici = App1.ProfileHelper.findUser(sepetRecord.kullaniciAdi);

            if(kullanici == null)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("UYARI");
                alert.SetMessage("Kullanıcı adı bulunamadı!");
                alert.SetPositiveButton("Delete", (senderAlert, args) => {
                    Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
                });
                alert.Show();
            }
            else if(kullanici.Surname != sifre)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("UYARI");
                alert.SetMessage("Şifre yanlış!");
                alert.SetPositiveButton("Delete", (senderAlert, args) => {
                    Toast.MakeText(this, "Deleted!", ToastLength.Short).Show();
                });
                alert.Show();
            }
            else
            {

                //Sqlite insert ediyoruz.
                App1.SepetHelper.insert(sepetRecord);

                //Profile tablosunda ki verileri çekiyoruz.
                List<Model.Sepet> listSepet = App1.SepetHelper.getSepetAll();

                //Adapteri kullanarak verilerimizi ProfileLayout.axml dosyasında ilgili yerlere yazıyoruz.
                SepetlistAdapter sepetAdapter = new SepetlistAdapter(this, listSepet);
                SetContentView(Resource.Layout.sepetlist);
                //Main.axml dosyamızda ki Listview objemizi çekiyoruz.
                ListView sepetListView = FindViewById<ListView>(Resource.Id.sepetListView);

                //ProfileLayout.axml dosyasında ki verileri main.axml dosyasında ki mainListview objesine atıyoruz.
                sepetListView.Adapter = sepetAdapter;
            }

        }

        private void Uyeol_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UyeOlActivity));
        }
    }
}