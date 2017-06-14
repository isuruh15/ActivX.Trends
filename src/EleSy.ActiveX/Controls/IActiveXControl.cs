namespace EleSy.ActiveX.Controls
{
    /*
    [ComVisible(true)]
    [Guid()]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]*/
    public interface IActiveXControl
    {

        bool AutoActivate { get; set; }
        bool AutoRunTime { set; get; }
        void SuspendUpdate();
        void ResumeUpdate();
        void StopRunTime();
        void StartRunTime();
        void Activate();
        void Deactivate();
        bool Status { get; set; }
        bool VisionX { get; set; }
        bool VisionY { get; set; }
        bool VisionTitleX { get; set; }
        bool VisionTitleY { get; set; }


    }
}
