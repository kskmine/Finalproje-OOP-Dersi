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
    class SepetlistAdapter : BaseAdapter
    {
        private Activity context;
        private int[] id;
        private string[] kad;
        private string[] siparisBilgi;
        private string[] Tutar;
        private string[] Adres;

        public SepetlistAdapter(Activity context, List<Sepet> sepet)
        {
            this.context = context;
            this.id = sepet.Select(x => x.Id).ToArray();
            this.kad = sepet.Select(x => x.kullaniciAdi).ToArray();
            this.siparisBilgi = sepet.Select(x => x.siparisBilgi).ToArray();
            this.Tutar = sepet.Select(x => x.Tutar).ToArray();
            this.Adres = sepet.Select(x => x.Adres).ToArray();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //Profile bilgilerini göstereceğimiz layotu burada belirtiyoruz.
            var view = context.LayoutInflater.Inflate(Resource.Layout.sepetlist_layout, parent, false);

            // + Ekrandaki objeler çekilir, yani ProfileLayout.xaml dosyamızda ki objeler.
            TextView txtkad = (TextView)view.FindViewById(Resource.Id.txtkad);
            TextView txtsiparis = (TextView)view.FindViewById(Resource.Id.txtsiparis);
            TextView txttutar = (TextView)view.FindViewById(Resource.Id.txttutar);
            TextView txtadres = (TextView)view.FindViewById(Resource.Id.txtadres);
            // -

            // + Veriler atanır.
            txtkad.Text = this.kad[position];
            txtsiparis.Text = this.siparisBilgi[position];
            txttutar.Text = this.Tutar[position];
            txtadres.Text = this.Adres[position];
            // -

            return view;
        }

        public override int Count
        {
            get
            {
                return id.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return id[position];
        }
    }
}