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

namespace App1.Model
{
    class Sepet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string kullaniciAdi { get; set; }
        public string siparisBilgi { get; set; }
        public string Tutar { get; set; }
        public string Adres { get; set; }

        public override string ToString()
        {
            return string.Format("Profile : Id = {0}, kullaniciAdi = {1}, siparisBilgi = {2}, Tutar = {3}, Adres = {4}", Id, kullaniciAdi, siparisBilgi, Tutar, Adres);
        }
    }
}