using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditImageUI : MonoBehaviour {
	public InputField description;
	public RawImage chosenPic;
	public Button confirmButton;



	public void SetChosenPic(Texture2D texture){
		chosenPic.texture = texture;
	}

	public string GetDescription(){
		return this.description.text;
	}
}
