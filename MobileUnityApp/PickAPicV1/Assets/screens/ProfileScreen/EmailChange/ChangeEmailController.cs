using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEmailController : MainScreensController {
	public ChangeEmailUI ui;
	public GeneralPopupController generalPopupController;
	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.submitChange.onClick.AddListener (SubmitChange);
	}
	
	public void SubmitChange(){
		NetworkAPI.UpdateEmailResponse response = NetworkAPI.ChangeEmail ("" + UserInfo.GetUserId (), ui.GetPassword(), ui.GetNewEmail ());
		if (response.error.Length == 0) {
			generalPopupController = new GeneralPopupController (ui);
			generalPopupController.SetMessage ("Email Changed");
			generalPopupController.Show ();
		} else {
			generalPopupController = new GeneralPopupController (ui);
			generalPopupController.SetMessage (response.error);
			generalPopupController.Show ();
		}

		ui.ClearFields ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
