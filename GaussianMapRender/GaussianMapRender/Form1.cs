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
            gmap.Zoom = MAP_ZOOM;

            // Debug Code
            displayMarkers();
            //latLngToPixel(0, 0);
        }

        private void gmap_Load(object sender, EventArgs e)
        {

        }

        public Image getGmapImage()
        {
            Image img = gmap.ToImage();
            //Console.WriteLine(img.Width);
            //Console.WriteLine(img.Height);
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

        public void displayMarkers()
        {
            BitmapCalculator bc = new BitmapCalculator();
            ParserManager P = new ParserManager();
            P.execute();
            List<double> lats = P.latitudeValues;
            List<double> lngs = P.longitudeValues;
            List<double> alphaValues = P.alphaValues;
            P.scale(alphaValues);

            // 1. Create the overlay
            GMapOverlay markers = new GMapOverlay("markers");
            int count = 0;
            for (int i =0; i < lats.Count; i++)
            {
                //Console.WriteLine(lats[i]);
                for (int j = 0; j < lngs.Count; j++)
                {
                    //Console.WriteLine(lats[i] + " " + lngs[j]);
                    PointLatLng point = new PointLatLng(lats[i], lngs[j]);
                    Bitmap temp = getAlphaMap((int)alphaValues[count], 3, 3);
                    GMapMarker marker = new GMarkerGoogle(point, temp);
                    
                    // 2. Add markers
                    markers.Markers.Add(marker);

                    // 3. Cover map with overlay
                    count++;
                }
            }
            gmap.Overlays.Add(markers);

            // TEST BITMAP CALCULATOR
            PointF topLeft = new PointF();
            PointF topRight = new PointF();
            PointF botLeft = new PointF();
            PointF botRight = new PointF();
            //lng = x, lat = y
            topLeft.X = (float)gmap.ViewArea.LocationTopLeft.Lng;
            topLeft.Y = (float)gmap.ViewArea.LocationTopLeft.Lat;
            topRight.X = (float)(gmap.ViewArea.LocationTopLeft.Lng + gmap.ViewArea.WidthLng);
            topRight.Y = topLeft.Y;
            botRight.X = (float)gmap.ViewArea.LocationRightBottom.Lng;
            botRight.Y = (float)gmap.ViewArea.LocationRightBottom.Lat;
            botLeft.X = (float)(gmap.ViewArea.LocationRightBottom.Lng - gmap.ViewArea.WidthLng);
            botLeft.Y = botRight.Y;
            Console.WriteLine("TL: " + topLeft.ToString());
            Console.WriteLine("TR: " + topRight.ToString());
            Console.WriteLine("BR: " + botRight.ToString());
            Console.WriteLine("BL: " + botLeft.ToString());

            // calculate distances
            double maxWidthDistance = bc.calculateDistance(System.Convert.ToDouble(topLeft.Y), System.Convert.ToDouble(topLeft.X),
                System.Convert.ToDouble(topRight.Y), System.Convert.ToDouble(topRight.X));
            double maxHeightDistance = bc.calculateDistance(System.Convert.ToDouble(topLeft.Y), System.Convert.ToDouble(topLeft.X),
                System.Convert.ToDouble(botRight.Y), System.Convert.ToDouble(botRight.X));
            //double maxWidthDistance2 = bc.calculateDistance(lats[0], lngs[0], lats[0], lngs[lngs.Count - 1]);
            Console.WriteLine("WIDTH IN KM: " + maxWidthDistance / 1000);
            Console.WriteLine("HEIGHT IN KM: " + maxHeightDistance / 1000);

            // RENDER BITMAPS
        }

        // Lat/Lng to Pixel Code

        public int[] latLngToPixel(double lat, double lng)
        {
            Console.WriteLine("PIXEL WIDTH: " + gmap.Width);
            Console.WriteLine("POXEL HEIGHT: " + gmap.Height);
            return null;
        }

        private void zoomplus_btn_Click_1(object sender, EventArgs e)
        {
            MAP_ZOOM++;
            gmap.Zoom = MAP_ZOOM;
        }

        private void SaveMap_Click(object sender, EventArgs e)
        {
            Image map = gmap.ToImage();
            map.Save("C:\\Users\\tejas\\Desktop\\MapImgs\\p19.png");
        }
    }
}
