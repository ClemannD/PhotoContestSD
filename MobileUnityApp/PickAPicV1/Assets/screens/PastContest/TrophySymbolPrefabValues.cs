using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophySymbolPrefabValues : MonoBehaviour {
	public Image trophySymbol;
	public Text trophyLabel;


	public void SetImage(Sprite s){
		this.trophySymbol.sprite = s;
	}

	public void SetLabel(string s){
		this.trophyLabel.text = s;
	}

	public Sprite GetImageSprite(){
		return this.trophySymbol.sprite;
	}

	public string GetLabel(){
		return this.trophyLabel.text;
	}
}
