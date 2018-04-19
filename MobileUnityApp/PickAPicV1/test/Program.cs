using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace test
{
	class MainClass
	{
		static string sha256(string stringToHash)
		{
			var crypt = new System.Security.Cryptography.SHA256Managed();
			var hash = new System.Text.StringBuilder();
			byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
			foreach (byte theByte in crypto)
			{
				hash.Append(theByte.ToString("x2"));
			}
			return hash.ToString();
		}
		
		public static void Main (string[] args)
		{
			
			string password = sha256("hello");
			//Debug.Log (password);

			Console.WriteLine (password);
		}
	}
}
