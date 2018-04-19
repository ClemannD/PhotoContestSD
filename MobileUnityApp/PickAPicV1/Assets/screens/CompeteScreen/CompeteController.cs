using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;//todo

public class CompeteController : MainScreensController {
	public CompeteUI ui; 
	private UploadImage imageToUpload;
	private CapturedImage capturedImageToUpload;
	private int contestId;

	void Start(){
		//NetworkAPI.RetrieveCurrentContestsResponse info = NetworkAPI.GetCurrentContestInfo ();
		ContestInfo.SetCurrentWeekData();
		contestId = ContestInfo.GetContestID();
		ui.SetThemeText ("This Week's Theme: " + ContestInfo.GetWeekTheme());
		AddListeners (ui);
		ui.saveButton.onClick.AddListener (SavePressed);
		ui.uploadSelectButton.onClick.AddListener (UploadSelectPressed);
	
		if (SelectedImageStorage.selectedImageIsReady) {
			capturedImageToUpload = null;
			imageToUpload = SelectedImageStorage.selectedImage;
			ui.SetUploadImage (imageToUpload.texture);
			SelectedImageStorage.selectedImage = null;
			SelectedImageStorage.selectedImageIsReady = false;
		}
		ui.useCamera.onClick.AddListener (OpenCamera);


	}

	public void OpenCamera(){
		WebCamDevice[] stuff = WebCamTexture.devices;
	
		ui.cam.OpenCam (stuff [0].name, stuff [1].name);
	}


		

	private void RefreshGUI(){

	}

	public void SetPicFromCamera(Texture2D pic){
		imageToUpload = null;
		capturedImageToUpload = new CapturedImage (UserInfo.GetUserId (),UserInfo.GetUsername(), contestId,pic);
		ui.SetUploadImage (capturedImageToUpload.texture);
	}

	private void SavePressed(){
		string description = ui.GetDescription ().Trim ();
		if (description.Length == 0) {
			description = "_";
		}
		if (imageToUpload != null) {
			imageToUpload.description = description;
			NetworkAPI.UploadEntryCoroutine (imageToUpload, this);
			ui.RemoveUploadImage();
			imageToUpload = null;

		} else if (capturedImageToUpload != null) {
			capturedImageToUpload.SetDescription (description);
			NetworkAPI.UploadCapturedEntry (capturedImageToUpload, this);
			ui.RemoveUploadImage();
			capturedImageToUpload = null;
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
