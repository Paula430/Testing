using Microsoft.Playwright.NUnit;
using WUP.Pages;

namespace WUP.Tests
{

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class MapTest:PageTest
    {
        LoginPage LoginPage;
        MapPage MapPage;
        const string nameMap = "Testowe paula mapowanie";
        const string nameMapToAdd = "Testowe paula mapowanie- dodawanie";
        const string nameAfterEdit = "Testowe paula mapowanie- po edycji";
        const string nameToEdit = "Testowe paula mapowanie- do edycji";

        [SetUp]
        public async Task Setup()
        {
            LoginPage = new LoginPage(Page);
            await LoginPage.GoTo();
            await LoginPage.SignIn();
            MapPage = new MapPage(Page);
            await MapPage.GoTo();
            await MapPage.AddMap(nameMap,"1","2");
            await MapPage.GoTo();
        }

        [TearDown]
        public async Task Teardown()
        {
            await MapPage.GoTo();
            await MapPage.CleanUpMap("Testowe paula");
        }

        [Test]
        public async Task AddMapTest()
        {
            await MapPage.AddMap(nameMapToAdd, "1", "2");
            Assert.That(await MapPage.IsAnnouncement("Sukces!Pomyślnie dodano definicję mapowania."), Is.True);
        }

        [Test]
        public async Task AddMapWithoutNameTest()
        {
            await MapPage.AddMap("", "1", "2");
            Assert.Multiple(async () =>
            {
                Assert.That(await MapPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
                Assert.That(await MapPage.IsAnnouncement("Pole jest wymagane."), Is.True);
            });
        }

        [Test]
        public async Task AddMapWithIncorrectValuesTest()
        {
            await MapPage.AddMap(nameMapToAdd, "xd", "dx");
            Assert.That(await MapPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
        }

        [TestCase("csv")]
        [TestCase("xls")]
        [TestCase("xlsx")]
        public async Task ImportMapTest(string fileType)
        {
            await MapPage.AddMapByImportFile(nameMapToAdd+" "+ fileType, "D:/Dokumenty/infomex/TestoweMapowanie." + fileType);
            Assert.That(await MapPage.IsAnnouncement("Sukces!Pomyślnie dodano definicję mapowania."));
        }

        [Test]
        public async Task EditMapTest()
        {
            await MapPage.EditMap(nameMap, nameAfterEdit);
            Assert.That(await MapPage.IsAnnouncement("Sukces!Pomyślnie zapisano definicję mapowania."), Is.True);
        }

        [Test]
        public async Task EditTheSameNameMapTest()
        {
            await MapPage.AddMap(nameToEdit, "1", "2");
            await MapPage.EditMap(nameToEdit, nameMap);
            Assert.That(await MapPage.IsAnnouncement("Taka nazwa mapowania już istnieje"), Is.True);

            //Assert.Multiple(async () =>
            //{
            //    Assert.That(await MapPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
            //    Assert.That(await MapPage.IsAnnouncement("Taka nazwa mapowania już istnieje"), Is.True);

            //});
        }










    }
}
