using Microsoft.JSInterop;

namespace Sirius.Provider
{
    public class JavaScriptProvider
    {
        private readonly IJSRuntime _jsRunTime;
        private readonly ToastProvider _toastProvider;
        public JavaScriptProvider(IJSRuntime jSRuntime, ToastProvider toastProvider)
        {
            _jsRunTime = jSRuntime;
            _toastProvider = toastProvider;
        }

        public void CopyToClipBoard(string text)
        {
            _jsRunTime.InvokeVoidAsync("navigator.clipboard.writeText", text);
            _toastProvider.ShowToast("Copiado com sucesso", Enum.ToastLevelEnum.Success);
        }
    }
}
