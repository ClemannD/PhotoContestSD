using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserInfo {//TODO remove these later
	private static int userId = 5;
	private static string userPassword = "donothackplz!!";
	private static string username = "commander_clutch";

	private static bool verified;


	public static void SetVerified(bool isVerified){
		verified = isVerified;
	}

	public static bool IsVerified(){
		return verified;
	}

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

	public static void SetUsername(string name){
		username = name;
	}

	public static string GetUsername(){
		return username;
	}

	public static void ClearUserData(){
		userId = int.MinValue;
		userPassword = "";
		username = "";
	}

}
