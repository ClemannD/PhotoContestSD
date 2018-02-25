using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileController : NormalUserScreensController {
	public ProfileUI ui;

	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.changePasswordButton.onClick.AddListener (ChangePasswordListener);
		ui.trophyButton.onClick.AddListener (TrophyCabinetListener);
		ui.removePictureButton.onClick.AddListener (RemovePictureListener);
	}

	public void ChangePasswordListener(){
		SceneTransitions.NextScene (SceneIndices.CHANGE_PASSWORD);
	}

	public void TrophyCabinetListener(){
		SceneTransitions.NextScene (SceneIndices.TROPHY_CABINET);

	}

	public void RemovePictureListener(){
		SceneTransitions.NextScene (SceneIndices.REMOVE_PICTURE);

	}

}
