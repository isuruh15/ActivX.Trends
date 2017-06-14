using System.Runtime.InteropServices;
using EleSy.ActiveX.Controls;

namespace EleSy.CV.ActiveX
{
    [ComVisible(true)]
    [Guid("1CE77060-964D-4853-AF1B-2AE5FCDA586C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IEmergensyResponcePlanControlEvent
    {
        [DispId(1)]
        void OnActivate();

        [DispId(2)]
        void OnDeactivate();

        [DispId(3)]
        void OnError(ErrorType errorType, string message);
    }
}