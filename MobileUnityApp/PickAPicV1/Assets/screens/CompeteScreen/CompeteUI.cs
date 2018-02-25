using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompeteUI : NormalUserScreensUI {
	public Text weekText;
	public Text themeText;
	public Button uploadSelectButton;
	public Button saveButton;
	public Image uploadImage;



	public void SetThemeText(string themeText){
		this.themeText.text = themeText;
	}



}
