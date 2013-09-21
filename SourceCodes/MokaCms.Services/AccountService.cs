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
			
		   
				
			//Root means Root element in XMl file (eg. Users)
			//.element only load first element
			//.elements loads all elements
			// firstOrDefault means finding first element match the condition
			// "p" means an element loaded from .Elements
			// first vs firstOrDefault vs single vs singleOrDefault vs last vs lastOrDefault
			// single = Must be 1
			// singleOrDefualt = can be 1 or 0


			//// Way 1. easy to navigate node.
			//var xml = new XmlDocument();
			//xml.Load(@"C:\\Users\moka\Documents\Visual Studio 2012\MOKA\MOKA-CMS\Documents\XML Files\Users-justin.xml");



			// Way 2. use linq to load XML file
			var doc = XDocument.Load(@"C:\\Users\moka\Documents\Visual Studio 2012\MOKA\MOKA-CMS\Documents\XML Files\Users-justin.xml");

			// To remove blue underline on doc.Root 
			if (doc.Root == null)
				return false;
				//or
				//throw new Exception("Invalid XML");


			var user = 
				doc.Root
					.Elements("User")
						.FirstOrDefault(p => 
							p.Element("Username").Value == username.ToLower() && 
							p.Element("Password").Value == password);

			if (user != null)
				authenticated = true;
			
			

			//var authenticated = username == "robin" && password == "robin";

			return authenticated;
		}
	}
}
