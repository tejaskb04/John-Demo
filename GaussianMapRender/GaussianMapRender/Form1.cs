using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Threading;
using System.Collections;
using System.Diagnostics;

namespace GaussianMapRender
{
    public partial class Form1 : Form
    {
        public int MAP_ZOOM = 5;    // default zoom of map

        private const String DEFAULT_LOCATION = "Seattle, Washington";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords(DEFAULT_LOCATION);
            gmap.ShowCenter = false;
            gmap.Zoom = 5;

            // Debug Code
            latLngToPixel();
        }

        private void gmap_Load(object sender, EventArgs e)
        {

        }

        public Image getGmapImage()
        {
            Image img = gmap.ToImage();
            Console.WriteLine(img.Width);
            Console.WriteLine(img.Height);
            return img;
        }

        public void renderBitmaps(List<double> lats, List<double> lngs, List<double> alphaValues, Image img)
        {
            Bitmap[,] preStitchedCollection = new Bitmap[lats.Count, lngs.Count];
            int count = 0;
            for (int i = 0; i < lats.Count; i++)
            {
                for (int j = 0; j < lngs.Count; j++)
                {
                    // add bitmap to collection for stitching process
                    //preStitchedCollection[i, j] = getAlphaMap((int)alphaValues[count], width, height);
                    count++;
                }
            }

        }

        public Bitmap getAlphaMap(double alphaValue, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            Color c = Color.FromArgb(((int)(alphaValue)), 255, 0, 0);
            Brush b = new SolidBrush(c);
            g.FillRectangle(b, 0, 0, width, height);
            return bmp;
        }

        // TEST SCALE

        public void latLngToPixel()
        {
            BitmapCalculator bc = new BitmapCalculator();
            ParserManager P = new ParserManager();
            P.execute();
            List<double> lats = P.latitudeValues;
            List<double> lngs = P.longitudeValues;
            List<double> alphaValues = P.alphaValues;

            // 1. Create the overlay
            GMapOverlay markers = new GMapOverlay("markers");

            for (int i =0; i < lats.Count; i++)
            {
                //Console.WriteLine(lats[i]);
                for (int j = 0; j < lngs.Count; j++)
                {
                    //Console.WriteLine(lats[i] + " " + lngs[j]);
                    PointLatLng point = new PointLatLng(lats[i], lngs[j]);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);
                    //marker.Position
                    // 2. Add markers
                    markers.Markers.Add(marker);

                    // 3. Cover map with overlay
                }
            }
            gmap.Overlays.Add(markers);

        }
    }
}
