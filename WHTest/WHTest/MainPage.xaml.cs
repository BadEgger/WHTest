using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Xamarin.Forms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;

namespace Notes
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //本来还想用Xamarin.Forms.GoogleMaps.这个东西，，发现用不了，还是得用之前的东西。
            MapInit();
        }

        private WebTiledLayer _BasemapLayer;
        private readonly string _GoogleUri = "http://{subDomain}.google.cn/vt/lyrs=s&z={level}&x={col}&y={row}";
        private readonly List<string> _GoogleSubdomains = new List<string> { "mt2", "mt3", "mt0", "mt1", "mt4" };
        private WebTiledLayer _TDmapLayer;
        private readonly string _TDUri = "http://t{subDomain}.tianditu.com/DataServer?T=cia_w&tk=31e32d9cb4710dbe7352eb1dba3181be&x={col}&y={row}&l={level}";
        private readonly List<string> _TDSubdomains = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7" };

        private WebTiledLayer _GDmapLayer;
        private readonly string _GDUri = "http://webst0{subDomain}.is.autonavi.com/appmaptile?style=6&x={col}&y={row}&z={level}";
        private readonly List<string> _GDSubdomains = new List<string> { "0", "1", "2" };


        //高德路况信息，并不是道路信息。但是也是不重合。
        private readonly string _GDRoadUri = "https://history.traffic.amap.com/traffic?type={subDomain}&day=2&hh=14&mm=1&x={col}&y={row}&z={level}";
        private readonly List<string> _GDRoadSubdomains = new List<string> { "4" };
        //天地图和google影像配合的最好，与高德地图配合得不好。
        //天地图和高德道路地图倒是很像，但是高德的切片图有点不合。
        //但是google地图配合不了高德的道路图，高德道路图只能配高德地图
        private async void MapInit()
        {
            try
            {
                // _BasemapLayer = new WebTiledLayer(_GoogleUri, _GoogleSubdomains);
                _BasemapLayer = new WebTiledLayer(_GoogleUri, _GoogleSubdomains);
                _BasemapLayer.Name = "googleMap";
                await _BasemapLayer.LoadAsync();

                _TDmapLayer = new WebTiledLayer(_TDUri, _TDSubdomains);
                _TDmapLayer.Name = "TianDiMap";
                await _TDmapLayer.LoadAsync();

                mapView.ViewpointChanged += mapViewViewPointChanged;

                Basemap basemap = new Basemap(_BasemapLayer);
                Esri.ArcGISRuntime.Mapping.Map mainmap = new Esri.ArcGISRuntime.Mapping.Map(basemap);

                mainmap.OperationalLayers.Add(_TDmapLayer);

                mapView.Map = mainmap;



            }
            catch (Exception ex)
            {
                
            }

        }


        //怎么设置扩大缩小范围。
        private void getTile(int level, int col, int row)
        {

        }

        //地图移动事件
        private void mapViewViewPointChanged(object sender, EventArgs e)
        {
            try
            {
                //可以是可以，但是坐标系显示的不同。
                var centerPoint = mapView.VisibleArea.Extent.GetCenter();

                string x = centerPoint.X.ToString("F6");
                string y = centerPoint.Y.ToString("F6");
                Coordinate.Text = x + ", " + y;
                if (mapView.MapScale < 200000)
                {

                }
                else
                {

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


    }
}