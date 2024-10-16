using WUP.Pages;
using Microsoft.Playwright.NUnit;

namespace WUP.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TagTest:PageTest
    {
        LoginPage loginPage;
        TagPage tagPage;
        const string nameTag = "Testowy paula tag";

        [SetUp]
        public async Task Setup()
        {
            loginPage = new LoginPage(Page);
            await loginPage.GoTo();
            await loginPage.SignIn();
            tagPage = new TagPage(Page);
            await tagPage.GoTo();
            await tagPage.AddTag(nameTag);
            await tagPage.GoTo();
        }

        [TearDown]
        public async Task Teardown()
        {
            await tagPage.GoTo();
            await tagPage.CleanUpTag("Testowy paula");
        }

        [Test]
        public async Task AddTagTest()
        {
            await tagPage.AddTag("Testowy paula tag dodawanie");
            Assert.That(await tagPage.IsAnnouncement("Pomyślnie dodano tag."), Is.True);
        }

        [Test]
        public async Task AddTheSameTagTest()
        {
            await tagPage.AddTag(nameTag);
            Assert.That(await tagPage.IsAnnouncement("Tag nie może zostać utworzony ponieważ już istnieje"), Is.True);
        }


        [Test]
        public async Task AddEmptyTagTest()
        {
            await tagPage.AddTag("");
            Assert.Multiple(async () =>
            {
                Assert.That(await tagPage.IsAnnouncement("Nazwa tagu nie może być pusta"), Is.True);
                Assert.That(await tagPage.IsAnnouncement("Formularz został nieprawidłowo wypełniony."), Is.True);
            });
        }

        [Test]
        public async Task EditTagTest()
        {
            await tagPage.EditTag(nameTag,"Testowy paula tag po edycji");
            Assert.That(await tagPage.IsAnnouncement("Pomyślnie edytowano tag."), Is.True);
        }

        [Test]
        public async Task EditTheSameTagTest()
        {
            await tagPage.EditTag(nameTag, nameTag);
            Assert.That(await tagPage.IsAnnouncement("Tag nie może zostać utworzony ponieważ już istnieje"), Is.True);
        }

        [Test]
        public async Task DeleteTagTest()
        {
            await tagPage.DeleteTag(nameTag);
            Assert.That(await tagPage.IsAnnouncement("Sukces!Pomyślnie usunięto tag."), Is.True);
        }

        [Test]
        public async Task CheckTagPageTestUI()
        {
            Assert.That(await tagPage.CheckTagPageUI(), Is.True);
        }

        [Test]
        public async Task CheckAddTagFormTestUI()
        {
            Assert.That(await tagPage.CheckAddTagFormUI(), Is.EqualTo(true));
        }

        [Test]
        public async Task CheckEditTagFormTestUI()
        {
            Assert.That(await tagPage.CheckEditTagFormUI(nameTag), Is.EqualTo(true));
        }

        [Test]
        public async Task CheckDeleteTagPopUpTestUI()
        {
            Assert.That(await tagPage.CheckDeletePopUp(nameTag), Is.EqualTo(true));
        }


    }
}
