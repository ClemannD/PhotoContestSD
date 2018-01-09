using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour {

	private LoginScreenUI ui;


	NetworkAPI.LoginUserResponse loginResponse;

	public LoginController(LoginScreenUI ui){
		this.ui = ui;
	}

	//for when the user hits the login button
	public void LoginPressed(){
		loginResponse = NetworkAPI.DoUserLogin (ui.GetUsername(),ui.GetPassword());

		if (loginResponse.error.Length > 0) {
			Debug.Log (loginResponse.error);//maybe have a class with the error codes???
			//tell the user something is wrong
		} else {
			UserInfo.userId = loginResponse.id;

			SceneTransitions.NextScene (SceneIndices.ENTRIES);
		}


	}



}
