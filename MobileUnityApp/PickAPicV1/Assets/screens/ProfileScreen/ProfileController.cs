using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileController : MainScreensController {
	public ProfileUI ui;

	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.changePasswordButton.onClick.AddListener (ChangePasswordListener);
		ui.myPicturesButton.onClick.AddListener (MyPicturesListener);
		ui.deleteProfileButton.onClick.AddListener (DeleteProfileListener);
	}

	public void ChangePasswordListener(){
		SceneTransitions.NextScene (SceneIndices.CHANGE_PASSWORD);
	}

	public void MyPicturesListener(){
		SceneTransitions.NextScene (SceneIndices.MY_PICTURES);

	}

	public void DeleteProfileListener(){
		SceneTransitions.NextScene (-1);

	}

}
