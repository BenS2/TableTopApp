using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TableGameApp2.DataAccessors;
using TableGameApp2.Model;
namespace TableGameApp2.Pages
{
    /// <summary>
    /// Interaction logic for AlterHeroPage.xaml
    /// </summary>
    public partial class AlterHeroPage : Page
    {
        bool _isCreate;
        Hero _currentHero;
        ObservableCollection<Status> _statuses;
        ObservableCollection<Hero> _heroes;

        public AlterHeroPage(bool isCreate = true)
        {
            this.DataContext = this;
            _isCreate = isCreate;

            _heroes = Model.Model.getHeroes();
            if (_heroes.Count > 0 && !_isCreate)
            {
                _currentHero = _heroes[0];
            }
            else
            {
                _currentHero = new Hero();
            }

            if (_currentHero != null)
            {
                _statuses = new ObservableCollection<Status>(_currentHero._statuses);

            }
            else
            {
                _statuses = new ObservableCollection<Status>();
            }
            this.InitializeComponent();
            this.SelectHeroCombo.ItemsSource = Model.Model._heroes;
            SelectHeroCombo.DisplayMemberPath = "_name";
            StatusesGrid.DataContext = this;
            this.StatusesGrid.ItemsSource = _statuses;


            if (_isCreate)
            {
                this.SelectHeroLabel.IsEnabled = false;
                this.SelectHeroLabel.Visibility = Visibility.Collapsed;
                this.SelectHeroCombo.IsEnabled = false;
                this.SelectHeroCombo.Visibility = Visibility.Collapsed;
            }
            else
            {
                HeroName.Text = _currentHero._name;
                HeroNotes.Text = _currentHero._notes;
                this.SelectHeroLabel.IsEnabled = true;
                this.SelectHeroLabel.Visibility = Visibility.Visible;
                this.SelectHeroCombo.IsEnabled = true;
                this.SelectHeroCombo.Visibility = Visibility.Visible;
            }
        }

        void OnSaveHero(object sender, RoutedEventArgs e)
        {
            _currentHero._name = HeroName.Text;
            _currentHero._notes = HeroNotes.Text;
            _currentHero._statuses = _statuses.ToList();
            Model.Model.addHero(_currentHero);
            Model.Model.saveHeroes();
        }

        /// <summary>
        /// handle the hero select box having an item selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void selectHero(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            int selected = SelectHeroCombo.SelectedIndex;
            OnSaveHero(sender, e);
            _currentHero = Model.Model._heroes[selected];
            _statuses = new ObservableCollection<Status>(_currentHero._statuses);
            this.StatusesGrid.ItemsSource = _statuses;
            HeroName.Text = _currentHero._name;
            HeroNotes.Text = _currentHero._notes;
            StatusesGrid.Items.Refresh();
        }
    }
}
