using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileSelectUI : MainScreensUI {
	public GameObject contentFromScroll;
	public GameObject folderButtonPrefab;
	public GameObject picButtonPrefab;

	public Text themeText;

	public Button prevFolder;


	public void ClearScreen(){
		contentFromScroll.transform.DetachChildren ();
	}
		
	public void DisplayFile(UploadImage potentialUpload){
		GameObject picPrefab = GameObject.Instantiate (picButtonPrefab);
		ClickImagePrefabValues prefabValues = picPrefab.GetComponent<ClickImagePrefabValues> ();
		potentialUpload.AttatchToGUI (prefabValues);
		picPrefab.transform.SetParent (contentFromScroll.transform);
	}

	public void DisplayFolder(FolderIcon folder){
		GameObject folderPrefab = GameObject.Instantiate (folderButtonPrefab);
		EnterFolderPrefabValues prefabValues = folderPrefab.GetComponent<EnterFolderPrefabValues> ();
		folder.AttatchGUI (prefabValues);
		folderPrefab.transform.SetParent (contentFromScroll.transform);
	}

	public void SetTheme(string theme){

		this.themeText.text = theme;
	}
}
