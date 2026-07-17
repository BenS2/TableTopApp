using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGameApp2.Data;

namespace TableGameApp2.DataAccessors
{
    public static class ArmyController
    {

        /// <summary>
        /// Gets the Hero objects that are in an army
        /// </summary>
        /// <param name="army"></param>
        /// <returns></returns>
        public static List<Hero> getArmyHeroes(Army army)
        {
            List<Hero> armyHeroes = new List<Hero>();

            foreach(Guid heroId in army._heroIds)
            {
                foreach(Hero hero in Model.Model.getHeroes())
                {
                    if(hero._guid == heroId)
                    {
                        armyHeroes.Add(hero);
                        break;
                    }
                }
            }
            return armyHeroes;
        }

        /// <summary>
        /// Gets the Heroes that are not in an army
        /// </summary>
        /// <param name="army"></param>
        /// <returns></returns>
        public static List<Hero> getNonArmyHeroes(Army army)
        {
            List<Hero> nonArmyHeroes = new List<Hero>();
            List<Hero> armyHeroes = getArmyHeroes(army);
            foreach (Hero hero in Model.Model.getHeroes())
            {
                if (!armyHeroes.Contains(hero))
                {
                    nonArmyHeroes.Add(hero);
                }
            }
            return nonArmyHeroes;
        }

    }
}
