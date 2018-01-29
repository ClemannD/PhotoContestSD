using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;


public class UserRegistrationController:MainScreensController{

	public UserRegistrationUI ui;


	void Start(){
		AddMainListeners (ui);
		ui.submitButton.onClick.AddListener (SubmitPressed);//need rali to make a submit button
	}


	public void SubmitPressed(){

		if (VerifyUsername() && VerifyPassword () && VerifyEmail ()  && VerifyBirthday() && ui.TermsAccepted()) {
			NetworkAPI.InsertUserResponse responseStruct = NetworkAPI.InsertNewUser (ui.GetUsername (), ui.GetFullName(),ui.GetEmailAddress (), ui.GetPassword (), ui.GetBirthday ());
			if (responseStruct.error.Length == 0) {
				MessageForUser.OutputMessage (responseStruct.error);
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


	//TODO
	private bool VerifyBirthday(){
		int bday;
		try {
			bday = Convert.ToInt32(ui.GetBirthday());
		} catch (Exception) {
			return false;
		}

		DateTime currTime = DateTime.Now;
		int difference = currTime.Year - bday;
		if (difference < 13) {
			return false;
		} else {
			return true;
		}
	}




}
