using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EditImageController : MonoBehaviour {

	public EditImageUI ui;
	public UploadImage uploadImage;

	// Use this for initialization
	void Start () {
		//add listeners
		ui.confirmButton.onClick.AddListener(ConfirmClicked);
		this.uploadImage = SelectedImageStorage.selectedImage;
		ui.SetChosenPic (uploadImage.texture);




	}


	public void ConfirmClicked(){
		uploadImage.SetDescription (ui.GetDescription ());
		SelectedImageStorage.selectedImageIsReady = true;
		SceneTransitions.NextScene (SceneIndices.COMPETE);//needs to send image, or something ....




	}


	//TOMORROW: UI. Proper back and forth with scenes. keep file structure scene when you go to image edit scene
	//do methods to upload
	//make sure it goes back to compete screen
	//make sure upload button does something in compete screen

	public void CancelClicked(){
		//TOOD
	}
	
	
}
