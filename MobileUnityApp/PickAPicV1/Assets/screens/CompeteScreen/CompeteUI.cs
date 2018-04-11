using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompeteUI : MainScreensUI {
	public Text themeText;
	public Button uploadSelectButton;
	public Button saveButton;
	public RawImage uploadImageDisplay;
	public InputField description;



	public void SetThemeText(string themeText){
		this.themeText.text = themeText;
	}


	public void SetUploadImage(Texture2D pic){
		uploadImageDisplay.texture = pic;
	}

	public string GetDescription(){
		return description.text;
	}



}
