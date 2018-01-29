using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UserRegistrationUI : MainScreensUI {

	public InputField username;
	public InputField password;
	public InputField passwordConfirm;
	public InputField birthday;
	public InputField email;
	public Toggle acceptTerms;
	public Button submitButton;
	public InputField fullName;



	public string GetEmailAddress(){
		return NullHelper.SafeInputStringReturn (email);
	}

	public string GetFullName(){
		return NullHelper.SafeInputStringReturn (fullName);
	}

	public bool TermsAccepted(){
		return acceptTerms.isOn;
	}

	public string GetUsername(){
		return NullHelper.SafeInputStringReturn (username);
	}

	public string GetPassword(){
		return NullHelper.SafeInputStringReturn (password);
	}

	public string GetPasswordConfirmation(){
		return NullHelper.SafeInputStringReturn (passwordConfirm);
	}

	//TODO wouldnt this field be designed to take in a specific format
	public string GetBirthday(){
		return  NullHelper.SafeInputStringReturn(birthday);
	}

}
