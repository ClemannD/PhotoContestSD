using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour {
	//
	//
	public LoginScreenUI ui;

	void Start(){
		ui.loginButton.onClick.AddListener (LoginPressed);
		ui.signUpButton.onClick.AddListener (SignUpPressed);


	}

	//for when the user hits the login button
	public void LoginPressed(){
		ContestInfo.SetCurrentWeekData ();
		Debug.Log (ContestInfo.GetContestID());

		NetworkAPI.LoginUserResponse loginResponse = new NetworkAPI.LoginUserResponse ();
		string password = ui.GetPassword ();
		loginResponse = NetworkAPI.DoUserLogin (ui.GetUsername(),password);

		if (loginResponse.error.Length > 0) {
			MessageForUser.OutputMessage(loginResponse.error);
			//tell the user something is wrong
		} else {
			UserInfo.SetUserId (loginResponse.id);
			UserInfo.SetUserPassword (password);
			SceneTransitions.NextScene (SceneIndices.ENTRIES);
		}
	}

	public void SignUpPressed(){
		SceneTransitions.NextScene (SceneIndices.CREATE_ACCOUNT);
	}



}
