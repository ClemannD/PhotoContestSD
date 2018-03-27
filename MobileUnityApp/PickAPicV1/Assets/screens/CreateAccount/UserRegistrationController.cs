﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;


public class UserRegistrationController:MainScreensController{

	public UserRegistrationUI ui;


	void Start(){
		AddListeners (ui);
		ui.submitButton.onClick.AddListener (SubmitPressed);//need rali to make a submit button
	}


	public void SubmitPressed(){
		ContestInfo.SetCurrentWeekData ();
		if (VerifyUsername() && VerifyPassword () && VerifyEmail ()  && VerifyBirthday() && ui.TermsAccepted()) {
			NetworkAPI.InsertUserResponse responseStruct = NetworkAPI.InsertNewUser (ui.GetUsername (), ui.GetFullName(),ui.GetEmailAddress (), ui.GetPassword (), BirthdayStringForm());
			if (responseStruct.error.Length == 0) {
				MessageForUser.OutputMessage (responseStruct.error);
				UserInfo.SetUserId (responseStruct.id);
				UserInfo.SetUserPassword (ui.GetPassword ());
				SceneTransitions.NextScene (SceneIndices.ENTRIES);
			} else {
				MessageForUser.OutputMessage (responseStruct.error);
			}
		} else {
			
			string message = "One or more fields do not meet requirements";
			if (!VerifyPassword()) {
				message+= "Password and/or Password confirm field does not meet requirements";
			}

			if (!VerifyUsername()) {
				message += "\nusername does not meet requirements. Must be bla bla bla";
			}

			if (!VerifyEmail()) {
				message += "\n Invalid email address.";
			}

			if (!VerifyBirthday ()) {
				message += "\n You may not user pick a pic. All users must be age 13 or above.";
			}

			MessageForUser.OutputMessage (message);

		}
			
	}

	private bool VerifyUsername(){
		string name = ui.GetUsername();
		if (name.Length >= 6 && name.Length <= 20) {
			return true;
		} else {
			return false;
		}
		//TODO the allowed characters seem too restrictive, see page 77
	}

	private bool VerifyPassword(){
		string password = ui.GetPassword ();
		string confirmPassword = ui.GetPasswordConfirmation ();


		if (password != confirmPassword) {
			return false;
		}

		if (password.Length >= 6 && password.Length <= 16) {
			return true;
		} else {
			return false;
		}
		//TODO again the allowed characters seem too restrictive
	}

	//TODO really need help here
	private bool VerifyEmail(){
		string email = ui.GetEmailAddress ();

		if (email.Length > 40) {
			return false;
		}
		email = email.ToLower ();//TODO fix Regex
		Regex reg = new Regex ("[a-z]+[0-9]*@[a-z]+.[a-z]+");

		bool properFormat = reg.IsMatch (email);
		bool realEmail = true;//todo change later
		//TODO verify this email is real

		if (properFormat && realEmail) {
			return true;
		} else {
			return false;
		}
	}
		
	private bool VerifyBirthday(){
		int day = ui.GetBirthDay ();
		int month = ui.GetBirthMonth ();
		int year = ui.GetBirthYear ();

		if (month < 1 || month > 12) {
			return false;
		}

		if (year > DateTime.Now.Year) {
			return false;
		}

		int[] months31Array = {1,3,5,7,8,10,12};
		List<Int32> months31 = new List<Int32>();
		for (int m = 0; m < months31Array.Length; m++) {
			months31.Add (months31Array [m]);
		}
		
		if (months31.Contains (month)) {
			if (day < 1 || day > 31) {
				return false;
			}
		}



		int[] months30Array= { 4, 6, 9, 11 };
		List<Int32> months30 = new List<Int32>();
		for (int i = 0; i < months30Array.Length; i++) {
			months30.Add (months30Array [i]);
		}
		if (months30.Contains (month)) {
			if (day < 1 || day > 30) {
				return false;
			}
		}

		if (month == 2) {
			if (DateTime.IsLeapYear (year)) {
				if (day < 1 || day > 29) {
					return false;
				}
			} else {
				if (day < 1 || day > 28) {
					return false;
				}
			}

		}


	


		Birthday bday = new Birthday (day,month,year);

		return bday.OlderThan (13);
	}

	private string BirthdayStringForm(){
		return ui.GetBirthMonth()+ "/" + ui.GetBirthDay() + "/" + ui.GetBirthYear();
	}




}
