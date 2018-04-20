using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyCodeController : MonoBehaviour {
	public VerifyCodeUI ui;
	public GeneralPopupController popupControl;

	void Start(){
		ui.submit.onClick.AddListener (SendCode);
		ui.later.onClick.AddListener (Later);
	}

	public void SendCode(){
		NetworkAPI.VerifyUserResponse response = NetworkAPI.SendVerificationCode (UserInfo.GetUserId (), UserInfo.GetUserPassword (), ui.GetCode ());
		if (response.error.Length == 0) {
			UserInfo.SetVerified (true);
			if (SceneTransitions.LastScene () == SceneIndices.CREATE_ACCOUNT) {
				SceneTransitions.NextScene (SceneIndices.OPENING);
			} else {
				SceneTransitions.NextScene (SceneIndices.ENTRIES);
			}

		} else {
			popupControl = new GeneralPopupController (ui);
			popupControl.SetMessage ("Unable to verify");
			popupControl.Show ();
		}
	}

	public void Later(){
		UserInfo.SetVerified (false);
		SceneTransitions.NextScene (SceneIndices.ENTRIES);
	}


}
