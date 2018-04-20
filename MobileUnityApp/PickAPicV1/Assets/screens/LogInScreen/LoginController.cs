using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class LoginController : MonoBehaviour {
	//
	//
	public LoginScreenUI ui;
	public GeneralPopupController popupControl;

	void Start(){
		ui.loginButton.onClick.AddListener (LoginPressed);
		ui.signUpButton.onClick.AddListener (SignUpPressed);


	}

	static string sha256(string stringToHash)
	{
		var crypt = new System.Security.Cryptography.SHA256Managed();
		var hash = new System.Text.StringBuilder();
		byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
		foreach (byte theByte in crypto)
		{
			hash.Append(theByte.ToString("x2"));
		}
		return hash.ToString();
	}

	//for when the user hits the login button
	public void LoginPressed(){
		
		//Debug.Log (ContestInfo.GetContestID());

		NetworkAPI.LoginUserResponse loginResponse = new NetworkAPI.LoginUserResponse ();
		string password = sha256(ui.GetPassword());
		string username = ui.GetUsername ();
		loginResponse = NetworkAPI.DoUserLogin (ui.GetUsername(),password);


		if (loginResponse.error.Length > 0 || (loginResponse.isBanned == 1)) {
			string message = loginResponse.error;
			if (loginResponse.isBanned == 1) {
				message = "You have been banned and may not login at this time";
			}
			popupControl = new GeneralPopupController (ui);
			popupControl.SetMessage (message);
			popupControl.Show ();
			//MessageForUser.OutputMessage(loginResponse.error);
			//tell the user something is wrong TODO
		} 
		else {
			UserInfo.SetUserId (loginResponse.id);
			UserInfo.SetUserPassword (password);
			UserInfo.SetUsername (username);
			ContestInfo.SetCurrentWeekData ();
			if (loginResponse.id == 1) {
				SceneTransitions.NextScene (SceneIndices.ENTRIES);
			} else {
				SceneTransitions.NextScene (SceneIndices.VERIFY);
			}

		}
	}

	public void SignUpPressed(){
		SceneTransitions.NextScene (SceneIndices.CREATE_ACCOUNT);
	}



}
