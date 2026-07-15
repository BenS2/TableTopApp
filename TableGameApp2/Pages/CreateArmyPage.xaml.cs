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

namespace TableGameApp2.Pages
{
    /// <summary>
    /// Interaction logic for CreateArmyPage.xaml
    /// </summary>
    public partial class CreateArmyPage : Page
    {
        ObservableCollection<Army> _armies;
        public CreateArmyPage()
        {
            InitializeComponent();
            _armies = Model.Model.getArmies();
            this.SelectArmyCombo.ItemsSource = Model.Model._armies;
            SelectArmyCombo.DisplayMemberPath = "_armyName";



        }
    }
}
