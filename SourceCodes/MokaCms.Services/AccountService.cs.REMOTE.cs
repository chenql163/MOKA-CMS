using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			var authenticated = username == "robin" && password == "robin";

			return authenticated;
		}
	}
}
