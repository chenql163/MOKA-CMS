using System;
using System.Linq;
using MokaCms.DataAccessFramework;

namespace MokaCms.Services
{
    /// <summary>
    /// This represents the account service entity.
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// Authenticate a user by username and password.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Returns <c>True</c>, if authenticated; otherwise returns <c>False</c>.</returns>
        public bool Authenticate(string username, string password)
        {
            var authenticated = false;

            using (var context = new MokaCmsDataContext())
            {
                var user = context.Users
                                  .SingleOrDefault(p => p.Username.ToLower() == username
                                                        && p.Password == password);
                if (user != null)
                    authenticated = true;
            }
            return authenticated;
        }

        /// <summary>
        /// Gets the user's role.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>Returns the user's role.</returns>
        public string GetUserRole(string username)
        {
            var result = String.Empty;

            using (var context = new MokaCmsDataContext())
            {
                var role = (from r in context.Roles
                            join ur in context.UserRoles
                                on r.RoleId equals ur.RoleId
                            join u in context.Users
                                on ur.UserId equals u.UserId
                            where u.Username.ToLower() == username
                            select r).SingleOrDefault();
                if (role != null)
                    result = role.RoleDescription;
            }
            return result;
        }
    }
}