using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [Category("Basic")]
    [TestFixture]
    public class AdminNTest : BaseNTest
    {
        private Header header;
        private LogInPage logInPage;
        private AdminPanelPage adminPanelPage;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
        }


        [Test]
        public void IsUserPresentedInUserListTest()
        {
            var isUserPresentedInUserList = adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL);
            Assert.True(isUserPresentedInUserList,$"User {Constants.STUDENT_EMAIL} is not presented in user list");
        }

        [Test]
        public void DeleteUserTest()
        {
            var isUserPresentedInUserList = adminPanelPage.IsUserPresentedInUserList(Constants.USER_FOR_DELETE_EMAIL);
            Assert.True(isUserPresentedInUserList,
                $"User {Constants.USER_FOR_DELETE_EMAIL} is not presented in the system," +
                "so we have not opportunity to delete this user");
            adminPanelPage.DeleteUser(Constants.USER_FOR_DELETE_EMAIL);
            var isListOfUsersH2ElementPresented = adminPanelPage.IsListOfUsersH2ElementPresented();
            Assert.True(isListOfUsersH2ElementPresented, "List of users is not available");
            Assert.False(adminPanelPage.IsUserPresentedInUserList(Constants.USER_FOR_DELETE_EMAIL), $"Can't delete user {Constants.USER_FOR_DELETE_EMAIL} from the system");
        }

        [Test]
        public void ChangeUserRoleTest()
        {
            var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.USER_FOR_CHANGE_ROLE_EMAIL);
            changeRolePage.ChangeRole(Constants.TEACHER);
            changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.USER_FOR_CHANGE_ROLE_EMAIL);
            var currentRole = changeRolePage.CurrentRole();
            Assert.AreEqual(Constants.TEACHER, currentRole ,"Role of user are not the same");
        }

        [Test]
        public void IsUserListAvailableTest()
        {
            var isUserListAvailable = adminPanelPage.IsListOfUsersH2ElementPresented();
            Assert.True(isUserListAvailable,"User list is not available");
        }
    }
}