using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;
using Android.Systems;
using Android;
using Android.Content;


// EMA KochBuch Projekt
// Name: Iliass Hilmi
// Immatrikulation Nummer: 672515


namespace KochBuch
{
    [Activity(Label = "MeinKochBuch",MainLauncher =true)]
    public class MainActivity : Activity
    {
        List<TableItem> tableItems = new List<TableItem>();
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

          
            SetContentView(Resource.Layout.Main);
  

            GridView Grid = FindViewById<GridView>(Resource.Id.gridView1);
          
            tableItems.Add(new TableItem("Italienische Küsche", "(6 Rezepte)", Resource.Drawable.Italien));
            tableItems.Add(new TableItem("Spanische Küsche", "(6 Rezepte)", Resource.Drawable.Spain));
            tableItems.Add(new TableItem("Deutsche Küche", "(6 Rezepte)", Resource.Drawable.Deutschland));
            tableItems.Add(new TableItem("Portugiesische Küche", "(6 Rezepte)", Resource.Drawable.Portugal));
            tableItems.Add(new TableItem("Französische Küche", "(6 Rezepte)", Resource.Drawable.France));
            tableItems.Add(new TableItem("Türkische Küche", "(6 Rezepte)", Resource.Drawable.Turkei));
         
        
            Grid.Adapter = new HomeScreenAdapter(this, tableItems);
            Grid.ItemClick += OnListItemClick;

            DbRezept ObjDb = new DbRezept();
            if(ObjDb.empty())
            {

                ObjDb.Insert();


            }






        }
        
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
             var listView = sender as ListView;
             var t = tableItems[e.Position];
            //Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();


            if (t.Heading == "Deutsche Küche")
            {

                Intent DeIntent = new Intent(this, typeof(List));
                StartActivity(DeIntent);


            }
            else if (t.Heading == "Italienische Küsche")
            {
                Intent ItIntent = new Intent(this, typeof(Italien));
                StartActivity(ItIntent);


            }
            else if (t.Heading == "Spanische Küsche")
            {
                Intent SpIntent = new Intent(this, typeof(Spanien));
                StartActivity(SpIntent);


            }
            else if (t.Heading == "Portugiesische Küche")
            {
                Intent PoIntent = new Intent(this, typeof(Portugal));
                StartActivity(PoIntent);


            }
            else if (t.Heading == "Französische Küche")
            {
                Intent RoIntent = new Intent(this, typeof(Frankreich));
                StartActivity(RoIntent);


            }
            else if (t.Heading == "Türkische Küche")
            {
                Intent TuIntent = new Intent(this, typeof(Turkey));
                StartActivity(TuIntent);


            }


        } 



    }

    public class TableItem
    {
        public string Heading;
        public string SubHeading;
        public int ImageResourceId;
        public TableItem(string Heading, string SubHeading, int ImageResourceId)
        {
            this.Heading = Heading;
            this.SubHeading = SubHeading;
            this.ImageResourceId = ImageResourceId;
            
        }


       
        





    }

    public class HomeScreenAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<TableItem> items)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.ItemsLayout, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}

