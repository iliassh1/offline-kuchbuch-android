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
    [Activity(Label = "Französische Küsche")]
    public class Frankreich : Activity
    {
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Frankreich);

            // Create your application here

            ListView List1 = FindViewById<ListView>(Resource.Id.List1);

            // DB Objekt
            DbRezept Db = new DbRezept();




            int i = 0;
            int resourceId = 0;

            for (i = 19; i <= 24; i++)
            {
                resourceId = (int)typeof(Resource.Drawable).GetField(Db.selectImageNachID(i)).GetValue(null);
                tableItems.Add(new TableItem(Db.selectNameNachID(i), " " + Db.selectDauerNachID(i) + " Min", resourceId));


            }



            List1.Adapter = new HomeScreenAdapter2(this, tableItems);
            List1.ItemClick += OnListItemClick;

        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];



            // Intent DeIntent = new Intent(this, typeof(Board));

            Intent myIntent = new Intent(this, typeof(Board));
            myIntent.PutExtra("Data", t.Heading);
            StartActivity(myIntent);


        }


    }




}