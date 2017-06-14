using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using EleSy.CV.ActiveX.Forms;
using EleSy.CV.ActiveX.Model.OpcClients;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace EleSy.CV.ActiveX.Model.Trends
{
    internal class TrendsService : TrendsServiceBase
    {
        private OpcValueResult _opcValue;
        private OpcValueResult _opcDistanceNow;
        private OpcValueResult _opcDistanceEnd;
        private OpcValueResult _opcDimension = new OpcValueResult();
        private OpcValueResult _point;
        private OpcDaClient opcDa;
        private bool _isAxisSetted;
        private string test { get; set; }
        // TEMP!
        private int _incrementValue;
        private double maxxy;
        private OpcDaClientBase _client;
        private double _distance;
        public bool VisionX;
        public bool VisionY;
        public bool TitleX;
        public bool TitleY;
        //private Settings _path;
        private string _tag;
        //private const string path = @"c:\pathToTag.txt";
        private ActiveXPropertiesForm _server;
        public string Host { get; set; }
        public string OpcServer { get; set; }
        public TrendsService(string host, string opcserver, bool visionX , bool visionY , bool titleX, bool titleY)
        {

            VisionX = visionX;
            VisionY = visionY;
            TitleX = titleX;
            TitleY = titleY;

            var set = new Settings();

            var tag = File.ReadAllLines(set.Path);
            _client = new OpcDaClient();
            //_client = new OpcDaClientProxy();
            _client.Connect(host, opcserver);
            _client.Subscribe(tag[2], tag[1], tag[0],tag[3]);
            //_client.Subscribe("integer", "distanceNow", "distanceEnd");
           _client.DataChanged += ClientOnDataChanged;
            InitializePlot();
            maxxy = 0;
        }
        private void ClientOnDataChanged(object sender, EventArgs e)
        {
            var handler = e as DataChangedEventArgs;
            if (handler != null)
            {
                _opcValue = handler.Value;
                _opcDistanceNow = handler.DistanceNow;
                _opcDistanceEnd = handler.DistanceEnd;
                _opcDimension = handler.Dimension;
            }
            if (!TitleY) return;
            if (!_isAxisSetted && _opcDimension.Demenision != null)
            {
                var yAxis = _plot.Axes.SingleOrDefault(axe => axe.Key.Equals("Y"));
                if (yAxis != null)
                    SetYAxis(yAxis as UserLinearAxis);
            }
        }
        public sealed override void InitializePlot()
        {
            _plot = new PlotModel() { Title = "" };
            
            var series = new LineSeries();
            series.LineStyle = LineStyle.Dot;
            series.ItemsSource = new List<DataPoint>();
            _plot.TextColor = OxyColor.FromRgb(255, 255, 255);
            _plot.PlotAreaBorderColor =  OxyColor.FromRgb(255, 255, 255);
            _plot.SubtitleColor = OxyColor.FromRgb(255, 255, 255);
            _plot.TitleColor = OxyColor.FromRgb(255, 255, 255);
            _plot.PlotAreaBorderColor = OxyColor.FromRgb(255, 255, 255);
            _plot.Series.Add(series);

            var xAxis = new UserLinearAxis()
            {
                Position = AxisPosition.Bottom,
                
                IntervalLength = 60,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                Key = "X",
                AxislineColor = OxyColor.FromRgb(255, 255, 255),
                TextColor = OxyColor.FromRgb( 255, 255, 255),
                TicklineColor = OxyColor.FromRgb(255, 255, 255),
                MajorGridlineColor = OxyColor.FromRgb(165, 165 , 165),
                MinorGridlineColor = OxyColor.FromRgb(165, 165, 165)
                

            };
            if (TitleX)
            {
                xAxis.Title = "Дистанция, [м]";
            }
            xAxis.IsAxisVisible = VisionX;
            var yAxis = new UserLinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Solid,
                IntervalLength = 40,
                Position = AxisPosition.Left,
                AxislineColor = OxyColor.FromRgb(255, 255, 255),
                TextColor = OxyColor.FromRgb( 255, 255, 255),
                ExtraGridlineColor = OxyColor.FromRgb(255, 255, 255),
                TicklineColor = OxyColor.FromRgb(255, 255, 255),
                MajorGridlineColor = OxyColor.FromRgb(165, 165 , 165),
                MinorGridlineColor = OxyColor.FromRgb(165, 165 , 165),
                //Title = "2",
                Key = "Y"
            };
            yAxis.IsAxisVisible = VisionY;
            _plot.Axes.Add(xAxis);
            _plot.Axes.Add(yAxis);
        }
        private void SetYAxis(UserLinearAxis yAxis)
        {
            yAxis.Title = _opcDimension.Demenision;
            _isAxisSetted = true;
        }
        public override void UpdatePlot()
        {
            #region Line

            if (_opcValue != null)
            {

                var currentSeries = _plot.Series.LastOrDefault() as LineSeries;

                if (currentSeries == null)
                {
                    currentSeries = new LineSeries();
                    currentSeries.StrokeThickness = 22;

                    currentSeries.LineStyle = LineStyle.Dot;
                    currentSeries.Color = OxyColors.Black;

                    _plot.Series.Add(currentSeries);
                    _plot.InvalidatePlot(true);
                }

                if (_opcValue.Quality >= OpcValueResult.GoodQuality)
                {
                    if (currentSeries.LineStyle != LineStyle.Solid)
                    {
                        currentSeries = new LineSeries();
                        currentSeries.LineStyle = LineStyle.Solid;
                        currentSeries.Color = OxyColors.Brown;

                        currentSeries.XAxisKey = "X";

                        if ((_plot.Series.Last() as LineSeries).Points.Count != 0)
                        {
                            currentSeries.Points.Add((_plot.Series.Last() as LineSeries).Points.Last());
                        }

                        _plot.Series.Add(currentSeries);
                        _plot.InvalidatePlot(true);

                    }
                }

                else if (_opcValue.Quality < OpcValueResult.GoodQuality)
                {
                    if (currentSeries.LineStyle != LineStyle.Dot)
                    {
                        currentSeries = new LineSeries();
                        currentSeries.LineStyle = LineStyle.Dot;
                        currentSeries.Color = OxyColors.Brown;

                        currentSeries.XAxisKey = "X";

                        if ((_plot.Series.Last() as LineSeries).Points.Count != 0)
                        {
                            currentSeries.Points.Add((_plot.Series.Last() as LineSeries).Points.Last());
                        }

                        _plot.Series.Add(currentSeries);

                        _plot.InvalidatePlot(true);
                    }
                }
            #endregion
                _point = new OpcValueResult();
                var points = currentSeries.Points;
                var lastPoint = points.LastOrDefault();
                currentSeries.Points.Add(new DataPoint(_opcDistanceNow.Value,
                    _opcValue.Value));
                if (_opcDistanceNow.Value == 0)
                {
                    points.Clear();
                    maxxy = 0;
                }

                points.Add(new DataPoint(DateTimeAxis.ToDouble(_opcDistanceNow.Value), _opcValue.Value));
                _point.Value = _opcValue.Value;
                _opcValue = null;
                //Минимальное  и максимальное значение по оси x
                (_plot.Axes[0] as UserLinearAxis).SetMinimum(0);
                if (_opcDistanceEnd == null) return;

                (_plot.Axes[0] as UserLinearAxis).SetMaximum(Convert.ToDouble(_opcDistanceEnd.Value));
                test = _opcDimension.Demenision;

                if (_point.Value >= maxxy)
                {
                    maxxy = _point.Value;
                }
                (_plot.Axes[1] as UserLinearAxis).SetMinimum(0);
                (_plot.Axes[1] as UserLinearAxis).SetMaximum(maxxy + 15);
            }
        }
    }
}
