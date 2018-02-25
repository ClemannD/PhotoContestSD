using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminController:AdminScreensController{
	public AdminUI ui;
	// Use this for initialization
	void Start () {
		//AddMainListeners (ui);
		ui.newThemeButton.onClick.AddListener (NewThemeListener);
		ui.banUserButton.onClick.AddListener (BanUsersListener);
		ui.reviewReportedPhotosButton.onClick.AddListener (ReviewReportedPhotosListener);
		ui.monetizeButton.onClick.AddListener (MonetizeListener);
	}

	public void NewThemeListener(){
		SceneTransitions.NextScene (SceneIndices.NEW_THEME);
	}

	public void BanUsersListener(){
		SceneTransitions.NextScene (SceneIndices.BAN_USERS);
	}

	public void ReviewReportedPhotosListener(){
		SceneTransitions.NextScene (SceneIndices.REVIEW_PHOTOS);
	}

	public void MonetizeListener(){
		//TODO
	}
	

}
