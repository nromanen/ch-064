using System.Linq;
using NUnit.Framework;
using OnlineExam.DatabaseHelper;
using OnlineExam.DatabaseHelper.DAL;
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

            LogProgress("Go to log in page");
            logInPage = header.GoToLogInPage();

            LogProgress($"Log in as administrator: email {Constants.ADMIN_EMAIL}, password {Constants.ADMIN_PASSWORD}");
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);

            LogProgress("Go to admin panel page");
            adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
        }


        [Test]
        public void IsUserPresentedInUserListTest()
        {
            var isUserPresentedInUserList = adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL);
            Assert.True(isUserPresentedInUserList, $"User {Constants.STUDENT_EMAIL} is not presented in user list");
        }

        [Test]
        public void DeleteUserTest()
        {
            LogProgress($"Check if user {Constants.USER_FOR_DELETE_EMAIL} is presented in user list before delete");
            var isUserPresentedInUserListBeforeDelete =
                adminPanelPage.IsUserPresentedInUserList(Constants.USER_FOR_DELETE_EMAIL);

            Assert.True(isUserPresentedInUserListBeforeDelete,
                $"User {Constants.USER_FOR_DELETE_EMAIL} is not presented in the system," +
                "so we have not opportunity to delete this user");

            LogProgress($"Delete user {Constants.USER_FOR_DELETE_EMAIL}");
            adminPanelPage.DeleteUser(Constants.USER_FOR_DELETE_EMAIL);

            LogProgress("Check if user list is available");
            var isListOfUsersH2ElementPresented = adminPanelPage.IsListOfUsersH2ElementPresented();
            Assert.True(isListOfUsersH2ElementPresented, "List of users is not available");

            LogProgress($"Check if user {Constants.USER_FOR_DELETE_EMAIL} is presented in user list after delete");
            var isUserPresentedInUserListAfterDelete =
                adminPanelPage.IsUserPresentedInUserList(Constants.USER_FOR_DELETE_EMAIL);
            Assert.False(isUserPresentedInUserListAfterDelete,
                $"User {Constants.USER_FOR_DELETE_EMAIL} was not deleted from the system");

            LogProgress($"Check if user {Constants.USER_FOR_DELETE_EMAIL} is presented in DB after delete");
            var userFromDB = new UserDAL().GetUserByEmail(Constants.USER_FOR_DELETE_EMAIL);
            Assert.IsNull(userFromDB, $"User {Constants.USER_FOR_DELETE_EMAIL} was not deleted from the system");
        }

        [Test]
        public void ChangeUserRoleTest()
        {
            LogProgress($"Go to change role of user page, user {Constants.USER_FOR_CHANGE_ROLE_EMAIL} ");
            var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.USER_FOR_CHANGE_ROLE_EMAIL);

            LogProgress($"Change user role to role {Constants.TEACHER}");
            changeRolePage.ChangeRole(Constants.TEACHER);

            LogProgress($"Go to change role of user page, user {Constants.USER_FOR_CHANGE_ROLE_EMAIL} ");
            changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.USER_FOR_CHANGE_ROLE_EMAIL);

            LogProgress("Check roles on UI");
            var currentRole = changeRolePage.CurrentRole();
            Assert.AreEqual(Constants.TEACHER, currentRole, "Role of user are not the same");

            LogProgress("Check roles in DB");
            var currentRoleDB = new UserDAL().GetRoleOfUserByEmail(Constants.USER_FOR_CHANGE_ROLE_EMAIL);
            Assert.AreEqual(Constants.TEACHER,currentRoleDB);
        }

        [Test]
        public void IsUserListAvailableTest()
        {
            var isUserListAvailable = adminPanelPage.IsListOfUsersH2ElementPresented();
            Assert.True(isUserListAvailable, "User list is not available");
        }
    }
}