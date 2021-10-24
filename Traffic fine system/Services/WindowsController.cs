using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Traffic_fine_system
{
    public class WindowsController
    {
        private Stack<Window> _windowsStack;

        public WindowsController()
        {
            _windowsStack = new Stack<Window>();
        }

        public void Show<T>(Window window, T viewModel) where T: IViewModel
        {
            if (_windowsStack.Count != 0)
               _windowsStack.Peek().Hide();

            var view = window as IView<T>;
            view?.Initialize(viewModel);

            _windowsStack.Push(window);
            window.Closing += Close;
            window.Show();
        }

        public void Close(object sender, CancelEventArgs e)
        {
            if (_windowsStack.Count != 0)
                _windowsStack.Pop();

            if (_windowsStack.Count != 0)
                _windowsStack.Peek().Show();
        }

    }
}
