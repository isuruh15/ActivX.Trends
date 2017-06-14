using EleSy.CV.ActiveX.Views;

namespace EleSy.CV.ActiveX.Presenters
{
    class SettingsPresenter : IPresenter
    {
        private readonly ISettingsView _settingsView;


        public SettingsPresenter(ISettingsView settingsView)
        {
            _settingsView = settingsView;
        }

        public void Run()
        {
            _settingsView.Show();
        }
    }
}
