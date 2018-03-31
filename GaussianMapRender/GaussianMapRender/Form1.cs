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
    }
}
