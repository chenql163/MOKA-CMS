using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
			var doc = XDocument.Load(@"C:\Users\Bongmin\Documents\Visual Studio 2012\Projects\MOKA-CMS\Documents\XML Files\Users-justin.xml");
		    if (doc.Root == null)
		        return false;
            else if (doc.Root.Elements("User").Elements("Username") == null &&
                     doc.Root.Elements("User").Elements("Password") == null)
            {
                return false;
            }
		    var xml = new XmlDocument();
            xml.Load(@"C:\Users\Bongmin\Documents\Visual Studio 2012\Projects\MOKA-CMS\Documents\XML Files\Users-justin.xml");
            
            var user = doc.Root.Elements("User")
				.FirstOrDefault(p => p.Element("Username").Value.ToLower() == username.ToLower() && p.Element("Password").Value == password);
			//람다펑션^
			
            if (user != null)
			{
				authenticated = true;
			}
			
			return authenticated;
		}
	}
}
