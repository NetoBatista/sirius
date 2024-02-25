using Microsoft.JSInterop;

namespace Sirius.Provider
{
    public class JavaScriptProvider(IJSRuntime jSRuntime, ToastProvider toastProvider)
    {
        public void CopyToClipBoard(string text)
        {
            _ = jSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
            toastProvider.ShowToast("Copiado com sucesso", Enum.ToastLevelEnum.Success);
        }

        public void ApplyCurrencyMask()
        {
            _ = jSRuntime.InvokeVoidAsync("window.sirius.applyCurrencyMask");
        }

    }
}
