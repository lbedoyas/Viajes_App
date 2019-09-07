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
using ViajesApp.Modelos;

namespace ViajesApp.Clases
{
    public class DatabaseHelper
    {
        public static bool Insertar<T>(ref T item, string ruta_db)
        {
            using(SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(ruta_db))
            {
                conexion.CreateTable<T>();

                if (conexion.Insert(item)>0)
                {
                    return true;
                }
                return false;
            }
        }


        public static List<Viaje> LeerViajes(string ruta_db)
        {
            List<Viaje> viajes = new List<Viaje>();

            using (var conexion = new SQLite.SQLiteConnection(ruta_db))
            {
                viajes = conexion.Table<Viaje>().ToList();
            }

                return viajes;
        }


    }
}