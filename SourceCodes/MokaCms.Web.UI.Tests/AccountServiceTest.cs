using MokaCms.Services;
using NUnit.Framework;

namespace MokaCms.Web.UI.Tests
{
    [TestFixture]
    public class AccountServiceTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion SetUp / TearDown

        #region Tests

        [Test]
        [TestCase("robin", "robin", true)]
        [TestCase("patrick", "patrick", true)]
        [TestCase("hayley", "hayley", true)]
        [TestCase("harold", "hayley", false)]
        public void Login_GivenUsernamePassword_LoginConfirmed(string username, string password, bool result)
        {
            var account = new AccountService();
            var authenticated = account.Authenticate(username, password);

            Assert.AreEqual(result, authenticated);
        }

        [Test]
        [TestCase("robin", "guest", false)]
        [TestCase("patrick", "editor", true)]
        [TestCase("harold", "guest", true)]
        public void GetUserRole_GivenUsername_UserRoleReturned(string username, string role, bool expected)
        {
            var account = new AccountService();
            var result = account.GetUserRole(username);

            Assert.AreEqual(expected, role.ToLower() == result.ToLower());
        }

        #endregion Tests
    }
}