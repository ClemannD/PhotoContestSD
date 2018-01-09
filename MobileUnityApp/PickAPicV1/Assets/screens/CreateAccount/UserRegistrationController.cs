using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class UserRegistrationController : MonoBehaviour {

	private UserRegistrationUI ui;
	private NetworkAPI.InsertUserResponse apiResponse;

	public UserRegistrationController(UserRegistrationUI ui){
		this.ui = ui;
	}

	public void SubmitFormPressed(){
		//todo send information
		string username = ui.GetUsername();
		string password = ui.GetPassword ();
		string confirmPassword = ui.GetPasswordConfirmation ();
		string email = ui.GetEmailAddress ();
		string bday = ui.GetBirthday ();

		if (VerifyUsername (username) && VerifyPassword (password, confirmPassword) && VerifyEmail (email) /* TODO && VerifyBirthday(bday) */) {
			// TODO apiResponse = NetworkAPI.doUserInsert
			SceneTransitions.NextScene (SceneIndices.SPLASH);
		} else {
			//TODO message the person that something went wrong
		}
			
	}

	private bool VerifyUsername(string name){
		if (name.Length >= 6 && name.Length <= 20) {
			return true;
		} else {
			return false;
		}
		//TODO the allowed characters seem too restrictive, see page 77
	}

	private bool VerifyPassword(string password, string confirmpassword){
		if (password != confirmpassword) {
			return false;
		}

		if (password.Length >= 6 && password.Length <= 16) {
			return true;
		} else {
			return false;
		}
		//TODO again the allowed characters seem too restrictive
	}

	private bool VerifyEmail(string email){
		if (email.Length > 40) {
			return false;
		}

		Regex reg = new Regex ("*@*.*");

		bool properFormat = reg.IsMatch (email);
		bool realEmail = false;
		//TODO verify this email is real

		if (properFormat && realEmail) {
			return true;
		} else {
			return false;
		}
	}
	//TODO
	//private bool VerifyBirthday(){
		
	//}
}
