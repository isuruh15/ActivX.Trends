using OxyPlot;

namespace EleSy.CV.ActiveX.Model.Trends
{

    abstract class TrendsServiceBase
    {
        public TrendMode Mode;
        private int Interval;
        protected PlotModel _plot;

        public abstract void InitializePlot();

        public void Dispose()
        {

        }

        public abstract void UpdatePlot();

        public PlotModel GetPlot()
        {
            return _plot;
        }
    }
}
