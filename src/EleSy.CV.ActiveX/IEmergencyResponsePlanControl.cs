using System.Runtime.InteropServices;

namespace EleSy.CV.ActiveX
{
    [ComVisible(true)]
    [Guid("1B0C39E1-A9AB-4534-93A3-F07FA1CE3A8A")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IEmergensyResponcePlanControl
    {
        string Host { get; set; }
        string OpcServer { get; set; }
        bool AutoActivate { get; set; }
        bool AutoRunTime { set; get; }
        void SuspendUpdate();
        void ResumeUpdate();
        void StopRunTime();
        void StartRunTime();
        void Activate();
        void Deactivate();
        string MinesInfoXml { get; set; }
        bool CheckBoxSize { get; set; }
        bool Status { get; set; }
        bool VisionX { get; set; }
        bool VisionY { get; set; }
        bool VisionTitleX { get; set; }
        bool VisionTitleY { get; set; }

        //DateTime StartPer { get; set; }
        //DateTime EndPer { get; set; }
        //int NumberOfPositionAtBegining { get; set; }
        //int NumberOfPositionForToday { get; set; }
        //int ExtractedPosition { get; set; }
        //int AddedPosition { get; set; }
        //int AddedChanges { get; set; }
        //int Involved { get; set; }

    }
}