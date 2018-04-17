using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//
public class UserRegistrationUI : MainScreensUI {

	public InputField username;
	public InputField password;
	public InputField passwordConfirm;

	public InputField birthdayYears;
	public InputField birthdayMonth;
	public InputField birthdayDay;

	public InputField email;
	public Toggle acceptTerms;
	public Button submitButton;
	public InputField fullName;

	public SuccessPopupValues successPopup;
	public FailurePopupValues failurePopup;

	public void ShowSuccessPopup(bool b){
		successPopup.gameObject.SetActive (b);
	}



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
	public int GetBirthDay(){

		string dayString =  NullHelper.SafeInputStringReturn (birthdayDay);
		if (dayString.Length == 2 && dayString [0] == '0') {
			dayString = "" + dayString [1];
		}

		int day = 0;
		try {
			day = Convert.ToInt32(dayString);
		} catch (Exception) {
		}

		return day;

	}

	public int GetBirthMonth(){
		string monthString = NullHelper.SafeInputStringReturn (birthdayMonth);
		if (monthString.Length == 2 && monthString [0] == '0') {
			monthString = "" + monthString [1];
		}

		int month = 0;
		try {
			month = Convert.ToInt32(monthString);
		} catch (Exception) {
		}

		return month;
	}

	public int GetBirthYear(){
		int year = 0;
		try {
			year = Convert.ToInt32(birthdayYears);
		} catch (Exception) {
			
		}

		return year;
	}

}
