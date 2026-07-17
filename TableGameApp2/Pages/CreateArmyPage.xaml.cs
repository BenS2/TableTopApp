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
using TableGameApp2.Model;
using TableGameApp2.DataAccessors;

namespace TableGameApp2.Pages
{
    /// <summary>
    /// Interaction logic for CreateArmyPage.xaml
    /// </summary>
    public partial class CreateArmyPage : Page
    {
        ObservableCollection<Army> _armies;
        ObservableCollection<Hero> _selectedHeroes;
        ObservableCollection<Hero> _nonSelectedHeroes;
        Army _selectedArmy;
        public CreateArmyPage()
        {
            InitializeComponent();

            SelectArmyCombo.DataContext = this;
            ArmyHeroes.DataContext = this;
            NonArmyHeroes.DataContext = this;

            _selectedHeroes = new ObservableCollection<Hero>();
            _nonSelectedHeroes = new ObservableCollection<Hero>();

            _armies = Model.Model.getArmies();
            this.SelectArmyCombo.ItemsSource = Model.Model._armies;
            SelectArmyCombo.DisplayMemberPath = "_armyName";
            
            this.ArmyHeroes.ItemsSource = _selectedHeroes;
            this.ArmyHeroes.DisplayMemberPath = "_name";
            
            //this.NonArmyHeroes.ItemsSource = _nonSelectedHeroes;
            this.NonArmyHeroes.DisplayMemberPath = "_name";

            setCurrentArmy(new Army());
            populateTables();
        }

        public void setCurrentArmy(Army army)
        {
            _selectedArmy = army;
        }

        public void populateTables()
        {
            if (_selectedArmy != null)
            {
                _selectedHeroes = new ObservableCollection<Hero>(ArmyController.getArmyHeroes(_selectedArmy));
                _nonSelectedHeroes = new ObservableCollection<Hero>(ArmyController.getNonArmyHeroes(_selectedArmy));

            }
            //if there is no army selected, then populate the non-selected heroes table with everything
            else
            {
                //declare a selected heroes list so that items from over armies are not kept in the list
                _selectedHeroes = new ObservableCollection<Hero>();
                _nonSelectedHeroes = new ObservableCollection<Hero>(Model.Model.getHeroes());
            }


            this.ArmyHeroes.ItemsSource = _selectedHeroes;
            ArmyHeroes.Items.Refresh();

            this.NonArmyHeroes.ItemsSource = _nonSelectedHeroes;
            NonArmyHeroes.Items.Refresh();

        }

        private void OnAddHero(object sender, RoutedEventArgs e)
        {
            transferHero();
        }

        private void OnRemoveHero(object sender, RoutedEventArgs e)
        {
            transferHero(false);
        }

        public void transferHero(bool add = true)
        {
            if(add)
            {
                if (NonArmyHeroes.SelectedItem != null)
                {
                    Hero hero = (Hero)NonArmyHeroes.SelectedItem;
                    _selectedHeroes.Add(hero);
                    _nonSelectedHeroes.Remove(hero);
                }
                else
                {
                    string message = "Please select a profile to add from the right table";
                    MessageBoxResult result = MessageBox.Show(message,
                              message,
                              MessageBoxButton.OK,
                              MessageBoxImage.Information);
                }
            }
            else
            {
                if (ArmyHeroes.SelectedItem != null)
                {
                    Hero hero = (Hero)ArmyHeroes.SelectedItem;
                    _nonSelectedHeroes.Add(hero);
                    _selectedHeroes.Remove(hero);
                }
                else
                {

                    string message = "Please select a profile to remove from the left table";
                    MessageBoxResult result = MessageBox.Show(message,
                              message,
                              MessageBoxButton.OK,
                              MessageBoxImage.Information);
                }
            }
        }

        void selectArmy(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            int selected = SelectArmyCombo.SelectedIndex;

            setCurrentArmy(Model.Model._armies[selected]);
            populateTables();
            ArmyName.Text = _selectedArmy._armyName;
        }

        private void OnSaveArmy(object sender, RoutedEventArgs e)
        {
            _selectedArmy._armyName = ArmyName.Text;

            _selectedArmy._heroIds = new List<Guid>();
            foreach(Hero selectedHero in _selectedHeroes)
            {
                _selectedArmy._heroIds.Add(selectedHero._guid);
            }

            if (_selectedArmy._armyId == Guid.Empty)
            {
                _selectedArmy._armyId = Guid.NewGuid();
                //if there is no id, it is new so add it to the model
                Model.Model.addArmy(_selectedArmy);
            }
            var checkArmies = Model.Model.getArmies();
            List<Army> updatedArmies = Model.Model.getArmies().ToList();

            XMLAccessor.saveArmies(updatedArmies);
        }
        
        void OnNewArmy(object sender, RoutedEventArgs e)
        {
            setCurrentArmy(null);
            populateTables();
            ArmyName.Text = "";
        }
    }
}
