using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUI : MainScreensUI,IUsesGeneralPopup {
	public Button changePasswordButton;
	public Button myPicturesButton;
	public Button deleteProfileButton;
	public Button changeEmailButton;

	public DeleteProfilePopupValues deletePopupValues;
	public PopupValues generalPopupValues;

	// Use this for initialization
	void Start () {
		
	}


	public void ShowDeletePopup(bool b){
		deletePopupValues.gameObject.SetActive (b);
	}

	public PopupValues GetPopupValues(){
		return generalPopupValues;
	}


}
