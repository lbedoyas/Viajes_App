using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace ViajesApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText usuarioEditText, passwordEditText;
        Button inicioSessionButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            usuarioEditText = FindViewById<EditText>(Resource.Id.usuarioEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            inicioSessionButton = FindViewById<Button>(Resource.Id.inicioSessionButton);

            inicioSessionButton.Click += InicioSessionButton_Click;
        }

        private void InicioSessionButton_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(usuarioEditText.Text)|| string.IsNullOrEmpty(passwordEditText.Text) )
            {
                Intent intent = new Intent(this, typeof(ListaViajesActivity));
                StartActivity(intent);
            }else
            {
                Toast.MakeText(this, "Ocurrio un error", ToastLength.Short).Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}