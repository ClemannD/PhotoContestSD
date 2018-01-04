using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserRegistrationUI : MonoBehaviour {

	public InputField username;
	public InputField password;
	public InputField passwordConfirm;
	public InputField birthday;

	// Use this for initialization
	void Start () {
		
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

	}
}
