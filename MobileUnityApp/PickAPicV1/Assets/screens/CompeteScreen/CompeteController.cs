using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CompeteController : MainScreensController {
	public CompeteUI ui; 
	public UploadImage imageToUpload;

	void Start(){
		AddListeners (ui);
		ui.saveButton.onClick.AddListener (SavePressed);
		ui.uploadSelectButton.onClick.AddListener (UploadSelectPressed);
	
		if (SelectedImageStorage.selectedImageIsReady) {
			imageToUpload = SelectedImageStorage.selectedImage;
			ui.SetUploadImage (imageToUpload.texture);
		}

		ContestInfo.SetCurrentWeekData ();
		ui.SetThemeText ("This Week's Theme: " + ContestInfo.GetWeekTheme());
	}



		

	private void RefreshGUI(){

	}

	private void SavePressed(){
		if (imageToUpload != null) {
			imageToUpload.description = ui.GetDescription ();
			NetworkAPI.UploadEntryCoroutine (imageToUpload, this);
			ui.SetUploadImage (null);
			imageToUpload = null;
		}

	}




	private void UploadSelectPressed(){
		Debug.Log ("the upload button was pressed");
		SceneTransitions.NextScene (SceneIndices.FILE_SELECTION);
	}



	public override void CompetePressed ()
	{
		RefreshGUI ();
	}



}
