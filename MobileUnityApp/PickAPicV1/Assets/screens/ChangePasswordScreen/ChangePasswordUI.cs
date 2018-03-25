using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePasswordUI : MainScreensUI {
	public InputField currentPassword;
	public InputField newPassword;
	public InputField confirmNewPassword;
	public Button submitButton;

	public string getCurrentPassword(){
		return currentPassword.text;
	}

	public string getNewPassword(){
		return newPassword.text;
	}

	public string getConfirmNewPassword(){
		return confirmNewPassword.text;
	}
}
