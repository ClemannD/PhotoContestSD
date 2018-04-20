using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEmailUI : MainScreensUI, IUsesGeneralPopup {

	public Button submitChange;
	public InputField newEmail;
	public InputField password;
	public PopupValues popupValues;



	public string GetNewEmail(){
		return this.newEmail.text;
	}

	public string GetPassword(){
		return password.text;
	}

	public void ClearFields(){
		newEmail.text = "";
		password.text = "";
	}

	public PopupValues GetPopupValues(){
		return popupValues;
	}
}
