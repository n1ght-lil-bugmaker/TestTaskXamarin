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

namespace TestTask
{
    [Activity(Label ="Full Info")]
    public class FullInfoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.fullinfo);

            var textView = FindViewById<TextView>(Resource.Id.textView1);

            textView.Text = Intent.GetStringExtra("offer");
        }
    }
}