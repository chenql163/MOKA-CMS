using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
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
		    var doc = XDocument.Load(@"C:\Users\moka\Documents\Visual Studio 2012\Projects\MOKA-CMS\Documents\XML files\Users-SeokminKang.xml");
		    
            if (doc.Root == null)
		        return false;

                //throw new Exception("Invalid XML");
		    
            /*
            var xml = new XmlDocument();
            xml.Load(@"C:\Users\moka\Documents\Visual Studio 2012\Projects\MOKA-CMS\Documents\XML files\Users-SeokminKang.xml");
            */

            var user =
		        doc.Root
		            .Elements("User")
		            .SingleOrDefault(p =>
		                p.Element("ID").Value.ToLower() == username.ToLower() &&
		                p.Element("PWD").Value == password);

		    if (user != null)
                authenticated = true;

		    //    doSomething();
		    //else 
            //    doElse();
			//var authenticated = username == "robin" && password == "robin";

            return authenticated;
		}
	}
}
