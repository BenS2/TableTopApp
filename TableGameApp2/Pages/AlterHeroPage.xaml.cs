using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TableGameApp2.Data;

namespace TableGameApp2.Pages
{
    /// <summary>
    /// Interaction logic for AlterHeroPage.xaml
    /// </summary>
    public partial class AlterHeroPage : Page
    {
        bool _isCreate;
        Hero _currentHero;
        public AlterHeroPage(bool isCreate = true, Hero selectedHero = null)
        {
            this.StatusesList.DataContext = this;
            _isCreate = isCreate;
            if (_isCreate)
            {
                _currentHero = new Hero();
                this.SelectHeroLabel.IsEnabled = false;
                this.SelectHeroLabel.Visibility = Visibility.Collapsed;
                this.SelectHeroCombo.IsEnabled = false;
                this.SelectHeroCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                _currentHero = selectedHero;
                this.SelectHeroLabel.IsEnabled = true;
                this.SelectHeroLabel.Visibility = Visibility.Visible;
                this.SelectHeroCombo.IsEnabled = true;
                this.SelectHeroCombo.Visibility = Visibility.Visible;
            }

            this.
            InitializeComponent();
            
        }
    }
}
