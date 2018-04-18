using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompeteImagePrefabValues : MonoBehaviour {

	public LayoutElement layoutE;
	public RawImage picToDisplay;

	public void AdjustLayoutElement(float width, float height){

		layoutE.minWidth = width;
		layoutE.minHeight = height;
	}

	public void AdjustRawImageDimensions(float width, float height){
		Vector2 v = new Vector2 (width, height);
		picToDisplay.rectTransform.sizeDelta = v;
	}

	public void SetPic(Texture2D t){
		picToDisplay.texture = t;
	}


}
