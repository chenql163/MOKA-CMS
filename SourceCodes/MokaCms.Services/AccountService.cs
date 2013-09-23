using System;
using System.Collections.Generic;
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

            var doc = XDocument.Load(@"C:\Users\moka\Documents\Visual Studio 2012\Projects\MOKA-CMS\Documents\XML Files\Users-justin.xml");

		    if (doc.Root == null)
		        throw new Exception("Invalid XML");
		        //return false;

            // xml 파일 로드하는 또 다른 방법
		    //var xml = new XmlDocument();
            //xml.Load(@"C:\Users\moka\Documents\Visual Studio 2012\Projects\MOKA-CMS\Documents\XML Files\Users-justin.xml");

            var user =
		        doc.Root.Elements("User")
		            .SingleOrDefault(
		                p =>
		                    p.Element("Username").Value.ToLower() == username.ToLower() &&
		                    p.Element("Password").Value == password);
            // Root는 Users라는 루트 엘리먼트를 말함. 
            // Elements 는 User 들을 말함

		    if (user != null)
		        authenticated = true;

            
			// var authenticated = username == "robin" && password == "robin";

			return authenticated;
		}
	}
}
