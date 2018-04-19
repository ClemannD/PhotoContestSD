using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickImagePrefabValues : MonoBehaviour {
	public RawImage thumbnail;//the picture
	public Button picButton;//click this to select as the upload image
	public LayoutElement layoutElement;

	public void SetThumbnail(Texture t){
		thumbnail.texture = t;
	}

	public void AdjustButtonDimensions(float width, float height){
		layoutElement.minWidth = width;
		layoutElement.minHeight = height;
	}
}
