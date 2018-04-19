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
		Vector2 newDimensions = adjustDimensions (new Vector2 (potentialUpload.texture.width, potentialUpload.texture.height), DimensionValues.IMAGE_DISPLAY_WIDTH);
		prefabValues.AdjustButtonDimensions (newDimensions.x, newDimensions.y);
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


	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);
	}
}
