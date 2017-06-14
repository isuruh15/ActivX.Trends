using System;
using OxyPlot;
using IView = EleSy.CV.ActiveX.Views.IView;

namespace EleSy.CV.ActiveX.Views
{
    interface ITrendView : IView
    {
        event Action ButtonClicked;

        /// <summary>
        /// Отрисовка графика
        /// </summary>
        void DrawTrends(PlotModel plotModel);

        void RefreshTrends();
    }
}
