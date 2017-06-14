namespace EleSy.ActiveX.Controls
{
    /*[ComVisible(true)]
    [Guid()]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]*/
    public interface IActiveXEvent
    {
        //[DispId(1)]
        void OnActivate();

        //[DispId(2)]
        void OnDeactivate();

        //[DispId(3)]
        void OnError(ErrorType errorType, string message);
    }
}
