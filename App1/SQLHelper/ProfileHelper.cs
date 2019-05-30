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
    class ProfileHelper
    {
        public static string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public static string path = System.IO.Path.Combine(folderPath, "Profile.db3");

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
                    connection.CreateTable<App1.Model.Profile>();

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
        /// <param name="profile"></param>
        /// <returns></returns>
        public static bool insert(App1.Model.Profile profile)
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    connection.Insert(profile);

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
        /// <param name="profile"></param>
        /// <returns></returns>
        public static bool deleteTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    connection.DeleteAll<Profile>();

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
                    connection.Delete<Profile>(id);

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
        public static Profile find(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    return connection.Find<Profile>(id);
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);

                return null;
            }
        }

        public static Profile findUser(string kad)
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    return connection.Query<Profile>("SELECT * FROM Profile WHERE Name = ?", kad).SingleOrDefault();
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
        public static List<Profile> getProfileAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(path))
                {
                    return connection.Table<Profile>().ToList();
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