using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System.Linq;
using TestTask.Model;

namespace TestTask
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var listView = FindViewById<ListView>(Resource.Id.listView1);    
            var offers = Services.GetOffers().ToList();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, offers.Select(x => x.Id.ToString()).ToList());

            listView.Adapter = adapter;

            listView.ItemClick += (sender, args) =>
            {
                var intent = new Intent(this, typeof(FullInfoActivity));

                var offer = offers[args.Position];
                intent.PutExtra("offer", offer.SereilizeToJson());
                StartActivity(intent);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}