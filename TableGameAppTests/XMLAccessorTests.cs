using TableGameApp2.Data;
using TableGameApp2.DataAccessors;
using System.Linq;

namespace TableGameAppTests
{
    [TestClass]
    public class XMLAccessorTests
    {
        [TestMethod]
        public void saveAndLoadHeroesCorrectly()
        {

            //Arrange
            XMLAccessor._heroStatsFileName = "testHeroStatus.xml";
            List<Status> statuses = new List<Status>();
            statuses.Add(new Status("Might", "3"));
            statuses.Add(new Status("Will", "2"));

            Hero hero = new Hero("Aragorn", statuses, "Has the Mighty Hero special rule", Guid.NewGuid());

            List<Hero> expectedHeroes = new List<Hero>();
            expectedHeroes.Add(hero);
            //Act
            XMLAccessor.saveHeroes(expectedHeroes);
            List<Hero> actualHeroes = XMLAccessor.loadHeroes();
            bool heroesEqual = true;

            heroesEqual = expectedHeroes.SequenceEqual(actualHeroes);

            //Assert
            Assert.IsTrue(heroesEqual, "Failed to save or load heroes");
        }
    }
}
