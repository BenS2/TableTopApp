using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGameApp2.Data;
using TableGameApp2.DataAccessors;

namespace TableGameApp2.Model
{
    public static class Model
    {
        public static ObservableCollection<Hero> _heroes;
        public static void loadHeroes()
        {
            _heroes = new ObservableCollection<Hero>(XMLAccessor.loadHeroes());    
        }

        public static void addHero(Hero hero)
        {
            if(!_heroes.Contains(hero))
                _heroes.Add(hero);
        }
        public static void saveHeroes()
        {
            XMLAccessor.saveHeroes(_heroes.ToList());
        }

        public static ObservableCollection<Hero> getHeroes()
        {
            return _heroes;
        }

    }
}
