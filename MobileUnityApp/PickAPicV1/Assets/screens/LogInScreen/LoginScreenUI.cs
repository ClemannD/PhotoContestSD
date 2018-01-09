using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreenUI : MonoBehaviour {
	public InputField username;
	public InputField password;

	public void Start(){

	}

	/// <summary>
	/// Called when the login button is pressed. Calls the controller layer to take action
	/// </summary>
	public void LoginListener(){

	}

	public string GetUsername(){
		return username.text;
	}

	public string GetPassword(){
		return password.text;
	}





}
