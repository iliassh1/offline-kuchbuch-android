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
    [Activity(Label = "Deutsche Küsche")]
    public class List : Activity
    {
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Deutschland);
            // Create your application here
            ListView List1 = FindViewById<ListView>(Resource.Id.List1);
            // DB Objekt
            DbRezept Db = new DbRezept();
            int i = 0;
            int resourceId = 0;
            for (i = 13; i <= 18; i++)
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
    // Adapter für die Listview Listview
    public class HomeScreenAdapter2 : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public HomeScreenAdapter2(Activity context, List<TableItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.Ticket, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}



