using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompeteUI : MainScreensUI {
	public Text themeText;
	public Button uploadSelectButton;
	public Button saveButton;
	public GameObject competeImagePrefab;
	public InputField description;
	public Transform attachPicToThis;

	public PhotoCamera cam;
	public Button useCamera;

	void Awake(){
		
	}



	public void SetThemeText(string themeText){
		this.themeText.text = themeText;
	}



	//TODO change this so it works with the scroll view!!!
	public void SetUploadImage(Texture2D pic){
		

		GameObject displayPic = GameObject.Instantiate(competeImagePrefab);
		CompeteImagePrefabValues values = displayPic.GetComponent<CompeteImagePrefabValues> ();
		values.AdjustLayoutElement (pic.width, pic.height);
		values.AdjustRawImageDimensions (pic.width, pic.height);
		values.SetPic (pic);

		displayPic.transform.SetParent (attachPicToThis);
	}

	public void RemoveUploadImage(){
		//TODO
		for (int i = 0; i < attachPicToThis.childCount; i++) {
			//GameObject competeEntry = attachPicToThis.GetChild(i).gameObject;
			GameObject.Destroy(attachPicToThis.GetChild(i).gameObject);
			//GameObject.Destroy (competeEntry.GetComponent<CompeteImagePrefabValues> ());
			//GameObject.Destroy (competeEntry);

		}
	}

	public string GetDescription(){
		return description.text;
	}

	//todo maybe delete this
	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);
	}



}
