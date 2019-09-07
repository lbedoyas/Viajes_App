using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ViajesApp.Clases;
using ViajesApp.Modelos;

namespace ViajesApp
{
    [Activity(Label = "ListaViajesActivity")]
    public class ListaViajesActivity : Activity
    {
        List<Viaje> Viajes;

        static string nombreArchivo = "Viajes_db.sqlite";
        static string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string ruta = Path.Combine(rutaCarpeta, nombreArchivo);

        Toolbar viajesToolbar;
        ListView viajesListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListaViajes);

            Viajes = new List<Viaje>();
            Viajes = DatabaseHelper.LeerViajes(ruta);

            viajesToolbar = FindViewById<Toolbar>(Resource.Id.viajesToolbar);
            viajesListView = FindViewById<ListView>(Resource.Id.viajesListView);


            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1,Viajes);
            //ListAdapter = arrayAdapter;

        }

        protected override void OnRestart()
        {
            base.OnRestart();

            Viajes = new List<Viaje>();
            Viajes = DatabaseHelper.LeerViajes(ruta);

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Viajes);
            //ListAdapter = arrayAdapter;
        }
    }
}