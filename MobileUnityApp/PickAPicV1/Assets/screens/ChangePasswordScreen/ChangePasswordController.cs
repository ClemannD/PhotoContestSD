using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePasswordController:NormalUserScreensController{
	public ChangePasswordUI ui;

	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.submitButton.onClick.AddListener (SubmitListener);
	}

	public void SubmitListener(){
		bool valid = VerificationTools.VerifyPassword (ui.getNewPassword (), ui.getConfirmNewPassword ());
		if (valid) {
			//api call here
			SceneTransitions.NextScene(SceneIndices.ENTRIES);
		}
	}


}
