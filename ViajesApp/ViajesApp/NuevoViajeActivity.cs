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
    [Activity(Label = "NuevoViajeActivity")]
    public class NuevoViajeActivity : Activity
    {
        EditText lugarEditText;
        DatePicker idaDatePicker, regresoDatePicker;
        Button guardarButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NuevoViaje);

            lugarEditText = FindViewById<EditText>(Resource.Id.lugarEditText);
            idaDatePicker = FindViewById<DatePicker>(Resource.Id.idaDatePicker);
            regresoDatePicker = FindViewById<DatePicker>(Resource.Id.regresoDatePicker);
            guardarButton = FindViewById<Button>(Resource.Id.guardarButton);

            guardarButton.Click += GuardarButton_Click;

            // Create your application here
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            string nombreArchivo = "Viajes_db.sqlite";
            string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string ruta = Path.Combine(rutaCarpeta, nombreArchivo);

            var nuevoViaje = new Viaje()
            {
                Nombre = lugarEditText.Text,
                FechaInicio = idaDatePicker.DateTime,
                FechaRegreso = regresoDatePicker.DateTime
            };

            if (DatabaseHelper.Insertar(ref nuevoViaje, ruta))
            {
                Toast.MakeText(this, "Registro Ingresado Correctamente en la agenda", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Registro No Ingresado en la agenda", ToastLength.Short).Show();
            }
        }
    }
}