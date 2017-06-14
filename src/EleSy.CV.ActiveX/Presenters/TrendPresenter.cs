using EleSy.CV.ActiveX.Model.Trends;
using EleSy.CV.ActiveX.Views;

namespace EleSy.CV.ActiveX.Presenters
{
    class TrendPresenter : IPresenter
    {
        private readonly ITrendView _trendView;
        private readonly TrendsServiceBase _trendsService;
        private readonly System.Timers.Timer _timer;

        public TrendPresenter(ITrendView trendView, TrendsServiceBase trendsService)
        {
            _trendView = trendView;
            _trendsService = trendsService;

            //_trendView.ButtonClicked += TrendViewOnButtonClicked;
            SetTimer(1000);
        }

        private void SetTimer(int interval)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(interval);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _trendsService.UpdatePlot();
            _trendView.RefreshTrends();
        }
        public void Run()
        {
            _trendView.DrawTrends(_trendsService.GetPlot());
            _trendView.Show();
        }

        public static System.Timers.Timer aTimer { get; set; }
    }
}
