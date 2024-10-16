using Microsoft.Playwright.NUnit;
using WUP.Pages;

namespace WUP.Tests
{

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class FieldTest:PageTest
    {
        LoginPage loginPage;
        FieldPage fieldPage;

        const string newNameAfterEdit = "Testowe paula po edycji";    
        const string nameField = "Testowe paula";
        const string nameFieldToAdd = "Testowe paula dodawanie";

        [SetUp]
        public async Task Setup()
        {
            loginPage = new LoginPage(Page);
            await loginPage.GoTo();
            await loginPage.SignIn();
            fieldPage = new FieldPage(Page);
            await fieldPage.GoTo();
            await fieldPage.AddField(nameField,"kwota");
            await fieldPage.GoTo();
        }

        [TearDown]
        public async Task Teardown()
        {
            await fieldPage.GoTo();
            await fieldPage.CleanUpField(nameField);
        }


        [TestCase("liczba")]
        [TestCase("liczba zmiennoprzecinkowa")]
        [TestCase("kwota")]
        [TestCase("procent")]
        public async Task AddFieldTest(string type)
        {
            await fieldPage.AddField(nameFieldToAdd, type);
            Assert.That(await fieldPage.IsAnnouncement("Pomyślnie dodano pole."), Is.True);
            
        }

        
        [Test]
        public async Task AddTheSameFieldTest()
        {
            await fieldPage.AddField(nameField, "liczba");
            Assert.Multiple(async () =>
            {
                Assert.That(await fieldPage.IsAnnouncement("Taka nazwa pola już istnieje"), Is.True);
                Assert.That(await fieldPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
            });
            await fieldPage.CloseFormAddField();
            await fieldPage.DeleteField(nameField);
        }

        [Test]
        public async Task AddEmptyFormTest()
        {
            //dodanie pola z pusta nazwa
            await fieldPage.AddField("","kwota");

            Assert.Multiple(async () =>
            {
                Assert.That(await fieldPage.IsAnnouncement("Brak nazwy pola"), Is.True);
                Assert.That(await fieldPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
            });
            await fieldPage.CloseFormAddField();

            //dodanie pola bez typu
            await fieldPage.AddFieldWithoutType(nameField);
            Assert.Multiple(async () =>
            {
                Assert.That(await fieldPage.IsAnnouncement("Brak typu pola"), Is.True);
                Assert.That(await fieldPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
            });
        }

        [TestCase("liczba")]
        [TestCase("liczba zmiennoprzecinkowa")]
        [TestCase("kwota")]
        [TestCase("procent")]
        public async Task EditFieldTest(string type)
        {
            await fieldPage.EditField(nameField, newNameAfterEdit, type);
            Assert.That(await fieldPage.IsAnnouncement("Pomyślnie zapisano pole."), Is.True);

        }

        //do naprawy
        [Test]
        public async Task EditTheSameNameTest()
        {

            await fieldPage.EditField(nameField, nameField, "procent");
            Assert.That(await fieldPage.IsAnnouncement("Pomyślnie zapisano pole."), Is.True);
        }

        [Test]
        public async Task DeleteFieldTest()
        {
            await fieldPage.DeleteField(nameField);
            Assert.That(await fieldPage.IsAnnouncement("Sukces!Pomyślnie usunięto pole."), Is.True);
        }

        [Test]
        public async Task CheckFieldPageUITest()
        {
            bool result = await fieldPage.CheckFieldPageUI();
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CheckAddFieldFormTest()
        {
            bool result = await fieldPage.CheckAddFormUI();
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CheckEditFieldFormTest()
        {
            bool result = await fieldPage.CheckEditFormUI(nameField);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public async Task CheckDeleteFieldPopUpTest()
        {
            bool result = await fieldPage.CheckDeletePopUp(nameField);
            Assert.That(result, Is.EqualTo(true));
        }


    }
}
