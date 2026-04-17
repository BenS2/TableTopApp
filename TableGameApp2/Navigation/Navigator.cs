using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

using TableGameApp2.Pages;

namespace TableGameApp2.Navigation
{
    public static class Navigator
    {
        private static Frame _mainFrame;

        public static void Initialize(Frame mainFrame)
        {
            _mainFrame = mainFrame;
        }

        public static void openPage(string name)
        {
            if (name == "CreateArmy")
                _mainFrame.Navigate(new CreateArmyPage());
            if (name == "CreateHero")
                _mainFrame.Navigate(new AlterHeroPage(true));
            if(name == "EditHero")
                _mainFrame.Navigate(new AlterHeroPage(false));
            if (name == "PlayGame")
                _mainFrame.Navigate(new PlayGamePage());
            if (name == "MainPage")
                _mainFrame.Navigate(new MainPage());
        }
    }

    
}
