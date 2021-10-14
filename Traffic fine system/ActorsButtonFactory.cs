using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Traffic_fine_system
{
    public class ActorsButtonFactory
    {
        public Button CreateAButton(ActorType actor, RoutedEventHandler action)
        {
            Button btn = new Button();
            btn.Height = 80;
            btn.Width = 150;
            btn.Content = actor;
            btn.Click += action;

            return btn;
        }
    }
}
