using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreenUI : MonoBehaviour, IUsesGeneralPopup {
	public Button loginButton;
	public InputField username;
	public InputField password;
	public Button signUpButton;
	public PopupValues values;

	void Start(){


	}


	public string GetUsername(){
		return username.text;
	}

	public string GetPassword(){
		return password.text;
	}


	public PopupValues GetPopupValues(){
		return values;
	}


}
