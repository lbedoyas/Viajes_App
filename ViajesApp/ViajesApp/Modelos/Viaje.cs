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

namespace ViajesApp.Modelos
{
    public class Viaje
    {
        [PrimaryKey, AutoIncrement]
        public int idViajes { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaRegreso { get; set; }

        public override string ToString()
        {
            //return string.Format("[Viaje: Id={0}, Nombre={1},FechaInicio={2}, FechaRegreso={3}]", idViajes,Nombre,FechaInicio,FechaRegreso);
            return $"{Nombre}({FechaInicio:d} - {FechaRegreso:d})";
        }

    }
}