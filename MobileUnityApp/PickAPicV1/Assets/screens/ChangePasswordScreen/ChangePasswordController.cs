using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePasswordController:MainScreensController{
	public ChangePasswordUI ui;
	private GeneralPopupController popupControl;

	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.submitButton.onClick.AddListener (SubmitListener);
	}

	public void SubmitListener(){
		bool valid = VerificationTools.VerifyPassword (ui.getNewPassword (), ui.getConfirmNewPassword ());
		if (valid) {
			string error = NetworkAPI.NewPassword ("" + UserInfo.GetUserId (), Hashing.sha256(ui.getCurrentPassword ()), Hashing.sha256(ui.getNewPassword ())).error;
			if (error.Length == 0) {
				popupControl = new GeneralPopupController (ui);
				popupControl.SetMessage ("password changed");
				popupControl.Show ();
			} else {
				popupControl = new GeneralPopupController (ui);
				popupControl.SetMessage ("Unable to change password");
				popupControl.Show ();
			}


		} else {
			popupControl = new GeneralPopupController (ui);
			popupControl.SetMessage ("Unable to change password. Check that passwords match. \n Passwords should be between 6 and 16 characters.");
			popupControl.Show ();
		}
	}




}
