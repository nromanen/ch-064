using System.Linq;
using NUnit.Framework;
using OnlineExam.DatabaseHelper;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.Framework;
using OnlineExam.Framework.Params;
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

        private AdminTestParams adminTestParams;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            adminTestParams = ParametersResolver.Resolve<AdminTestParams>("AdminTestParams.json");
            header = ConstructPage<Header>();

            LogProgress("Go to log in page");
            logInPage = header.GoToLogInPage();

            LogProgress($"Log in as administrator: email {adminTestParams.AdminEmail}, password {adminTestParams.AdminPassword}");
            logInPage.SignIn(adminTestParams.AdminEmail, adminTestParams.AdminPassword);

            LogProgress("Go to admin panel page");
            adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
        }


        [Test]
        public void IsUserPresentedInUserListTest()
        {
            var isUserPresentedInUserList = adminPanelPage.IsUserPresentedInUserList(adminTestParams.StudentEmail);
            Assert.True(isUserPresentedInUserList, $"User {adminTestParams.StudentEmail} is not presented in user list");
        }

        [Test]
        public void DeleteUserTest()
        {
          
            LogProgress($"Check if user {adminTestParams.UserForDeleteEmail} is presented in user list before delete");
            var isUserPresentedInUserListBeforeDelete =
                adminPanelPage.IsUserPresentedInUserList(adminTestParams.UserForDeleteEmail);

            Assert.True(isUserPresentedInUserListBeforeDelete,
                $"User {adminTestParams.UserForDeleteEmail} is not presented in the system," +
                "so we have not opportunity to delete this user");

            LogProgress($"Delete user {adminTestParams.UserForDeleteEmail}");
            adminPanelPage.DeleteUser(adminTestParams.UserForDeleteEmail);

            LogProgress("Check if user list is available");
            var isListOfUsersH2ElementPresented = adminPanelPage.IsListOfUsersH2ElementPresented();
            Assert.True(isListOfUsersH2ElementPresented, "List of users is not available");


            LogProgress($"Check if user {adminTestParams.UserForDeleteEmail} is presented in user list after delete");
            var isUserPresentedInUserListAfterDelete =
                adminPanelPage.IsUserPresentedInUserList(adminTestParams.UserForDeleteEmail);
            Assert.False(isUserPresentedInUserListAfterDelete,
                $"User {adminTestParams.UserForDeleteEmail} was not deleted from the system");

            LogProgress($"Check if user {adminTestParams.UserForDeleteEmail} is presented in DB after delete");
            var userFromDB = new UserDAL().GetUserByEmail(adminTestParams.UserForDeleteEmail);
            Assert.IsNull(userFromDB, $"User {adminTestParams.UserForDeleteEmail} was not deleted from the system");
        }

        [Test]
        public void ChangeUserRoleTest()
        {
            
            LogProgress($"Go to change role of user page, user {adminTestParams.UserForChangeRoleEmail} ");
            var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(adminTestParams.UserForChangeRoleEmail);

            LogProgress($"Change user role to role {adminTestParams.TeacherRole}");
            changeRolePage.ChangeRole(adminTestParams.TeacherRole);
           
          
            LogProgress($"Go to change role of user page, user {adminTestParams.UserForChangeRoleEmail} ");
            changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(adminTestParams.UserForChangeRoleEmail);

            LogProgress("Check roles on UI");
            var currentRole = changeRolePage.CurrentRole();
            Assert.AreEqual(Constants.TEACHER, currentRole, "Role of user are not the same");

            LogProgress("Check roles in DB");
            var currentRoleDB = new UserDAL().GetRoleOfUserByEmail(adminTestParams.UserForChangeRoleEmail);
            CollectionAssert.Contains(adminTestParams.TeacherRole, currentRoleDB, "Role of user are not the same");
        }

        [Test]
        public void IsUserListAvailableTest()
        {
            var isUserListAvailable = adminPanelPage.IsListOfUsersH2ElementPresented();
            Assert.True(isUserListAvailable, "User list is not available");
        }
    }
}