using System.Runtime.InteropServices;

namespace EleSy.ActiveX.Controls
{
    [ComVisible(true)]
    public enum ErrorType
    {
        SuspendUpdateError,
        ResumeUpdateError,
        StopRunTimeError,
        StartRunTimeError,
        ActivateError,
        DeactivateError,
    }
}