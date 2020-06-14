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

namespace KochBuch
{
    [Activity(Label = "Portugiesische Küsche")]
    public class Portugal : Activity
    {
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Spanien);
            // Create your application here
            ListView List1 = FindViewById<ListView>(Resource.Id.List1);
            // List View
            tableItems.Add(new TableItem("Tajin", "3 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "3 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "3 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "3 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "2 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "2 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "2 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "2 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "2 Hour", Resource.Drawable.Tajin));
            tableItems.Add(new TableItem("Tajin", "2 Hour", Resource.Drawable.Tajin));
            List1.Adapter = new HomeScreenAdapter2(this, tableItems);
        }
    }
}