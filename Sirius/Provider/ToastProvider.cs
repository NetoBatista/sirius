using Sirius.Enum;
using System.Timers;

namespace Sirius.Provider
{
    public class ToastProvider : IDisposable
    {
        public event Action<string, ToastLevelEnum>? OnShow;
        public event Action? OnHide;
        private System.Timers.Timer? Countdown;

        public void ShowToast(string message, ToastLevelEnum level)
        {
            OnShow?.Invoke(message, level);
            StartCountdown();
        }

        private void StartCountdown()
        {
            SetCountdown();
            if (Countdown!.Enabled)
            {
                Countdown.Stop();
            }
            Countdown!.Start();
        }

        private void SetCountdown()
        {
            if (Countdown != null)
            {
                return;
            }

            Countdown = new System.Timers.Timer(3000);
            Countdown.Elapsed += HideToast;
            Countdown.AutoReset = false;
        }

        private void HideToast(object? source, ElapsedEventArgs args) => OnHide?.Invoke();

        public void Dispose() => Countdown?.Dispose();
    }
}
