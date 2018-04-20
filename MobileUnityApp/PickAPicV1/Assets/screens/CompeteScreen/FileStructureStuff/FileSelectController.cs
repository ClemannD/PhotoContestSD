﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileSelectController : MainScreensController {
	public FileSelectUI ui;
	private MobileFileStructure fileStructure;
	private int contestId;


	void Start(){
		//ui.SetTheme ("" + Directory.Exists("/sdcard/DCIM"));
		AddListeners (ui);
		/*string startPath = "";
		if (DeviceInfo.thisDeviceOS == DeviceInfo.ANDROID) {
			startPath = "/sdcard/data/DCIM";   //sdcard/DCIM";
		} else {
			//TODO
			startPath = "C:\\PicsStuff";
		}
*/
		fileStructure = new MobileFileStructure (DeviceInfo.GetStartPath());
		contestId = ContestInfo.GetContestID ();

		Debug.Log ("the contest id may be " + contestId);
		ui.SetTheme (ContestInfo.GetWeekTheme ());





		Reset ();
	}

	//make coroutine????
	public void DisplayFiles(){
		
		string[] filesToShow = fileStructure.GetImageFilePaths ();
		//ui.prevFolder.GetComponent<Text> ().text = "yo " + filesToShow [0];
		//ui.SetTheme ("ha");
		int bla = 0;
		foreach (string filename in filesToShow) {
			Texture2D picTexture = ImageIO.MakeImageFromFile (filename);
			UploadImage potentialImage = new UploadImage (filename,UserInfo.GetUserId (),UserInfo.GetUsername(),contestId,picTexture,this);
			potentialImage.SetDescription ("?");
			ui.DisplayFile (potentialImage);
		}
	}



	public void DisplayFolders(){
		string[] foldersToShow = fileStructure.GetFolders ();
		//ui.prevFolder.GetComponent<Text> ().text = "yo " + foldersToShow [0];

		foreach (string folderpath in foldersToShow) {
			FolderIcon folder = new FolderIcon (folderpath,this);
			ui.DisplayFolder (folder);
		}
	}



	public void ImageClicked(UploadImage clickedImage){
		//Go to the screen that deals with this
		//TODO !!!!!!!!
		SelectedImageStorage.selectedImage = clickedImage;
		SelectedImageStorage.selectedImageIsReady = true;
		SceneTransitions.NextScene (SceneIndices.COMPETE);
	}

	public void FolderClicked(FolderIcon clickedFolder){
		//Debug.Log ("hello");
		fileStructure.EnterFolder (clickedFolder.folderPath);
		Reset ();
	}

	private void Reset(){
		ui.ClearScreen ();
		DisplayFolders ();
		DisplayFiles ();
	}

	public void PrevFolder(){
		fileStructure.GoBack ();
		Reset ();
	}
}
