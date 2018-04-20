using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePasswordUI : MainScreensUI,IUsesGeneralPopup {
	public InputField currentPassword;
	public InputField newPassword;
	public InputField confirmNewPassword;
	public Button submitButton;
	public PopupValues popupValues;

	public string getCurrentPassword(){
		return currentPassword.text;
	}

	public string getNewPassword(){
		return newPassword.text;
	}

	public string getConfirmNewPassword(){
		return confirmNewPassword.text;
	}

	public PopupValues GetPopupValues(){
		return popupValues;
	}

	public void ClearScreen(){
		currentPassword.text = "";
		newPassword.text = "";
		confirmNewPassword.text = "";
	}
}
