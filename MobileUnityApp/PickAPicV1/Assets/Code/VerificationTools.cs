using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificationTools {

	public static bool VerifyPassword(string password, string confirmPassword){
		if (password != confirmPassword) {
			return false;
		}

		if (password.Length >= 6 && password.Length <= 16) {
			return true;
		} else {
			return false;
		}
	}
}
