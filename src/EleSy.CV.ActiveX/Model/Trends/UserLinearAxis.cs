using OxyPlot.Axes;

namespace EleSy.CV.ActiveX.Model.Trends
{
    class UserLinearAxis : LinearAxis
    {
        public void SetMinimum(double valueMin)
        {
            ActualMinimum = valueMin;
        }

        public void SetMaximum(double valueMax)
        {
            ActualMaximum = valueMax;
        }
    }
}
