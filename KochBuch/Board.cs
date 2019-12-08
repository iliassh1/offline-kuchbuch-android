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

    [Activity(Label = "Mein KochBuch")]
    public class Board : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Board);

            // Create your application here




            DbRezept Db = new DbRezept();
           

            TextView TxtTitel = FindViewById<TextView>(Resource.Id.TxtTitel);
            TextView TxtDauer = FindViewById<TextView>(Resource.Id.TxtDauer);
            TextView TxtZutaten = FindViewById<TextView>(Resource.Id.TxtZutaten);
            TextView TxtInhalt = FindViewById<TextView>(Resource.Id.TxtInhalt);
            var Foto = FindViewById<ImageView>(Resource.Id.Img);



            string Data = Intent.GetStringExtra("Data") ?? "Data not available";
           int  resourceId = (int)typeof(Resource.Drawable).GetField(Db.selectImageNachName(Data)).GetValue(null);


            TxtTitel.Text = Data;
            Foto.SetImageResource(resourceId);
            TxtDauer.Text = " "+Db.selectDauer(Data)+" Min";
            TxtZutaten.Text = Db.selectZutaten(Data);
            TxtInhalt.Text = Db.select(Data);


        }

      
    }
}