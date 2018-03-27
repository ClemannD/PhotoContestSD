using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePasswordController:MainScreensController{
	public ChangePasswordUI ui;

	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.submitButton.onClick.AddListener (SubmitListener);
	}

	public void SubmitListener(){
		bool valid = VerificationTools.VerifyPassword (ui.getNewPassword (), ui.getConfirmNewPassword ());
		if (valid) {
			string error = NetworkAPI.NewPassword ("" + UserInfo.GetUserId (), ui.getCurrentPassword (), ui.getNewPassword ()).error;
			if (error.Length == 0) {
				SceneTransitions.NextScene (SceneIndices.ENTRIES);
			} else {
				//TODO error message
			}

		} else {
			//TODO show pop up or toast saying mistake
		}
	}


}
