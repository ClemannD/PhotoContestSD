using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserInfo {
	private static int userId;
	private static string userPassword;

	public static int GetUserId(){
		return userId;
	}

	public static void SetUserId(int id){
		userId = id;
	}

	public static void SetUserPassword(string password){
		userPassword = password;
	}

	public static string GetUserPassword(){
		return userPassword;
	}

}
