using TableGameApp2.Data;
namespace TableGameAppTests
{
    [TestClass]
    public class HeroUnitTest
    {
        [TestMethod]
        public void heroHasCorrectStatuses()
        {
            
            //Arrange
            List<Status> expectedStatuses = new List<Status>();
            expectedStatuses.Add(new Status("Might", "3"));
            expectedStatuses.Add(new Status("Will", "2"));

            Hero hero = new Hero("Aragorn", expectedStatuses, "Has the Mighty Hero special rule");

            //Act
            List<Status> currentStatuses = hero.getStatuses();

            //Assert
            Assert.AreEqual(expectedStatuses, currentStatuses, "Statuses not equal");
        }

        [TestMethod]
        public void heroHasCorrectNotes()
        {
            //Arrange
            String expectedNotes = "Has the Mighty Hero special rule";
            Hero hero = new Hero("Aragorn", new List<Status>(), expectedNotes);

            //Act
            String actualHeroNotes = hero._notes;

            //Assert
            Assert.AreEqual(expectedNotes, actualHeroNotes, "Notes are not the same");

        }

        [TestMethod]
        public void heroHasCorrectName()
        {
            //Arrange
            String expectedName = "Aragorn";
            Hero hero = new Hero("Aragorn", new List<Status>(), expectedName);

            //Act
            String actualHeroName = hero._name;

            //Assert
            Assert.AreEqual(expectedName, actualHeroName, "Names are not the same");

        }
    }
}