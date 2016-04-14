using System.Windows;
using System.Windows.Controls;

namespace Paymetheus.Helpers
{
    public sealed class Navigator
    {
        private static Navigator _instance = null;
        private static readonly object padlock = new object();
        private Window _window;

        Navigator() { }

        public static Navigator Instance
        {
            get 
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new Navigator();
                    return _instance;
                }
            }
        }

        public static Navigator GetInstance(Window window = null)
        {
            if(window != null)
                Instance._window = window;
            return Instance;
        }

        public void NavigateTo(Page page)
        {
            _window.Content = page;
        }

    }
}