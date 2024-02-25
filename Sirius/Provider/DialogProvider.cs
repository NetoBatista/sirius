using Microsoft.AspNetCore.Components;

namespace Sirius.Provider
{
    public class DialogProvider
    {
        public event Action<string, RenderFragment>? Open;
        public event Action? Close;
        public event Func<object?, Task>? CallBack;
        public void OpenDialog(string title, RenderFragment body, Func<object?, Task>? callback = null)
        {
            CloseDialog();
            CallBack = callback;
            Open?.Invoke(title, body);
        }
        public void CloseDialog(object? sender = default!)
        {
            Close?.Invoke();
            if (sender != null)
            {
                CallBack?.Invoke(sender);
            }
            CallBack = null;
        }
    }
}
