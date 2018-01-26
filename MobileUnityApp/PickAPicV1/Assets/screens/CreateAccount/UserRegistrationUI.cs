using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserRegistrationUI : MainScreensUI {

	public InputField username;
	public InputField password;
	public InputField passwordConfirm;
	public InputField birthday;
	public InputField email;

	public UserRegistrationController controller;


	//todo need a variable and method relating to accepting the terms and conditions

	// Use this for initialization

	public string GetEmailAddress(){
		return email.text;
	}

	public string GetUsername(){
		return username.text;
	}

	public string GetPassword(){
		return password.text;
	}

	public string GetPasswordConfirmation(){
		return passwordConfirm.text;
	}

	//TODO wouldnt this field be designed to take in a specific format
	public string GetBirthday(){
		return birthday.text;
	}

	public void SubmitFormListener(){
		controller.SubmitFormPressed ();
	}
}
