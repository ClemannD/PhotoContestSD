using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class Hashing{

	public static string sha256(string stringToHash)
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
}
