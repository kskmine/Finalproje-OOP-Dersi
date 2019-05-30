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
using Android.Util;

namespace App1
{
    class SepetHelper
    {
        public static string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public static string path = System.IO.Path.Combine(folderPath, "Sepet.db3");

        /// <summary>
        /// Database oluşturur.
        /// </summary>
        /// <returns></returns>
        public static bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    connection.CreateTable<App1.Model.Sepet>();

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Profil tablosuna kayıt atar.
        /// </summary>
        /// <param name="sepet"></param>
        /// <returns></returns>
        public static bool insert(App1.Model.Sepet sepet)
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    connection.Insert(sepet);

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Profil tablosunu siler.
        /// </summary>
        /// <param name="sepet"></param>
        /// <returns></returns>
        public static bool deleteTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    connection.DeleteAll<Sepet>();

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return false;
            }
        }

        /// <summary>
        /// İlgili kayıdı siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool deleteRecord(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    connection.Delete<Sepet>(id);

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Aranılan kaydı bulur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Sepet find(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    return connection.Find<Sepet>(id);
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return null;
            }
        }

        

        /// <summary>
        /// Profile tablosunda ki verileri döner.
        /// </summary>
        /// <returns></returns>
        public static List<Sepet> getSepetAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    return connection.Table<Sepet>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return null;
            }
        }
    }
}