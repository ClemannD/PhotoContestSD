using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour {

	public LoginScreenUI ui;

	void Start(){
		ui.loginButton.onClick.AddListener (LoginPressed);
		ui.signUpButton.onClick.AddListener (SignUpPressed);
	}

	//for when the user hits the login button
	public void LoginPressed(){
		NetworkAPI.LoginUserResponse loginResponse = NetworkAPI.DoUserLogin (ui.GetUsername(),ui.GetPassword());

		if (loginResponse.error.Length > 0) {
			Debug.Log (loginResponse.error);
			//tell the user something is wrong
		} else {
			UserInfo.userId = loginResponse.id;

			SceneTransitions.NextScene (SceneIndices.ENTRIES);
		}
	}

	public void SignUpPressed(){
		SceneTransitions.NextScene (SceneIndices.CREATE_ACCOUNT);
	}



}
