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
using SQLite;
using App1.Model;

namespace App1
{
    [Activity(Label = "UyeOlActivity")]
    public class UyeOlActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.uyeol);
            Button uyegecis = FindViewById<Button>(Resource.Id.button1);
            uyegecis.Click += Uyegecis_Click;
            // Create your application here
        }

        private void Uyegecis_Click(object sender, EventArgs e)
        {

            // Set our view from the "main" layout resource
           
            EditText kad = FindViewById<EditText>(Resource.Id.editText1);
            EditText sifre = FindViewById<EditText>(Resource.Id.editText2);
            EditText email = FindViewById<EditText>(Resource.Id.editText3);
            App1.ProfileHelper.createDatabase();

            Model.Profile profileRecord = new Model.Profile();
            profileRecord.Name = kad.Text;
            profileRecord.Surname = sifre.Text;
            profileRecord.Email = email.Text;

            //Sqlite insert ediyoruz.
            App1.ProfileHelper.insert(profileRecord);

            //Profile tablosunda ki verileri çekiyoruz.
            List<Model.Profile> listProfile = App1.ProfileHelper.getProfileAll();

            //Adapteri kullanarak verilerimizi ProfileLayout.axml dosyasında ilgili yerlere yazıyoruz.
            ProfileAdapter profileAdapter = new ProfileAdapter(this, listProfile);
            SetContentView(Resource.Layout.profilelist);
            //Main.axml dosyamızda ki Listview objemizi çekiyoruz.
            ListView mainListView = FindViewById<ListView>(Resource.Id.mainListView);

            //ProfileLayout.axml dosyasında ki verileri main.axml dosyasında ki mainListview objesine atıyoruz.
            mainListView.Adapter = profileAdapter;
           
        }
    }
}